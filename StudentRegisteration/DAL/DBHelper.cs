using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelper
    {
        public static SqlConnection openCon()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-NBN971T\SQLEXPRESS;Initial Catalog=StudentRegisteration;Integrated Security=True");
            return cn;
        }
    }
}
