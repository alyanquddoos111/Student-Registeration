using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALAdmin
    {
       

        public static int Login(Admin admin)
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_login", con);
            cmd.Parameters.AddWithValue("@UserName", admin.username);
            cmd.Parameters.AddWithValue("@Pass", admin.password);
            cmd.CommandType = CommandType.StoredProcedure;
            int status = Convert.ToInt16(cmd.ExecuteScalar());
            return status;
        }
        public static int Signup(Admin admin)
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_allAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", admin.username);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                return 0;

            }
            else
            {
                dr.Close();
                cmd = new SqlCommand("sp_insertAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", admin.username);
                cmd.Parameters.AddWithValue("@pass", admin.password);
                cmd.ExecuteNonQuery();
                return 1;
            }
        }
    }
}
