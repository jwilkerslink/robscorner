using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using RFID.Properties;

namespace RFID
{
    public partial class frmSettingsPane : Form
    {
        private frmRFIDMain _RFIDMain;

        rfidSetting settings = new rfidSetting();
        public frmSettingsPane(frmRFIDMain RFIDMain)
        {
            InitializeComponent();
            _RFIDMain = RFIDMain;
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
            public void save(string i, decimal p, string u, string c, bool s)
            {
                Settings.Default.ReaderIP = i;
                Settings.Default.TCPPort = p;
                Settings.Default.AlienReaderUsername = u;
                Settings.Default.AlienReaderPassword = c;
                Settings.Default.OpenSSMSOnRun = s;
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
            chkRunSSMS.Checked = Settings.Default.OpenSSMSOnRun;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            settings.save(txtIP.Text, nudPort.Value, txtUser.Text, txtPass.Text, chkRunSSMS.Checked);
            this.Close();
        }
        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            using (Process currP = new Process())
            {
                currP.StartInfo.FileName = ".\\LocalDB\\setupDB.exe";

                if (Settings.Default.OpenSSMSOnRun == true)
                { currP.StartInfo.Arguments = "-s"; }

                currP.Start();
                currP.WaitForExit();
            }

            using (StreamReader file = new StreamReader(".\\LocalDB\\logs\\currPipe.txt"))
            {
                lblPipe.Text = file.ReadLine();
                _RFIDMain.con.changeCon(lblPipe.Text);
            }
        }
    }
}
