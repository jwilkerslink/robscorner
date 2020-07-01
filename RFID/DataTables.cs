using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace RFID
{
    class InsertEventArgs : EventArgs
    {
        readonly tagByte t;
        public tagByte T { get { return t; } }
        public InsertEventArgs(tagByte t)
        { this.t = t; }
    }

    class DataTables
    {
        const int readFloor = 20;

        static DataTable dtTracker = new DataTable();
        //public static BindingSource bsTracker = new BindingSource();
        static DataTable dtMaster = new DataTable();
        //public static BindingSource bsMaster = new BindingSource();
        static DataTable dtAlias = new DataTable();

        public static void InitDTs()
        {
            //bsTracker.DataSource = dtTracker;
            //bsMaster.DataSource = dtMaster;

            InitializeDTTracker();
            InitializeDTMaster();
            InitializeDTAlias();
        }

        public static void UpdateDTs(tagByte tag)
        {
            // -
            //this update function does way too much and needs to be modularized after removal of DGVs
            // -

            string id = "'" + tag.tagID + "'";

            DataRow[] resultT = dtTracker.Select("tagID = " + id);

            if (resultT.Count() < 1) // if tag is not in Tracker,
            {
                dtTracker.Rows.Add(tag.tagID, tag.location, tag.RSSI, 1, tag.evnt, tag.dateTime, tag.dateTime, "false"); //Console.WriteLine("added to DGV:" + tag.tagID);
                //add it to Tracker
            }
            else if (resultT.Count() > 0) // if it is, check if it's in Master,
            {
                DataRow[] resultM = dtMaster.Select("alias = " + id);

                if (resultM.Count() > 0) // if it's in Master, Update RSSI, current location, and last read time
                {
                    foreach (DataRow row in resultM)
                    {
                        dtMaster.Rows[dtMaster.Rows.IndexOf(row)]["RSSI"] = tag.RSSI;
                        dtMaster.Rows[dtMaster.Rows.IndexOf(row)]["last read time"] = tag.dateTime;
                        dtMaster.Rows[dtMaster.Rows.IndexOf(row)]["current location"] = tag.location;

                        TagTimer.UpdateSubject(tag.tagID, tag.dateTime);
                    }
                }
                else//if it's not, check its readFloor. if readcount hits threshhold, add it to master.
                {
                    foreach (DataRow row in resultT)
                    {
                        if (Convert.ToInt32(dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["read count"]) >= readFloor) // && dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["in master"] == "false")
                        {
                            dtMaster.Rows.Add(tag.tagID,
                                                dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["discovered at antenna"],
                                                dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["discovered at antenna"],
                                                DateTime.Now,
                                                DateTime.Now,
                                                tag.RSSI
                                              );

                            dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["in master"] = "true";
                            dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["RSSI"] = "# # # # #";
                            dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["last read"] = "# # # # #";
                            dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["read count"] = "0";

                            tag.evnt = "ADDED";
                            TagTimer.AddSubject(tag.tagID, tag.dateTime);
                            InsertSignal.IncomingSignal(tag);
                            // this is where the 'ADDED event' is inserted into the DB
                        }
                        else//if it hasn't hit its readFloor yet, keep updating it on tracker
                        {
                            if (dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["in master"] != "false")
                            { dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["in master"] = "false"; }
                            dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["RSSI"] = tag.RSSI;
                            dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["last read"] = tag.dateTime;
                            dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["read count"] = Convert.ToInt32(dtTracker.Rows[dtTracker.Rows.IndexOf(row)]["read count"]) + 1;
                        }
                    }
                }
            }
            //RefreshSignal.IncomingSignal(bsTracker);
            //RefreshSignal.IncomingSignal(bsMaster);

            //Refresh(bsTracker, dgvTracker);
            //Refresh(bsMaster, dgvMaster);
            ////SetCount(lblTagCount, (dgvTracker.Rows.Count - 1).ToString());
            //SetCount(lblTagCount, dgvTracker.Rows.Count.ToString());
        }
        public static void TagRemoved(string key)
        {
            Console.WriteLine("Tag removed from master: " + key);
            DataRow[] result = dtMaster.Select("alias = " + "'" + key + "'");

            foreach (DataRow row in result)
            { dtMaster.Rows.Remove(row); }

            //RefreshSignal.IncomingSignal(bsMaster);
            //this is what refreshes DGV
        }

        public static class InsertSignal
        {
            static public event EventHandler<InsertEventArgs> SignalReceived = delegate { };

            static public void OnSignalReceived(InsertEventArgs v)
            { SignalReceived?.Invoke(null, v); }

            static public void IncomingSignal(tagByte t)
            { OnSignalReceived(new InsertEventArgs(t)); }
        }

        private static void InitializeDTTracker()
        {
            dtTracker.Columns.Add("tagID");
            dtTracker.Columns.Add("discovered at antenna");
            dtTracker.Columns.Add("RSSI");
            dtTracker.Columns.Add("read count");
            dtTracker.Columns.Add("added by process");
            dtTracker.Columns.Add("discovery time");
            dtTracker.Columns.Add("last read");
            dtTracker.Columns.Add("in master");
        }
        private static void InitializeDTMaster()
        {
            dtMaster.Columns.Add("alias");
            dtMaster.Columns.Add("discovered at location");
            dtMaster.Columns.Add("current location");
            dtMaster.Columns.Add("added time");
            dtMaster.Columns.Add("last read time");
            dtMaster.Columns.Add("RSSI");
        }
        private static void InitializeDTAlias()
        {
            dtAlias.Columns.Add("tagID");
            dtAlias.Columns.Add("alias");
        }

        // Unused - - - - - v
        public static class RefreshSignal
        {
            static public event EventHandler<RefreshEventArgs> SignalReceived = delegate { };

            static public void OnSignalReceived(RefreshEventArgs v)
            { SignalReceived?.Invoke(null, v); }

            static public void IncomingSignal(BindingSource b)
            { OnSignalReceived(new RefreshEventArgs(b)); }
        }
    }

    class RefreshEventArgs : EventArgs
    {
        readonly BindingSource b;
        public BindingSource B { get { return b; } }
        public RefreshEventArgs(BindingSource b)
        { this.b = b; }
    }
    // Unused - - - - - ^
}
