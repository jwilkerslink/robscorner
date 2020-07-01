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
using System.Net.Sockets;
using System.Net;

namespace RFID
{
    public partial class frmRFIDMain : Form
    {
        clsReader mReader = new clsReader();
        Worker w = new Worker();

        public Connection con = new Connection();

        const int TCPPort = 11000;
        const string format = "<TagID>%k</TagID><Antenna>%A</Antenna><Time>${DATE2} ${TIME2}</Time><RSSI>%m</RSSI>";
        const string lineseparator = "\r\n - - - - - - - - - - - -\r\n";

        string msgBuffer;
        bool flagBuffer = false;


        public frmRFIDMain()
        {
            InitializeComponent();
            DataTables.InitDTs();
            TagTimer.InitTimer();
        }

        private void frmRFIDMain_Load(object sender, EventArgs e)
        {
            //dgvTracker.DataSource = DataTables.bsTracker;
            //dgvMaster.DataSource = DataTables.bsMaster;
            // bind data source for dgvTracker and Master

            mReader.MessageReceived += MReader_MessageReceived;
            // subscribe to event that allows us to receive response from the Reader

            AsynchronousSocketListener.PassMessage.MessageReceived += (s, v) =>
                HandleData(v.Message.ToString());
            // subscribe to event that brings data received by TCP socket from static Listener class file

            TagTimer.RemoveSignal.SignalReceived += (s, v) =>
                DataTables.TagRemoved(v.Tag);
            // subscribe to event that tells us when to remove a tag from our list

            DataTables.RefreshSignal.SignalReceived += (s, v) =>
                Refresh(v.B);
            //subscribe to event that tells us when to refresh DGVs

            DataTables.InsertSignal.SignalReceived += (s, v) =>
                InsertIntoRFIDTracker(v.T);

            con.changeCon(Settings.Default.Pipe);
            // sets up the connection string for interaction with LocalDB

            bwConnect.RunWorkerAsync();
            // attempt to connect to the Reader for cmd interaction
        }

        private void ConsumeTag(tagByte tag)
        { DataTables.UpdateDTs(tag); }

        private void HandleData(string data)
        {
            if (Encoding.ASCII.GetByteCount(data) >= 1024)
            {
                msgBuffer += data;
                flagBuffer = true;
            }
            else
            {
                List<tagByte> list = w.ParsePacket(new packet(msgBuffer + data, parseType.parseTag, DateTime.Now));

                for (int j = 0; j < list.Count(); j++)
                {
                    ConsumeTag(list[j]);
                }

                SetText(txtStream, data + lineseparator);
                if (flagBuffer == true)
                {
                    msgBuffer = "";
                    flagBuffer = false;
                }
            }
        }

        //private int ClientCheck()
        //{
        //    return 0;
        //}

        //private void SendUpdate(tagByte tag)
        //{
        //    //this will replace update dgvmaster when we have clients to send updates to
        //}

        //private void UpdateHandler(tagByte tag)
        //{
        //    int clients;
        //    if (0 < (clients = ClientCheck()))
        //    {
        //        for (int i = 0; i < clients; i++)
        //        {
        //            SendUpdate(tag);
        //        }
        //    }
        //    else
        //    { return; }
        //}

        public delegate void SetCountDelegate(System.Windows.Forms.Label ctrl, string text);
        public static void SetCount(System.Windows.Forms.Label ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                object[] params_list = new object[] { ctrl, text };

                ctrl.Invoke(new SetCountDelegate(SetCount), params_list);
            }
            else
            {
                ctrl.Text = text;
            }
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
            }
        }

        public delegate void RefreshDelegate(BindingSource b);
        public void Refresh(BindingSource b)
        {
            //DataGridView ctrl = new DataGridView();
            //if (b == DataTables.bsMaster)
            //{ ctrl = dgvTracker; }
            //else if (b == DataTables.bsTracker)
            //{ ctrl = dgvTracker; }


            //if (ctrl.InvokeRequired)
            //{
            //    object[] params_list = new object[] { b};

            //    ctrl.Invoke(new RefreshDelegate(Refresh), params_list);
            //}
            //else
            //{ b.ResetBindings(false); }
        }

        public delegate void AddRowDelegate(System.Windows.Forms.DataGridView ctrl, string location, string tagID, string evnt, DateTime dateTime);
        public static void AddRow(System.Windows.Forms.DataGridView ctrl, string tagID, string location, string evnt, DateTime dateTime)
        {
            if (ctrl.InvokeRequired)
            {
                object[] params_list = new object[] { ctrl, tagID, location, evnt, dateTime };

                ctrl.Invoke(new AddRowDelegate(AddRow), params_list);
            }

            else
            {
                char[] p = { ',' };
                ctrl.Rows.Insert(0, tagID, location, evnt, dateTime);
                //ctrl.Rows.Add();
            }

        }


        private void Monitor_ReaderRemoved(IReaderInfo data)
        {
            txtConsole.Text = txtConsole.Text + "\r\n Reader " + data.Name + " has been Removed. IP: " + data.IPAddress;


            //throw new NotImplementedException();
        }

        private void Monitor_ReaderAdded(IReaderInfo data)
        {

            txtConsole.Text = txtConsole.Text + "\r\n Reader " + data.Name + " has been Added. IP: " + data.IPAddress;

            //throw new NotImplementedException();
        }

        private void MReader_MessageReceived(string data)
        {
            Console.WriteLine("message received.");
            Console.WriteLine("data: " + data);
            SetText(txtConsole, data + "\r\n");
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

        private void Monitor_ReaderRemovedOnSerial(IReaderInfo data)
        {
            txtConsole.Text = txtConsole.Text + "\r\n Reader " + data.Name + " has been Removed. IP: " + data.IPAddress;

            //throw new NotImplementedException();
        }

        private void Monitor_ReaderAddedOnSerial(IReaderInfo data)
        {
            txtConsole.Text = txtConsole.Text + "\r\n Reader " + data.Name + " has been Added. IP: " + data.IPAddress;

            //throw new NotImplementedException();
        }

        private void btnTagList_Click(object sender, EventArgs e)
        {
            rtrvTagList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mReader.Send(txtCommand.Text + "\r\n", false);
        }

        private void rtrvTagList()
        {
            if (mReader.ParseTagList(mReader.TagList, out ITagInfo[] tagInfos))
            {
                int ctr = 0;
                foreach (ITagInfo tag in tagInfos)
                {
                    SetText(txtConsole, "TagID:" + tag.TagID + "\r\n Read Count:" + tag.ReadCount + "\r\n Last Seen:" + tag.LastSeenTime + lineseparator);
                    ctr++;
                }
                txtConsole.AppendText("Number of tags within list: " + ctr + lineseparator);
            }
            else
            { Console.WriteLine("taglist triggered but is empty"); txtConsole.AppendText(lineseparator + "Taglist triggered but is empty."); }
        }

        private void bwNotifications_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void bwNotifications_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bwNotifications.RunWorkerAsync();
        }

        private void bwConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            SetText(txtConsole, "Attempting connection. . .\r\n");
            mReader.InitOnNetwork(Settings.Default.ReaderIP, Convert.ToInt32(Settings.Default.TCPPort));

            if ("Connected" == (e.Result = mReader.Connect()))
            {
                SetText(txtConsole, e.Result.ToString() + ".\r\n");

                if (mReader.Login(Settings.Default.AlienReaderUsername, Settings.Default.AlienReaderPassword))
                { SetText(txtConsole, "Logged in.\r\n"); }
            }
            else
            { SetText(txtConsole, "Retrying connection.\r\n"); Thread.Sleep(2000); }
            //Initialize network connection to reader using application settings
        }

        private void bwConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string stemp = e.Result.ToString();


            if (stemp == "Connected")
            {
                if (mReader.DateTime != DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                { mReader.DateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); }

                //find a way to make this dynamic

                bwListen.RunWorkerAsync();

                mReader.TagStreamAddress = Dns.GetHostName().ToString() + ":" + TCPPort;
                mReader.NotifyMode = "OFF";
                mReader.TagStreamCustomFormat = format;
                mReader.TagStreamMode = "ON";
            }
            else
            {
                bwConnect.RunWorkerAsync();
            }
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetText(txtConsole, "\r\n" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "> " + txtCommand.Text);
                mReader.Send(txtCommand.Text + "\r\n", false);
                txtCommand.Text = "";
            }
        }

        private void txtUnitHistory_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettingsPane currSettings = new frmSettingsPane(this);
            currSettings.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        { MessageBox.Show("Dear god, WHY?!?!?"); }

        private void bwListen_DoWork(object sender, DoWorkEventArgs e)
        { AsynchronousSocketListener.StartListening(); }

        private void InsertIntoRFIDTracker(tagByte tag)
        {
            Console.WriteLine("Inserting into table.");

            SqlCommand InsertIntoRFIDTracker = new SqlCommand($@"Insert Into
                                                                    RFIDTracker
                                                                Values
                                                                    (@TID, @loc, @evnt, @DT)", con.nection);
            InsertIntoRFIDTracker.Parameters.AddWithValue("@TID", tag.tagID);
            InsertIntoRFIDTracker.Parameters.AddWithValue("@loc", tag.location);
            InsertIntoRFIDTracker.Parameters.AddWithValue("@evnt", tag.evnt);
            InsertIntoRFIDTracker.Parameters.AddWithValue("@DT", tag.dateTime);
            con.nection.Open();
            InsertIntoRFIDTracker.ExecuteNonQuery();
            con.nection.Close();
        }


        private void Monitor_ReaderAddedSerial()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //dgvUnitHistory.DataSource = GetHistory(txtUnitHistory.Text);
            //dgvUnitHistory.Columns[0].FillWeight = 25;
            //dgvUnitHistory.Rows.Clear();

            //DataTable dt = new DataTable();
            //foreach (DataGridViewColumn col in dgvTracker.Columns)
            //{
            //    dt.Columns.Add(col.Name);
            //}

            //foreach (DataGridViewRow row in dgvTracker.Rows)
            //{
            //    DataRow dRow = dt.NewRow();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        dRow[cell.ColumnIndex] = cell.Value;
            //    }
            //    dt.Rows.Add(dRow);
            //}

            //DataRow[] result = dt.Select($"TagID = '{txtUnitHistory.Text}'", "Time Desc");

            //dt = new DataTable();

            //foreach (DataRow row in result)
            //{
            //    AddRow(dgvUnitHistory, row[0].ToString(), row[1].ToString(), row[2].ToString(), DateTime.Parse(row[3].ToString()));

            //}

            //dgvUnitHistory.DataSource = dt;
            //String stemp;
            //mReader.InitOnCom(3);// ‘Initialize reader object on COM1
            //stemp = mReader.Connect();
            //txtConsole.Text = txtConsole.Text + "\r\n" + stemp;
        }

        private void dgvTracker_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataRow[] search = dtAlias.Select("tagID = " + "'" + dtTracker.Rows[e.RowIndex][0].ToString() + "'");

            //if (search.Count() == 0)
            //{
            //    if (MessageBox.Show("No alias found. Assign one?", "Alias", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        using (var pane = new frmAliasPane())
            //        {
            //            pane.ShowDialog();
            //            if (pane.Alias != "")
            //            {
            //                dtAlias.Rows.Add(dtTracker.Rows[e.RowIndex][0].ToString(), pane.Alias);
            //            }
            //        }
            //    }
            //}
            //else if (search.Count() >= 1)
            //{ MessageBox.Show("Alias already exists."); }
        }

        private void dgvTracker_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        { 
            //lblTagCount.Text = dgvTracker.Rows.Count.ToString(); 
        }
        private void dgvTracker_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        { 
            //lblTagCount.Text = dgvTracker.Rows.Count.ToString(); 
        }
    }
}
