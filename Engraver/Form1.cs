using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engraver
{
    public partial class Form1 : Form
    {
        public string Username { get; }
        public string Type, Notes;
        public string BLK = "001", SN;
        private bool isFormBeingDragged = false;
        private int mouseDownX;
        private int mouseDownY;
        private Engraver engraver = new Engraver();
        public string PRGM = "0";
        public static string connString = "Data Source=172.16.4.27;Initial Catalog=MfgTraveler;Persist Security Info=True;User ID=travelmfg;Password=Tr@vel@mfg";
        public SqlConnection sqlConn = new SqlConnection(connString);
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
           


            engraver.SetProgram(PRGM);
            Thread.Sleep(100);
            timerGetSettings.Enabled = true;
            Thread.Sleep(300);
            timerReady.Enabled = true;
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
            if (numLOC8.Value == 1)
            {
                PRGM = "1";
                lblXT2.Visible = false;
                lblXT3.Visible = false;
                lblXT4.Visible = false;
                txtXT2.Visible = false;
                txtXT3.Visible = false;
                txtXT4.Visible = false;
                lblCurrent2.Visible = false;
                lblCurrent3.Visible = false;
                lblCurrent4.Visible = false;
                txtXT1.Clear();
            }
            else if (numLOC8.Value == 4)
            {
                PRGM = "0";
                lblXT2.Visible = true;
                lblXT3.Visible = true;
                lblXT4.Visible = true;
                txtXT2.Visible = true;
                txtXT3.Visible = true;
                txtXT4.Visible = true;
                lblCurrent2.Visible = true;
                lblCurrent3.Visible = true;
                lblCurrent4.Visible = true;
                txtXT1.Clear();
                txtXT2.Clear();
                txtXT3.Clear();
                txtXT4.Clear();
            }
            else
            {
                numLOC8.Value = 1;
                return;
            }
            engraver.SetProgram(PRGM);

            timerGetSettings.Enabled = false;
            timerReady.Enabled = false;
            timerGetSettings.Enabled = true;
            Thread.Sleep(250);
            timerReady.Enabled = true;
        }

        private void TxtXT1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (txtXT1.Text.Length == 7 && txtXT1.Text.All(char.IsDigit))
                {
                    BLK = "001";
                    SN = txtXT1.Text;
                    engraver.ChangeSN(PRGM,BLK, SN);
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
                if (txtXT2.Text.Length == 7 && txtXT2.Text.All(char.IsDigit))
                {
                    BLK = "002";
                    SN = txtXT2.Text;
                    engraver.ChangeSN(PRGM,BLK, SN);
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
                if (txtXT3.Text.Length == 7 && txtXT3.Text.All(char.IsDigit))
                {
                    BLK = "003";
                    SN = txtXT3.Text;
                    engraver.ChangeSN(PRGM,BLK, SN);
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
                if (txtXT4.Text.Length == 7 && txtXT4.Text.All(char.IsDigit))
                {
                    BLK = "004";
                    SN = txtXT4.Text;
                    engraver.ChangeSN(PRGM,BLK, SN);
                }
                else
                {
                    MessageBox.Show($"Invalid Serial Number for {lblXT4.Text} {txtXT4.Text}");
                }
                Enabled = true;
            }
        }

        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            engraver.RequestString(PRGM);
            if (lblReady.Text == "READY ON")
            {
                btnStart.Enabled = true;
            }
            else
            {
                btnStart.Enabled = false;
            }
        }

        private void TimerReady_Tick(object sender, EventArgs e)
        {
            engraver.ReadyStateCheck();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            engraver.MarkingStart();

            //insertintooperations(txtXT1.Text);
            //if (PRGM == "4")
            //{
            //    insertintooperations(txtXT2.Text);
            //    insertintooperations(txtXT3.Text);
            //    insertintooperations(txtXT4.Text);
            //}
            

            //Reset timers
            timerGetSettings.Enabled = false;
            timerReady.Enabled = false;
            timerGetSettings.Enabled = true;
            Thread.Sleep(250);
            timerReady.Enabled = true;

        }

        

        private void TxtXT1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Resettimer_Tick(object sender, EventArgs e)
        {
            timerGetSettings.Enabled = false;
            timerReady.Enabled = false;
            timerGetSettings.Enabled = true;
            Thread.Sleep(250);
            timerReady.Enabled = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        public Form1(string userName)
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
