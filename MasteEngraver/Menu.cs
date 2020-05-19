using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasteEngraver
{
    public partial class Menu : Form
    {
        public bool isFormBeingDragged { get; private set; }
        public int mouseDownX { get; private set; }
        public int mouseDownY { get; private set; }
        public Form frmHG2020, frmTAD;

        public Menu()
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

        private void btnTAD_Click(object sender, EventArgs e)
        {
            if(frmTAD is null)
            {
                frmTAD = new Engraver.TAD.ADM.HOME();
                frmTAD.Show();
                return;
            }

            frmTAD.BringToFront();

        }

        private void btnHG2020_Click(object sender, EventArgs e)
        {
            if(frmHG2020 is null)
            {
                frmHG2020 = new HG2020_XMTR_Engraver.Engraver("Hello World");
                frmHG2020.Show();
                return;
            }

            frmHG2020.BringToFront();
            
        }
    }
}
