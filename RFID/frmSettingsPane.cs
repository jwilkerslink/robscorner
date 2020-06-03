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
            private decimal port;
            private string IP;
            private bool init;

            public rfidSetting()
            {
                init = true;
            }
            public bool isInitialized()
            {
                return init;
            }
            public void save(string i, decimal p)
            {
                Settings.Default.ReaderIP = i;
                Settings.Default.TCPPort = p;
                Settings.Default.Save();
                //System.Windows.Forms.Application.ExitThread();
            }
            public Tuple<string, decimal> display()
            {
                return Tuple.Create(IP, port);
            }
        }
        private void frmSettingsPane_Load(object sender, EventArgs e)
        {
            txtIP.Text = Settings.Default.ReaderIP;
            nudPort.Value = Settings.Default.TCPPort;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            settings.save(txtIP.Text, nudPort.Value);
            this.Close();
        }
    }
}
