using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;


namespace HG2020_XMTR_Engraver
{
    public partial class Engraver : Form
    {
        public string Username { get; }
        public string SN,Type, Notes,BLK = "001", ip = "192.168.5.101", PRGM = "0009";
        private bool isFormBeingDragged = false, Ready = false;
        private int mouseDownX, mouseDownY, port = 50002;
        private SimpleTcpClient engraver = new SimpleTcpClient();
        public SqlConnection sqlConn = new SqlConnection(connString);

        public static string connString = "Data Source=172.16.4.27;Initial Catalog=MfgTraveler;Persist Security Info=True;User ID=travelmfg;Password=Tr@vel@mfg";
        public string sqlStringInsert = @"INSERT INTO[Operations]([Serial Number], Operation, Resolution, Reasons, Operator, DateTime, Product, Repair, Notes, Type)
                                VALUES(@sn, Engraver, Pass, None, @oper, @dt, LOC8, None, @Notes, @Type)";
        public string sqlStringNotes = @"If( SELECT TOP 1 Operation
                                From Operations
                                Where [Serial Number] = @SerialNumber
                                AND (Operation LIKE 'Initial%')) IS NOT NULL
                                begin 
	                                select 'Service' as [Type]
	                                end
                                Else
                                begin
	                                Select 'New' as [Type]
                                End";
        public string sqlStringType = @"Select d.Item, CONCAT(p.Prefix, d.SerialNumber) [SN]
                                From DeviceInfo d
                                Inner join Prefixes p
                                on d.prefID = p.ID
                                Where d.SerialNumber = @SN";



        private void Form1_Load(object sender, EventArgs e)
        {
            engraver.Connect(ip, port);
            engraver.StringEncoder = Encoding.ASCII;
            engraver.DataReceived += Engraver_DataReceived;

            numLOC8.Value = 1;

            //SetProgram(PRGM);
            bwGetSettings.RunWorkerAsync();
            bwReadyStateCheck.RunWorkerAsync();

            //Thread.Sleep(100);
            //timerGetSettings.Enabled = true;
            //Thread.Sleep(300);
            //timerReady.Enabled = true;
        }

        private void SetProgram(string program)
        {
            engraver.WriteLine($"GA,{program}\r");

            if (program == "0009")
            {

                lblXT2.Visible = false;
                lblXT3.Visible = false;
                lblXT4.Visible = false;
                lblXT5.Visible = false;
                lblXT6.Visible = false;

                txtXT2.Visible = false;
                txtXT3.Visible = false;
                txtXT4.Visible = false;
                txtXT5.Visible = false;
                txtXT6.Visible = false;

                lblCurrent2.Visible = false;
                lblCurrent3.Visible = false;
                lblCurrent4.Visible = false;
                lblCurrent5.Visible = false;
                lblCurrent6.Visible = false;

                txtXT1.Clear();
            }
            else if (program == "0010")
            {
                lblXT2.Visible = true;
                lblXT3.Visible = true;
                lblXT4.Visible = true;
                lblXT5.Visible = true;
                lblXT6.Visible = true;

                txtXT2.Visible = true;
                txtXT3.Visible = true;
                txtXT4.Visible = true;
                txtXT5.Visible = true;
                txtXT6.Visible = true;

                lblCurrent2.Visible = true;
                lblCurrent3.Visible = true;
                lblCurrent4.Visible = true;
                lblCurrent5.Visible = true;
                lblCurrent6.Visible = true;

                txtXT1.Clear();
                txtXT2.Clear();
                txtXT3.Clear();
                txtXT4.Clear();
                txtXT5.Clear();
                txtXT6.Clear();
            }
            else
            {
                numLOC8.Value = 1;
                return;
            }
        }

        private void ChangeSN(string PRGM, string BLK, string SN)
        {

            engraver.WriteLine($"C2,0{PRGM},{BLK},{SN}\r");

        }

        public void RequestString(string prog)
        {
            if (prog == "0010")
            {
                engraver.WriteLine($"B3,{prog},000,003,006,009,012,015\r");
            }
            else if (prog == "0009")
            {
                engraver.WriteLine($"B3,{prog},000\r");
            }

        }

        private void Engraver_DataReceived(object sender, SimpleTCP.Message e)
        {

            string response = e.MessageString;
            if (response.Substring(0, 2) == "B3")
            {
                //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent1").Text = response.Substring(5, 7);
                //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent2").Text = response.Substring(13, 7);
                //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent3").Text = response.Substring(21, 7);
                //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent4").Text = response.Substring(29, 7);
                lblCurrent1.Text = response.Substring(5, 9);
                lblCurrent2.Text = response.Substring(15, 9);
                lblCurrent3.Text = response.Substring(25, 9);
                lblCurrent4.Text = response.Substring(35, 9);
                lblCurrent5.Text = response.Substring(45, 9);
                lblCurrent6.Text = response.Substring(55, 9);

            }
            else if (response.Substring(0, 2) == "RE")
            {
                if (response.Substring(3, 1) == "0")
                {
                    if (response.Substring(5, 1) == "0")
                    {
                        lblReady.Text = "READY ON";
                        lblReady.ForeColor = Color.FromArgb(0, 255, 0);

                        btnStart.Enabled = true;

                        //client.WriteLine($"NT\r");
                        //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblReady").Text = "READY ON";
                        //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblReady").ForeColor = System.Drawing.Color.FromArgb(0, 255, 0);

                    }
                    else if (response.Substring(5, 1) == "1")
                    {
                        lblReady.Text = "READY OFF";
                        lblReady.ForeColor = Color.FromArgb(255, 0, 0);

                        btnStart.Enabled = false;


                        //var result = MessageBox.Show("An error has occurred or the controller is under control of terminal", "READY OFF");
                        //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblReady").Text = "READY OFF";
                        //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblReady").ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
                    }
                    else if (response.Substring(5, 1) == "2")
                    {
                        lblReady.Text = "READY OFF";
                        lblReady.ForeColor = Color.FromArgb(255, 0, 0);

                        btnStart.Enabled = false;

                        //var result = MessageBox.Show("Program expansion or marking is in progress", "READY OFF");
                        //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblReady").Text = "READY OFF";
                        //Application.OpenForms["Form1"].Controls.OfType<Label>().First(x => x.Name == "lblReady").ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);

                    }
                }
                else
                {
                    MessageBox.Show("An error has ocurred. Please Restart", "Error Status");
                    this.Close();
                }

            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            engraver.Disconnect();
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isFormBeingDragged = true;
                mouseDownX = e.X;
                mouseDownY = e.Y;
            }
        }

        private void PnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isFormBeingDragged = false;
            }
        }

        private void PnlHeader_MouseMove(object sender, MouseEventArgs e)
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

        private void NumLOC8_ValueChanged(object sender, EventArgs e)
        {
            //if (numLOC8.Value == 1)
            //{
            //    PRGM = "0009";

            //    lblXT2.Visible = false;
            //    lblXT3.Visible = false;
            //    lblXT4.Visible = false;
            //    lblXT5.Visible = false;
            //    lblXT6.Visible = false;

            //    txtXT2.Visible = false;
            //    txtXT3.Visible = false;
            //    txtXT4.Visible = false;
            //    txtXT5.Visible = false;
            //    txtXT6.Visible = false;

            //    lblCurrent2.Visible = false;
            //    lblCurrent3.Visible = false;
            //    lblCurrent4.Visible = false;
            //    lblCurrent5.Visible = false;
            //    lblCurrent6.Visible = false;

            //    txtXT1.Clear();
            //}
            //else if (numLOC8.Value == 6)
            //{
            //    PRGM = "0010";
            //    lblXT2.Visible = true;
            //    lblXT3.Visible = true;
            //    lblXT4.Visible = true;
            //    lblXT5.Visible = true;
            //    lblXT6.Visible = true;

            //    txtXT2.Visible = true;
            //    txtXT3.Visible = true;
            //    txtXT4.Visible = true;
            //    txtXT5.Visible = true;
            //    txtXT6.Visible = true;

            //    lblCurrent2.Visible = true;
            //    lblCurrent3.Visible = true;
            //    lblCurrent4.Visible = true;
            //    lblCurrent5.Visible = true;
            //    lblCurrent6.Visible = true;

            //    txtXT1.Clear();
            //    txtXT2.Clear();
            //    txtXT3.Clear();
            //    txtXT4.Clear();
            //    txtXT5.Clear();
            //    txtXT6.Clear();
            //}
            //else
            //{
            //    numLOC8.Value = 1;
            //    return;
            //}
            PRGM = numLOC8.Value == 1 ? "0009" : "0010";
            SetProgram(PRGM);

            //timerGetSettings.Enabled = false;
            //timerReady.Enabled = false;
            //timerGetSettings.Enabled = true;
            //Thread.Sleep(250);
            //timerReady.Enabled = true;
        }

        private void TxtXT1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (txtXT1.Text.Length == 9 && txtXT1.Text.Substring(0, 2) == "HG" && txtXT1.Text.Substring(2, 7).All(char.IsDigit))
                {
                    BLK = "000";
                    SN = txtXT1.Text;
                    ChangeSN(PRGM, BLK, SN);
                }
                else
                {
                    MessageBox.Show($"Invalid Serial Number for {lblXT1.Text} {txtXT1.Text}");
                }
                Enabled = true;
                txtXT2.Focus();
                txtXT2.SelectAll();
            }
        }


        private void TxtXT2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (txtXT2.Text.Length == 9 && txtXT2.Text.Substring(0, 2) == "HG" && txtXT2.Text.Substring(2, 7).All(char.IsDigit))
                {
                    BLK = "003";
                    SN = txtXT2.Text;
                    ChangeSN(PRGM, BLK, SN);
                }
                else
                {

                    MessageBox.Show($"Invalid Serial Number for {lblXT2.Text} {txtXT2.Text}");

                }

                Enabled = true;
                txtXT3.Focus();
                txtXT3.SelectAll();
            }
        }



        private void TxtXT3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (txtXT3.Text.Length == 9 && txtXT3.Text.Substring(0,2) == "HG" && txtXT3.Text.Substring(2,7).All(char.IsDigit))
                {
                    BLK = "006";
                    SN = txtXT3.Text;
                    ChangeSN(PRGM, BLK, SN);
                }
                else
                {
                    MessageBox.Show($"Invalid Serial Number for {lblXT3.Text} {txtXT3.Text}");
                }
                Enabled = true;
                txtXT4.Focus();
                txtXT4.SelectAll();
            }
        }

        private void TxtXT4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (txtXT4.Text.Length == 9 && txtXT4.Text.Substring(0, 2) == "HG" && txtXT4.Text.Substring(2, 7).All(char.IsDigit))
                {
                    BLK = "009";
                    SN = txtXT4.Text;
                    ChangeSN(PRGM, BLK, SN);
                }
                else
                {
                    MessageBox.Show($"Invalid Serial Number for {lblXT4.Text} {txtXT4.Text}");
                }
                Enabled = true;
                txtXT5.Focus();
                txtXT5.SelectAll();
            }
        }

        private void txtXT5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (txtXT5.Text.Length == 9 && txtXT5.Text.Substring(0, 2) == "HG" && txtXT5.Text.Substring(2, 7).All(char.IsDigit))
                {
                    BLK = "012";
                    SN = txtXT5.Text;
                    ChangeSN(PRGM, BLK, SN);
                }
                else
                {
                    MessageBox.Show($"Invalid Serial Number for {lblXT5.Text} {txtXT5.Text}");
                }
                Enabled = true;
                txtXT6.Focus();
                txtXT6.SelectAll();
            }
        }

        private void txtXT6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (txtXT6.Text.Length == 9 && txtXT6.Text.Substring(0, 2) == "HG" && txtXT6.Text.Substring(2, 7).All(char.IsDigit))
                {
                    BLK = "015";
                    SN = txtXT6.Text;
                    ChangeSN(PRGM, BLK, SN);
                }
                else
                {
                    MessageBox.Show($"Invalid Serial Number for {lblXT6.Text} {txtXT6.Text}");
                }
                Enabled = true;

            }
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            //RequestString(PRGM);
            //if (lblReady.Text == "READY ON")
            //{
            //    btnStart.Enabled = true;
            //}
            //else
            //{
            //    btnStart.Enabled = false;
            //}
        }

        public void ReadyStateCheck()
        {
            engraver.WriteLine($"RE\r");
        }

        public void MarkingStart()
        {
            engraver.WriteLine($"NT\r");
        }

        private void bwReadyStateCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadyStateCheck();
            Thread.Sleep(500);

        }

        private void bwReadyStateCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bwReadyStateCheck.RunWorkerAsync();
        }

        private void bwGetSettings_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestString(PRGM);
            Thread.Sleep(500);

        }

        private void bwGetSettings_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bwGetSettings.RunWorkerAsync();
        }

        private void TimerReady_Tick(object sender, EventArgs e)
        {
            //ReadyStateCheck();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            SetProgram(PRGM);
            MarkingStart();

            //insertintooperations(txtXT1.Text);
            //if (PRGM == "4")
            //{
            //    insertintooperations(txtXT2.Text);
            //    insertintooperations(txtXT3.Text);
            //    insertintooperations(txtXT4.Text);
            //}


            //Reset timers
            //timerGetSettings.Enabled = false;
            //timerReady.Enabled = false;
            //timerGetSettings.Enabled = true;
           // Thread.Sleep(250);
            //timerReady.Enabled = true;

        }



        private void TxtXT1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Resettimer_Tick(object sender, EventArgs e)
        {
            //timerGetSettings.Enabled = false;
            //timerReady.Enabled = false;
            //timerGetSettings.Enabled = true;
            //Thread.Sleep(250);
            //timerReady.Enabled = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        public Engraver(string userName)
        {   
            Username = userName;
            InitializeComponent();
            this.Show();

        }

        public void insertintooperations(string sn)
        {

            SqlCommand sqlCommType = new SqlCommand(sqlStringType, sqlConn);
            SqlCommand sqlCommNotes = new SqlCommand(sqlStringNotes, sqlConn);
            SqlCommand sqlCommInsert = new SqlCommand(sqlStringInsert, sqlConn);

            //Obtain the build of the unit
            sqlCommType.Parameters.AddWithValue("@SN", sn);
            sqlConn.Open();
            SqlDataReader dr = sqlCommType.ExecuteReader();
            while (dr.Read())
            {
                Type = dr.GetString(0);
            }

            //Obtain New/Service
            sqlCommNotes.Parameters.AddWithValue("@SerialNumber", sn);
            Notes = sqlCommNotes.ExecuteScalar().ToString();




            //Insert into Opertations
            sqlCommInsert.Parameters.AddWithValue("@sn", sn);
            sqlCommInsert.Parameters.AddWithValue("@oper", Username);
            sqlCommInsert.Parameters.AddWithValue("@dt", DateTime.Now.ToString());
            sqlCommInsert.Parameters.AddWithValue("@Notes", Type);
            sqlCommInsert.Parameters.AddWithValue("@Type", Notes);
            sqlCommInsert.ExecuteNonQuery();


            sqlConn.Close();
        }





    }
}
