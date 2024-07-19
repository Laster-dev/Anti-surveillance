using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anti_surveillance
{
    public partial class BlackForm : Form
    {
        [DllImport("user32.dll")]
        static extern void SetWindowDisplayAffinity(IntPtr handle, int flag);
        public BlackForm()
        {
            InitializeComponent();
            SetWindowDisplayAffinity(Handle,1);
        }
    }
}
