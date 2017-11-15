using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TorStartupCS
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }
        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            ProcessStart.ProcessStartUp();
            ProxyToggle.ProxyOn();
            
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            ProxyToggle.ProxyOff();
            ProcessStart.ProcessQuit();
        }
    }
}
