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


namespace CellularData
{
    public partial class Form1 : Form
    {
        public DataTable dtUnits = new DataTable();
        public static string bldrsql = "Data Source=172.16.4.27;Initial Catalog=MfgTraveler;Persist Security Info=True;User ID=travelmfg;Password=Tr@vel@mfg";
        public static string syte = "Data Source=bldrsyte8db01;Initial Catalog=EM_App;Persist Security Info=True;User ID=travelmfg;Password=Tr@vel@mfg";
        public string SN, MDN, MEID, SIMID;
        SqlConnection bldrcon, sytecon;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //sytecon = new SqlConnection(syte);
            //SqlCommand cmdsyteData = new SqlCommand($@" Select
            //                                             ser_num [SN],
            //                                                uf_unit_MDN [MDN],
            //                                             charfld3 [MEID],
            //                                             uf_unit_SIM [SIM]
            //                                            From 
            //                                             fs_unit'", sytecon);



            foreach (DataRow dr in dtUnits.Rows)
            {
                SN = dr[0].ToString();
                lblSN.Text = SN;
                SqlConnection sytecon = new SqlConnection(syte);
                SqlCommand cmdSyteData = new SqlCommand($@"   Select
	                                                            ser_num,
                                                                uf_unit_MDN,
	                                                            charfld3,
	                                                            uf_unit_SIM
                                                            From 
	                                                            fs_unit 
                                                            Where 
	                                                            ser_num like '%{SN}'", sytecon);



                sytecon.Open();

                SqlDataAdapter DA = new SqlDataAdapter(cmdSyteData);
                var DT = new DataTable();
                DA.Fill(DT);

                sytecon.Close();

                if (DT.Rows.Count > 0)
                {
                    MEID = DT.Rows[0][2].ToString();
                    MDN = DT.Rows[0][1].ToString();
                    SIMID = DT.Rows[0][3].ToString();

                    lblMDN.Text = MDN;
                    lblMEID.Text = MEID;
                    lblSIM.Text = SIMID;

                    SqlConnection bldrcon = new SqlConnection(bldrsql);
                    SqlCommand cmdSetMEID = new SqlCommand(@"    Update 
                                                                DeviceInfo
                                                            SET 
                                                                MEID = @MEID,
                                                                MDN = @MDN,
                                                                SIM = @SIM
                                                            Where 
                                                                SerialNumber = @SN", bldrcon);
                    cmdSetMEID.Parameters.AddWithValue("@MEID", MEID);
                    cmdSetMEID.Parameters.AddWithValue("@SN", SN);
                    cmdSetMEID.Parameters.AddWithValue("@MDN", MDN);
                    cmdSetMEID.Parameters.AddWithValue("@SIM", SIMID);

                    bldrcon.Open();
                    cmdSetMEID.ExecuteNonQuery();
                    bldrcon.Close();
                }
                lblCount.Text = (Convert.ToInt32(lblCount.Text) - 1).ToString();
                Application.DoEvents();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bldrcon = new SqlConnection(bldrsql);
            SqlCommand cmdUnits = new SqlCommand(@"  Select 
                                                            Distinct SerialNumber
                                                        From
                                                            DeviceInfo
                                                        Where
                                                            (MEID IS NULL or MDN IS NULL or SIM IS NULL) and
                                                            SerialNumber > '7776420'", bldrcon);

            bldrcon.Open();
                SqlDataAdapter DA = new SqlDataAdapter(cmdUnits);
                DA.Fill(dtUnits);
            bldrcon.Close();

            lblCount.Text = dtUnits.Rows.Count.ToString();
            
        }
    }
}
