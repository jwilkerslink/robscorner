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
namespace RFID
{
    public partial class Form1 : Form
    {

        clsReaderMonitor Monitor = new clsReaderMonitor();
        clsReader mReader = new clsReader();
        const string reasonStr = "Reason:";

        public delegate void AddRowDelegate(System.Windows.Forms.DataGridView ctrl, string tagID, string evnt, DateTime dateTime);
        public static void AddRow(System.Windows.Forms.DataGridView ctrl, string tagID, string evnt, DateTime dateTime)
        {
            if (ctrl.InvokeRequired)
            {

                object[] params_list = new object[] { ctrl, tagID, evnt, dateTime };

                ctrl.Invoke(new AddRowDelegate(AddRow), params_list);

            }

            else
            {
                char[] p = { ',' };
                ctrl.Rows.Insert(0, tagID, evnt, dateTime);
                //ctrl.Rows.Add();
            }

        }


        public Form1()
        {
            InitializeComponent();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //Monitor.ReaderAdded += Monitor_ReaderAdded;
            //Monitor.ReaderRemoved += Monitor_ReaderRemoved;
            //Monitor.ReaderAddedOnSerial += Monitor_ReaderAddedOnSerial;
            //Monitor.ReaderRemovedOnSerial += Monitor_ReaderRemovedOnSerial;
            ////mReader.MessageReceived += MReader_MessageReceived;
            //Monitor.ComPortsMonitoring = true;
            //mReader.NotifyMode = "ON";
            //mReader.AutoMode = "ON";
            //Monitor.CheckComPorts();
            bwConnect.RunWorkerAsync();
        }

        //private void MReader_MessageReceived(string data)
        //{
        //    string tl;
        //    ITagInfo[] tagInfos;
        //    int start = data.IndexOf("#StopTriggerLines:");
        //    if (start > 0)
        //    {

        //        start = data.IndexOf("Tag:", start);
        //        int ennd = data.IndexOf("\r\n#End of Notification Message", start);

        //        tl = data.Substring(start, ennd - start);

        //        if (mReader.ParseTagList(tl, out tagInfos))
        //        {
        //            foreach (ITagInfo tag in tagInfos)
        //            {
        //                textBox1.Text = textBox1.Text + "\r\n TagID:" + tag.TagID + "\r\n Read Count:" + tag.ReadCount + "\r\n Last Seen:" + tag.LastSeenTime;
        //                textBox1.Select(textBox1.Text.Length, 0);
        //                textBox1.ScrollToCaret();
        //            }
        //        }

        //    }

        //    SetText(textBox1, data);


        //    //ITagInfo[] tagInfos;
        //    //if (mReader.ParseTagList(data, out tagInfos))
        //    //{
        //    //    foreach (ITagInfo tag in tagInfos)
        //    //    {
        //    //        SetText(textBox1, data);
        //    //    }
        //    //}

            
        //    //textBox1.Text = textBox1.Text + "\r\n" + data;
        //    //textBox1.Select(textBox1.Text.Length, 0);
        //    //textBox1.ScrollToCaret();
        //}

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
                ctrl.Text = ctrl.Text + text + "\r\n";
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

            //String stemp;
            //mReader.InitOnCom(3);// ‘Initialize reader object on COM1
            //stemp = mReader.Connect();
            //textBox1.Text = textBox1.Text + "\r\n" + stemp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ITagInfo[] tagInfos;
            var tl = mReader.TagList;
            //textBox1.Text = textBox1.Text + tl;
            //textBox1.Select(textBox1.Text.Length, 0);
            //textBox1.ScrollToCaret();
            

            if (mReader.ParseTagList(tl, out tagInfos))
            {
                foreach (ITagInfo tag in tagInfos)
                {
                    textBox1.Text = textBox1.Text + "TagID:" + tag.TagID + "\r\n Read Count:" + tag.ReadCount + "\r\n Last Seen:" + tag.LastSeenTime + "\r\n";
                    textBox1.Select(textBox1.Text.Length, 0);
                    textBox1.ScrollToCaret();
                }
            }
                

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] temp;
            int messages;

            //mReader.NotifyMode = "ON";
            //mReader.AutoMode = "ON";

            //messages = mReader.GetCurrentMessages(out temp);
            
            //if (messages > 0)
            //{
            //    foreach(string data in temp)
            //    {
            //        textBox1.Text = textBox1.Text + "\r\n" + data;
            //        textBox1.Select(textBox1.Text.Length, 0);
            //        textBox1.ScrollToCaret();
            //    }
            //}

        }

        private void bwNotifications_DoWork(object sender, DoWorkEventArgs e)
        {

            if (mReader.GetCurrentMessages(out string[] Notifications) > 0)
            {
                string tl,reason;
                ITagInfo[] tagInfos;
                int start,end;

                foreach (string notification in Notifications)
                {
                    SetText(textBox1, notification);
                    start = notification.IndexOf(reasonStr) + reasonStr.Count();
                    if (start > 0)
                    {
                        end = notification.IndexOf("\r\n",start);
                        reason = notification.Substring(start,end - start);
                        SetText(textBox1, reason);

                        start = notification.IndexOf("Tag:", start);
                        if (start > 0)
                        {

                            int ennd = notification.IndexOf("\r\n#End of Notification Message", start);

                            tl = notification.Substring(start, ennd - start);

                            if (mReader.ParseTagList(tl, out tagInfos))
                            {
                                //tagInfos.
                                foreach (ITagInfo tag in tagInfos)
                                {
                                    SetText(textBox1, "Direction: " + tag.Direction + "Antenna: " + tag.Antenna + "TagID: " + tag.TagID + ",Read Count: " + tag.ReadCount + ",Last Seen:" + tag.LastSeenTime + "\r\n");
                                    AddRow(dgvTracker, tag.TagID, reason.Contains("ADD") ? "Enter" : "Leave", DateTime.Now);
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
            mReader.InitOnCom(3);// ‘Initialize reader object on COM1
            e.Result = mReader.Connect();

        }

        private void bwConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string stemp;

            stemp = e.Result.ToString();
            textBox1.Text = textBox1.Text + "\r\n" + stemp + "\r\n";

            if (stemp == "Connected")
            {
                mReader.NotifyMode = "ON";
                mReader.AutoMode = "ON";
                bwNotifications.RunWorkerAsync();
            }
            else
            {
                bwConnect.RunWorkerAsync();
            }

        }


    }
}
