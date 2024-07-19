using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Anti_surveillance
{
    public partial class MainWindow : Window//, INotifyPropertyChanged
    {
        private bool _someBoolProperty;
        BlackForm BlackForm = null;
        private DispatcherTimer timer;
        public bool SomeBoolProperty
        {
            get { return _someBoolProperty; }
            set
            {
                _someBoolProperty = value;
                OnPropertyChanged();
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500); // 设置时间间隔为500毫秒
            timer.Tick += Timer_Tick;
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            CaptureScreen();
        }

        private void CaptureScreen()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new System.Drawing.Point(bounds.Left, bounds.Top), System.Drawing.Point.Empty, bounds.Size);
                }
                BitmapImage imageSource = BitmapToImageSource(bitmap);
                Dispatcher.Invoke(() => ScreenImage.Source = imageSource);
            }
        }

        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void myCheckbox_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _someBoolProperty = !_someBoolProperty;
            if (!_someBoolProperty) {
                BlackForm.Close();
                return;
            }
            BlackForm = new BlackForm();
            BlackForm.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
