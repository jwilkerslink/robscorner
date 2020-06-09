using RFID.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID
{
    public partial class frmSettingsPane : Form
    {
        rfidSetting settings = new rfidSetting();
        public frmSettingsPane()
        {
            InitializeComponent();
        }
        class rfidSetting
        {
            private bool init;

            public rfidSetting()
            {
                init = true;
            }
            public bool isInitialized()
            {
                return init;
            }
            public void save(string i, decimal p, string u, string c)
            {
                Settings.Default.ReaderIP = i;
                Settings.Default.TCPPort = p;
                Settings.Default.AlienReaderUsername = u;
                Settings.Default.AlienReaderPassword = c;
                Settings.Default.Save();
                //System.Windows.Forms.Application.ExitThread();
            }
            //public Tuple<string, decimal> display()
            //{
            //    return Tuple.Create(IP, port);
            //}
        }
        private void frmSettingsPane_Load(object sender, EventArgs e)
        {
            txtIP.Text = Settings.Default.ReaderIP;
            nudPort.Value = Settings.Default.TCPPort;
            txtUser.Text = Settings.Default.AlienReaderUsername;
            txtPass.Text = Settings.Default.AlienReaderPassword;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            settings.save(txtIP.Text, nudPort.Value, txtUser.Text, txtPass.Text);
            this.Close();
        }
    }
}
