using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID
{
    public partial class frmAliasPane : Form
    {
        public string Alias { get; set; }

        public frmAliasPane()
        {
            InitializeComponent();
        }

        private void frmAliasPane_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Alias = textBox1.Text;
            Close();
        }

        private void frmAliasPane_FormClosing(object sender, FormClosingEventArgs e)
        {
            Alias = "";
        }
    }
}
