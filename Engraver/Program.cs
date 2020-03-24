using System;
using System.Windows.Forms;

namespace Engraver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.SetCompatibleTextRenderingDefault(false);
            //Login frmLogin = new Login();
            //if (frmLogin.ShowDialog() == DialogResult.OK)
            //{
            //    // Application.Run(new QA(frmLogin.UserName));
            //    Application.Run(new Form1(frmLogin.UserName));



            //}
            Application.Run(new Form1("Hello World"));
        }
    }
}
