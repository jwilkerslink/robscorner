using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Timers;

namespace RFID
{
    class RemoveEventArgs : EventArgs
    {
        readonly string tag;
        public string Tag { get { return tag; } }
        public RemoveEventArgs(string tag)
        { this.tag = tag; }
    }

    class TagTimer
    {
        const int checkInterval = 1000; //how often in MS that our timer checks the tags in Master list for removal
        const int persistFloor = 2; //how long in seconds does a tag remain in Master without reads

        private static System.Timers.Timer time;
        private static DataTable subjects;

        public static bool IsRunning()
        {
            if (time.Enabled)
            { return true; }
            else
            { return false; }
        }
        public static void StopTimer()
        { time.Enabled = false; }
        public static void StartTimer()
        { time.Enabled = true; }
        public static void InitTimer()
        {
            Console.WriteLine("Timer initiated.");
            time = new System.Timers.Timer(checkInterval)
            { AutoReset = true};

            InitSubjects();

            time.Elapsed += AuditSubjects;
        }
        private static void InitSubjects()
        {
            subjects = new DataTable();

            DataColumn c1 = new DataColumn();
            c1.ColumnName = "tag";
            c1.DataType = Type.GetType("System.String");

            DataColumn c2 = new DataColumn();
            c2.ColumnName = "time";
            c2.DataType = Type.GetType("System.DateTime");

            subjects.Columns.Add(c1);
            subjects.Columns.Add(c2);
        }
        public static void AddSubject(string t, DateTime r)
        {
            Console.WriteLine("Subject added: " + t + " / " + r);
            subjects.Rows.Add(t, r);

            if (subjects.Rows.Count == 1)
            { StartTimer(); Console.WriteLine("Timer started."); }
        }
        public static void UpdateSubject(string t, DateTime r)
        {
            Console.WriteLine("Subject updated: " + t + " / " + r);
            foreach (DataRow row in subjects.Rows)
            { 
                if (row["tag"].ToString() == t)
                {
                    row["time"] = r;
                }
            }
        }
        public static void RemoveSubjects(List<DataRow> l)
        {
            Console.WriteLine("Subject removed.");

            foreach (DataRow row in l)
            { subjects.Rows.Remove(row); }

            if (subjects.Rows.Count == 0)
            { time.Enabled = false; Console.WriteLine("Timer stopped."); }
        }
        private static void AuditSubjects(Object source, ElapsedEventArgs e)
        {
            if (time.Enabled && subjects.Rows.Count > 0)
            {
                List<DataRow> garbage = new List<DataRow>();

                Console.WriteLine("Auditing subjects...");
                foreach (DataRow row in subjects.Rows)
                {
                    if ((e.SignalTime - Convert.ToDateTime(row["time"])).TotalSeconds >= persistFloor)
                    {
                        Console.WriteLine("time difference: " + (e.SignalTime - Convert.ToDateTime(row["time"])).TotalSeconds);
                        RemoveSignal.IncomingSignal(row["tag"].ToString());
                        garbage.Add(row);
                    }
                }
                if (garbage.Count() > 0)
                { RemoveSubjects(garbage); }
            }
            else
            { Console.WriteLine("Timer not enabled. Aborting audit."); }
        }
        public static class RemoveSignal
        {
            static public event EventHandler<RemoveEventArgs> SignalReceived = delegate { };

            static public void OnSignalReceived(RemoveEventArgs v)
            { SignalReceived?.Invoke(null, v); }

            static public void IncomingSignal(string tag)
            { OnSignalReceived(new RemoveEventArgs(tag)); }
        }

    }

}
