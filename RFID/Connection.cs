using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RFID
{

    public class Connection
    {
        public SqlConnection nection;

        private string pipe;
        public void changeCon(string c)
        { nection = new SqlConnection("Server=" + c + ";Integrated Security=true;"); }
    }
}
