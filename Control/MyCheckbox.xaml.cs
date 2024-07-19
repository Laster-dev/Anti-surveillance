using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Anti_surveillance.Control
{
    /// <summary>
    /// MyCheckbox.xaml 的交互逻辑
    /// </summary>
    public partial class MyCheckbox : UserControl
    {
        public MyCheckbox()
        {
            InitializeComponent();
        }
        public bool _check { get; set; }
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(MyCheckbox), new PropertyMetadata(false, OnIsCheckedChanged));

        private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MyCheckbox;
            if (control != null)
            {
                bool isChecked = (bool)e.NewValue;
                if (isChecked)
                {
                    Storyboard storyboard1 = (Storyboard)control.Resources["Storyboard1"];
                    storyboard1.Begin();
                }
                else
                {
                    Storyboard storyboard2 = (Storyboard)control.Resources["Storyboard2"];
                    storyboard2.Begin();
                }
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsChecked = !IsChecked;
        }

        //private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        //    {
        //        _check = !_check;
        //        if (_check)
        //        {
        //            Storyboard storyboard = (Storyboard)this.Resources["Storyboard1"];
        //            storyboard.Begin();
        //        }
        //        else
        //        {
        //            Storyboard storyboard = (Storyboard)this.Resources["Storyboard2"];
        //            storyboard.Begin();
        //        }
        //    }
        //}
    }
}
