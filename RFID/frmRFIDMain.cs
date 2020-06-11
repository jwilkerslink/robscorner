using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using nsAlienRFID2;
using Microsoft.VisualBasic;
using System.Security.AccessControl;
using Microsoft.VisualBasic.Devices;
using System.Data.SqlClient;
using RFID.Properties;
using System.Diagnostics;

namespace RFID
{
    public partial class frmRFIDMain : Form
    {

        public Connection con = new Connection();
        clsReaderMonitor Monitor = new clsReaderMonitor();
        clsReader mReader = new clsReader();

        const string reasonStr = "Reason: ";
        readonly string lineseparator = "\r\n - - - - - - - - - - - -\r\n";

        //public static string connString = "Data Source=172.21.4.30;Initial Catalog=DEV_MfgTraveler;Persist Security Info=True;User ID=Travelmfg;Password=travelmfg@1";

        public frmRFIDMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            mReader.MessageReceived += MReader_MessageReceived;
            Monitor.ComPortsMonitoring = true;
            bwConnect.RunWorkerAsync();
            //mReader.NotifyMode = "ON";
            //mReader.AutoMode = "ON";
            //Monitor.CheckComPorts();
            //Monitor.ReaderAdded += Monitor_ReaderAdded;
            //Monitor.ReaderRemoved += Monitor_ReaderRemoved;
            //Monitor.ReaderAddedOnSerial += Monitor_ReaderAddedOnSerial;
            //Monitor.ReaderRemovedOnSerial += Monitor_ReaderRemovedOnSerial;
        }

        public delegate void AddRowDelegate(System.Windows.Forms.DataGridView ctrl, string location, string tagID, string evnt, DateTime dateTime);
        public static void AddRow(System.Windows.Forms.DataGridView ctrl, string tagID,string location, string evnt, DateTime dateTime)
        {
            if (ctrl.InvokeRequired)
            {

                object[] params_list = new object[] { ctrl, tagID,location, evnt, dateTime };

                ctrl.Invoke(new AddRowDelegate(AddRow), params_list);

            }

            else
            {
                char[] p = { ',' };
                ctrl.Rows.Insert(0, tagID,location, evnt, dateTime);
                //ctrl.Rows.Add();
            }

        }

        private void Monitor_ReaderRemoved(IReaderInfo data)
        {
            textBox1.Text = textBox1.Text + "\r\n Reader " + data.Name + " has been Removed. IP: " + data.IPAddress;


            //throw new NotImplementedException();
        }

        private void Monitor_ReaderAdded(IReaderInfo data)
        {

            textBox1.Text = textBox1.Text + "\r\n Reader " + data.Name + " has been Added. IP: " + data.IPAddress;

            //throw new NotImplementedException();
        }

        private void MReader_MessageReceived(string data)
        {
            string tl;
            ITagInfo[] tagInfos;
            int start = data.IndexOf("#StopTriggerLines:");
            if (start > 0)
            {

                start = data.IndexOf("Tag:", start);
                int ennd = data.IndexOf("\r\n#End of Notification Message", start);

                tl = data.Substring(start, ennd - start);

                if (mReader.ParseTagList(tl, out tagInfos))
                {
                    foreach (ITagInfo tag in tagInfos)
                    {
                        textBox1.Text = textBox1.Text + "\r\n TagID:" + tag.TagID + "\r\n Read Count:" + tag.ReadCount + "\r\n Last Seen:" + tag.LastSeenTime;
                        textBox1.Select(textBox1.Text.Length, 0);
                        textBox1.ScrollToCaret();
                    }
                }

            }

            SetText(textBox1, data);


            //ITagInfo[] tagInfos;
            //if (mReader.ParseTagList(data, out tagInfos))
            //{
            //    foreach (ITagInfo tag in tagInfos)
            //    {
            //        SetText(textBox1, data);
            //    }
            //}


            //textBox1.Text = textBox1.Text + "\r\n" + data;
            //textBox1.Select(textBox1.Text.Length, 0);
            //textBox1.ScrollToCaret();
        }

        public delegate void SetTextDelegate(System.Windows.Forms.TextBox ctrl, string text);

        public static void SetText(System.Windows.Forms.TextBox ctrl, string text)
        {

            if (ctrl.InvokeRequired)
            {

                object[] params_list = new object[] { ctrl, text };

                ctrl.Invoke(new SetTextDelegate(SetText), params_list);

            }

            else
            {
                ctrl.Text = ctrl.Text + text;
                ctrl.Select(ctrl.Text.Length, 0);
                ctrl.ScrollToCaret();
                //if (text == "Pass")
                //{
                //    ctrl.BackColor = Color.LightGreen;
                //}
                //else if (text == "???")
                //    ctrl.BackColor = Color.LightGray;
                //else if (text == "Fail")
                //    ctrl.BackColor = Color.Red;
                // ctrl.SelectionStart = ctrl.Text.Length;
                //  ctrl.ScrollToCaret();

            }

        }


        private DataTable GetHistory(string tagID)
        {
            SqlCommand sqlCommand = new SqlCommand($@"Select 
                                                        datetime,Substring(event,6,99) + Case When event = 'TAGS ADDED' Then ' To ' Else ' From ' end + location [event]
                                                    From
                                                        RFIDTracker
                                                    Where 
                                                        TagID = @TID
                                                    Order By
                                                        DateTime Desc", con.nection);
            sqlCommand.Parameters.AddWithValue("@TID", tagID);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }


        private void InsertIntoRFIDTracker(string tagID, string location, string evnt, DateTime dateTime)
        {
            SqlCommand InsertIntoRFIDTracker = new SqlCommand($@"Insert Into
                                                                    RFIDTracker
                                                                Values
                                                                    (@TID, @loc, @evnt, @DT)", con.nection);
            InsertIntoRFIDTracker.Parameters.AddWithValue("@TID", tagID);
            InsertIntoRFIDTracker.Parameters.AddWithValue("@loc", location);
            InsertIntoRFIDTracker.Parameters.AddWithValue("@evnt", evnt);
            InsertIntoRFIDTracker.Parameters.AddWithValue("@DT", dateTime);
            con.nection.Open();
            InsertIntoRFIDTracker.ExecuteNonQuery();
            con.nection.Close();
        }

        private void Monitor_ReaderRemovedOnSerial(IReaderInfo data)
        {
            textBox1.Text = textBox1.Text + "\r\n Reader " + data.Name + " has been Removed. IP: " + data.IPAddress;

            //throw new NotImplementedException();
        }

        private void Monitor_ReaderAddedOnSerial(IReaderInfo data)
        {
            textBox1.Text = textBox1.Text + "\r\n Reader " + data.Name + " has been Added. IP: " + data.IPAddress;

            //throw new NotImplementedException();
        }

        private void Monitor_ReaderAddedSerial()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dgvUnitHistory.DataSource = GetHistory(txtUnitHistory.Text);
            dgvUnitHistory.Columns[0].FillWeight = 25;
            dgvUnitHistory.Rows.Clear();

            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgvTracker.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvTracker.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            DataRow[] result = dt.Select($"TagID = '{txtUnitHistory.Text}'", "Time Desc");

            dt = new DataTable();

            foreach (DataRow row in result)
            {
                AddRow(dgvUnitHistory, row[0].ToString(), row[1].ToString(), row[2].ToString(), DateTime.Parse(row[3].ToString()));

            }

            dgvUnitHistory.DataSource = dt;
            String stemp;
            mReader.InitOnCom(3);// ‘Initialize reader object on COM1
            stemp = mReader.Connect();
            textBox1.Text = textBox1.Text + "\r\n" + stemp;
        }

        private void btnTagList_Click(object sender, EventArgs e)
        {
            rtrvTagList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mReader.Send(txtCommand.Text + "\r\n",false);
        }

        private void rtrvTagList()
        {
            if (mReader.ParseTagList(mReader.TagList, out ITagInfo[] tagInfos))
            {
                int ctr = 0;
                foreach (ITagInfo tag in tagInfos)
                {
                    textBox1.AppendText("TagID:" + tag.TagID + "\r\n Read Count:" + tag.ReadCount + "\r\n Last Seen:" + tag.LastSeenTime + lineseparator);
                    textBox1.Select(textBox1.Text.Length, 0);
                    textBox1.ScrollToCaret();
                    ctr++;
                }
                textBox1.AppendText("Number of tags within list: " + ctr + lineseparator);
            }
        }

        private void bwNotifications_DoWork(object sender, DoWorkEventArgs e)
        {

            if (mReader.GetCurrentMessages(out string[] Notifications) > 0)
            {
                string tl,reason = "";
                ITagInfo[] tagInfos;
                int start,end;


                foreach (string notification in Notifications)
                {
                    SetText(textBox1, "\r\n" + notification + "\r\n");
                    start = notification.IndexOf(reasonStr) + reasonStr.Count();
                    if (start > 6)
                    {
                        end = notification.IndexOf("\r\n", start);
                        reason = notification.Substring(start, end - start);                    

                        start = notification.IndexOf("Tag:", 0);

                        if (start > -1)
                        {

                            end = notification.IndexOf("\r\n#End of Notification Message", start);

                            if (end <= start)
                            {
                                tl = notification.Substring(start);
                            }
                            else
                            {
                                tl = notification.Substring(start, end - start);
                            }

                            if (mReader.ParseTagList(tl, out tagInfos))
                            {
                                foreach (ITagInfo tag in tagInfos)
                                {
                                    AddRow(dgvTracker, tag.TagID, mReader.ReaderName, reason, DateTime.Now);
                                    InsertIntoRFIDTracker(tag.TagID, mReader.ReaderName, reason, DateTime.Now);
                                }
                            }
                        }

                    }
                }

            }

        }


        private void bwNotifications_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bwNotifications.RunWorkerAsync();
        }

        private void bwConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            mReader.InitOnNetwork(Settings.Default.ReaderIP, Convert.ToInt32(Settings.Default.TCPPort));
            e.Result = mReader.Connect();
            //Initialize network connection to reader using application settings
        }

        private void bwConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string stemp;

            stemp = e.Result.ToString();
            textBox1.Text = textBox1.Text + "\r\n" + stemp + "\r\n";
            mReader.Login(Settings.Default.AlienReaderUsername, Settings.Default.AlienReaderPassword);

            if (stemp == "Connected")
            {
                if (mReader.DateTime != DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                { mReader.DateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); }

                mReader.NotifyMode = "ON";
                mReader.AutoMode = "ON";
                bwNotifications.RunWorkerAsync();
            }
            else
            {
                bwConnect.RunWorkerAsync();
            }

        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SetText(textBox1, "\r\n" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "> " + txtCommand.Text);
                mReader.Send(txtCommand.Text + "\r\n",false);
                txtCommand.Text = "";
            }
        }

        private void txtUnitHistory_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        dgvUnitHistory.DataSource = GetHistory(txtUnitHistory.Text);
        //        dgvUnitHistory.Columns[0].FillWeight = 50;
        //    }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettingsPane currSettings = new frmSettingsPane(this);
            currSettings.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dear god, WHY?!?!?");
        }
    }
}
