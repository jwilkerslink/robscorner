using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Counts
{
    public partial class Tracker : Form
    {

        public static string conString = "Data Source=172.16.4.27;Initial Catalog=MfgTraveler;Persist Security Info=True;User ID=travelmfg;Password=Tr@vel@mfg";
        private SqlConnection con = new SqlConnection(conString);
        private Stopwatch stopwatch = new Stopwatch();
        private Dictionary<int, int> countPass = new Dictionary<int, int>();
        private Dictionary<int, int> countFail = new Dictionary<int, int>();
        private Dictionary<int, Label> Pass = new Dictionary<int, Label>();
        private Dictionary<int, Label> Fail = new Dictionary<int, Label>();
        private Dictionary<int, Label> Rc = new Dictionary<int, Label>();
        private Dictionary<int, TextBox> count = new Dictionary<int, TextBox>();
        private string TS = DateTime.Today.ToShortDateString().ToString(), stat = "r";
        private DateTime T0 = DateTime.Today.Date + new TimeSpan(6, 0, 0);
        private DateTime Tn = DateTime.Now;
        private string sqlString = $@"
                                    CREATE TABLE #flow
                                    (
	                                    SerialNumber varchar(max),
	                                    Operation varchar(max),
	                                    Resolution varchar(max),
	                                    Product varchar(max),
	                                    Status varchar(max),
	                                    RecordDate DateTime,
                                    )



                                    ;WITH t AS
                                    (
	                                    SELECT 
		                                    o.[Serial Number], o.Operation, o.Resolution, o.Product,
		                                    d.Stat as status,
		                                    o.DateTime as [RecordDate] 
	                                    FROM Operations o
	                                    Inner join DeviceInfo d
	                                    on o.[Serial Number] = d.SerialNumber
	                                    WHERE
		                                    o.Product = 'LOC8' and
		                                    Operation not like '%Retest%' and
		                                    DateTime between @TS and DateAdd(Day,1,@TS) and
		                                    [Serial Number] < '1600000' and
		                                    Stat != @stat
                                    )


                                    INSERT INTO #flow
                                    SELECT [Serial Number], Operation, Resolution, Product, Status, RecordDate
                                    FROM t





                                    --0,Programming
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation = 'Programming'
                                    Group by Resolution

                                    --1, PCB1
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation = 'PCB Assembly 1'
                                    Group by Resolution

                                    --2, Activation
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation = 'Activation'
                                    Group by Resolution

                                    --3, PCB2
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation = 'PCB Assembly 2'
                                    Group by Resolution

                                    --4, BI
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation LIKE 'Board Install 3'
                                    Group by Resolution

                                    --5, Pre
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation like 'Pre%'
                                    Group by Resolution

                                    --6, Glue
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation = 'Glue'
                                    Group by Resolution

                                    --7, Post
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation LIKE 'Post%'
                                    Group by Resolution

                                    --8, Leak
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation like 'Leak%'
                                    Group by Resolution

                                    --9, QC
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation LIKE 'QC%'
                                    Group by Resolution

                                    --10, Recase
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation like '%Recase%'
                                    Group by Resolution

                                    --11, Service Programming
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation LIKE 'Service Program%'
                                    Group by Resolution

                                    --12, Service PCB
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation like 'Service PCB%'
                                    Group by Resolution

                                    --13, Service BI
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation like '%Service Board%'
                                    Group by Resolution

                                    --14, Receiving
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation LIKE 'Receiv%'
                                    Group by Resolution

                                    --15, Initial Inspection
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    where Operation like 'Initial Insp%'
                                    Group by Resolution

                                    --16,WIP
                                    select Resolution, COUNT(distinct SerialNumber) AS Quantity from #flow
                                    Group by Resolution
                                    order by Resolution

                                    DROP TABLE #flow";
        private bool isFormBeingDragged;
        private int mouseDownX;
        private int mouseDownY;


        public Tracker()
        {
            InitializeComponent();
            Pass.Add(0, lblProgCount);
            Pass.Add(1, lblPCB1);
            Pass.Add(2, lblActivation);
            Pass.Add(3, lblPCB2);
            Pass.Add(4, lblBI);
            Pass.Add(5, lblPre);
            Pass.Add(6, lblGlue);
            Pass.Add(7, lblPost);
            Pass.Add(8, lblLeak);
            Pass.Add(9, lblQC);
            Pass.Add(10, lblRecase);
            Pass.Add(11, lblServiceProg);
            Pass.Add(12, lblServicePCB);
            Pass.Add(13, lblServiceBI);
            Pass.Add(14, lblReceiving);
            Pass.Add(15, lblInitialInspection);

            Fail.Add(0, lblProgFail);
            Fail.Add(1, lblPCB1Fail);
            Fail.Add(2, lblActivationFail);
            Fail.Add(3, lblPCB2Fail);
            Fail.Add(4, lblBIFail);
            Fail.Add(5, lblPreFail);
            Fail.Add(6, lblGlueFail);
            Fail.Add(7, lblPostFail);
            Fail.Add(8, lblLeakFail);
            Fail.Add(9, lblQCFail);
            Fail.Add(10, lblRecaseFail);
            Fail.Add(11, lblServiceProgFail);
            Fail.Add(12, lblServicePCBFail);
            Fail.Add(13, lblServiceBIFail);
            Fail.Add(14, lblRecFail);
            Fail.Add(15, lblInitialInspectionFail);

            count.Add(1, txtPCB1);
            count.Add(2, txtActivation);
            count.Add(3, txtPCB2);
            count.Add(4, txtBI);
            count.Add(5, txtPre);
            count.Add(6, txtGlue);
            count.Add(7, txtPost);
            count.Add(8, txtLeak);
            count.Add(9, txtQC);
            count.Add(11, txtServiceProg);
            count.Add(12, txtServicePCB);
            count.Add(13, txtServiceBI);
            count.Add(15, txtInitialInspection);

            Rc.Add(0, lblRc0);
            Rc.Add(1, lblRc1);
            Rc.Add(2, lblRc2);
            Rc.Add(3, lblRc3);
            Rc.Add(4, lblRc4);
            Rc.Add(5, lblRc5);
            Rc.Add(6, lblRc6);
            Rc.Add(7, lblRc7);
            Rc.Add(8, lblRc8);
            Rc.Add(9, lblRc9);
            Rc.Add(10, lblRc10);
            Rc.Add(11, lblRc11);
            Rc.Add(12, lblRc12);
            Rc.Add(13, lblRc13);
            Rc.Add(14, lblRc14);
            Rc.Add(15, lblRc15);






        }
        private void Counts_Load(object sender, EventArgs e)
        {
            BtnToday_Click(sender, e);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void GetData()
        {
            stopwatch.Start();


            con.Open();


            SqlCommand cmd = new SqlCommand(sqlString, con);
            cmd.Parameters.AddWithValue("@TS", TS);
            cmd.Parameters.AddWithValue("@stat", stat);

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);


            con.Close();

            foreach (DataRow r in DS.Tables[16].Rows)
            {
                if (r[0].ToString().StartsWith("P"))
                {
                    lblWIP.Text = r[1].ToString();
                }
                else if (r[0].ToString().StartsWith("F"))
                {
                    lblFailures.Text = r[1].ToString();
                }
                else if (r[0].ToString().StartsWith("S"))
                {
                    lblScrap.Text = r[1].ToString();
                }
            }


            for (int i = 0; i <16; i++)
            {
                foreach (DataRow r in DS.Tables[i].Rows)
                {
                    if (r[0].ToString().StartsWith("P"))
                    {
                        Pass[i].Text = r[1].ToString();
                    }
                    else if (r[0].ToString().StartsWith("F"))
                    {
                        Fail[i].Text = r[1].ToString();
                    }
                }
                //Rc[i].Text = (Int32.Parse(Pass[i].Text) / Tn.Subtract(T0).TotalHours).ToString();
            }


            foreach (KeyValuePair<int, TextBox> kvp in count)
            {
                kvp.Value.Text = (Int32.Parse(Pass[kvp.Key - 1].Text.ToString()) - (Int32.Parse(Pass[kvp.Key].Text.ToString()) + Int32.Parse(Fail[kvp.Key].Text.ToString()))).ToString();
            }

            //Console.WriteLine(Tn.Subtract(T0).TotalHours);

            txtPre.Text = (Int32.Parse(txtPre.Text.ToString()) + Int32.Parse(lblServiceBI.Text.ToString())).ToString();
            txtPost.Text = (Int32.Parse(txtPost.Text.ToString()) + Int32.Parse(lblInitialInspection.Text.ToString())).ToString();


            stopwatch.Stop();
            lblTimeQuery.Text = stopwatch.Elapsed.ToString();
            timerGetData.Interval = 3*Int32.Parse(stopwatch.ElapsedMilliseconds.ToString());
            stopwatch.Reset();
            

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            GetData();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                timerGetData.Enabled = false;
                btnPause.Text = "Resume";
                btnPause.BackColor = System.Drawing.Color.FromArgb(0, 68, 139);
            }
            else
            {
                timerGetData.Enabled = true;
                btnPause.Text = "Pause";
                btnPause.BackColor = System.Drawing.Color.FromArgb(192, 64, 0);
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isFormBeingDragged = true;
                mouseDownX = e.X;
                mouseDownY = e.Y;
            }
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isFormBeingDragged)
            {
                Point temp = new Point();

                temp.X = this.Location.X + (e.X - mouseDownX);
                temp.Y = this.Location.Y + (e.Y - mouseDownY);
                this.Location = temp;
                temp = new Point();
            }
        }

       

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isFormBeingDragged = false;
            }
        }

        private void BtnToday_Click(object sender, EventArgs e)
        {
            //pnlSide.Width = btnToday.Width;
            pnlSide.Top = btnToday.Top;
            lblHeader.Text = "Today's Activity";
            TS = DateTime.Today.ToShortDateString().ToString();
            //sqlString;

        }

        private void BtnLast24_Click(object sender, EventArgs e)
        {
            //pnlSide.Height = btnLast24.Height;
            pnlSide.Top = btnLast24.Top;
            lblHeader.Text = "Activity in the last 24 hours";
            TS = DateTime.Now.AddDays(-1).ToString();
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            pnlTop.Left = btnAll.Left;
            stat = "r";
            for (int i = 0; i < 16; i++)
            {
                Pass[i].Text = Fail[i].Text = "0";
            }
            pnlService1.Visible = pnlService2.Visible = pnlNew.Visible = true;
            lblWIP.Text = lblFailures.Text = lblScrap.Text = "0";
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            pnlTop.Left = btnNew.Left;
            stat = "S";
            for (int i = 0; i < 16; i++)
            {
                Pass[i].Text = Fail[i].Text = "0";
            }
            pnlService1.Visible = pnlService2.Visible = false;
            pnlNew.Visible = true;
            lblWIP.Text = lblFailures.Text = lblScrap.Text = "0";
        }

        private void BtnService_Click(object sender, EventArgs e)
        {
            pnlTop.Left = btnService.Left;
            stat = "n";
            for (int i = 0; i < 16; i++)
            {
                Pass[i].Text = Fail[i].Text = "0";
            }
            pnlService1.Visible = pnlService2.Visible = true;
            pnlNew.Visible = false;
            lblWIP.Text = lblFailures.Text = lblScrap.Text = "0";
        }


    }
}
