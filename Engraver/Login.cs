using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engraver
{
    public partial class Login : Form
    {
        public string UserName { get; private set; }
        private bool isFormBeingDragged = false;
        private int mouseDownX;
        private int mouseDownY;
        public static string connString = "Data Source=172.16.4.27;Initial Catalog=MfgTraveler;Persist Security Info=True;User ID=travelmfg;Password=Tr@vel@mfg";
        public SqlConnection sqlConn = new SqlConnection(connString);
        public string sqlString;
        public Login()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isFormBeingDragged = true;
                mouseDownX = e.X;
                mouseDownY = e.Y;
            }
        }

        private void Login_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtUsername.Text.Trim() != "" && txtPassword.Text.Trim() != "")
                btnLogin.Enabled = true;
            else
                btnLogin.Enabled = false;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool match = false;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select password from Users where UPPER(Username) = @User", con);
                cmd.Parameters.AddWithValue("@User", txtUsername.Text.ToUpper());
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (txtPassword.Text.Encrypt() == dr[0].ToString())
                            match = true;
                        else
                            System.Windows.Forms.MessageBox.Show("Incorrect username or password");
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No account with that username is registered");
                }
                con.Close();
                //authenticate = SqlCli.Login(txtUser.Text, txtPass.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected exception caught. Program may require a restart.\n\n" +
                    $"Exception Message: {ex.Message}", "Unhandled Exception");
            }

            if (match)
            {
                UserName = txtUsername.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                txtPassword.Clear();
                txtUsername.Focus();
                txtUsername.SelectAll();
            }
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
