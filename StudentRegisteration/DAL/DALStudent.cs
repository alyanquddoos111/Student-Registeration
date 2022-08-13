using System;
using Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALStudent
    {
        public static void insertStudent(EntStudent st)
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_insertStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RegID", st.RegisterationID);
            cmd.Parameters.AddWithValue("firstname", st.FirstName);
            cmd.Parameters.AddWithValue("@lastname", st.LastName);
            cmd.Parameters.AddWithValue("@mothername", st.MotherName);
            cmd.Parameters.AddWithValue("@fathername", st.FatherName);
            cmd.Parameters.AddWithValue("@gender", st.Gender);
            cmd.Parameters.AddWithValue("@currentaddress", st.CurrentAddress);
            cmd.Parameters.AddWithValue("@permanentaddress", st.PermanentAddress);
            cmd.Parameters.AddWithValue("@dob", st.DOB);
            cmd.Parameters.AddWithValue("fCNIC", st.FatherCNIC);
            cmd.Parameters.AddWithValue("@fatherphone", st.FatherPhoneNumber);
            cmd.Parameters.AddWithValue("@mCNIC", st.MotherCNIC);
            cmd.Parameters.AddWithValue("@motherphone", st.MotherPhoneNumber);
            cmd.Parameters.AddWithValue("age", st.Age);
            cmd.Parameters.AddWithValue("@siblings", st.Siblings);
            cmd.ExecuteNonQuery();
            
        }

        public static DataTable subjectDetails()
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_allDegrees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static DataTable allSubjects(Degree degree)
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_getSubjects", con);
            cmd.Parameters.AddWithValue("GroupID", degree.GroupID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public static int getFees(Degree degree)
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("getFees", con);
            cmd.Parameters.AddWithValue("GroupID", degree.GroupID);
            cmd.CommandType = CommandType.StoredProcedure;
            int fees = Convert.ToInt32(cmd.ExecuteScalar());
            return fees;
        }

        public static int getDuration(Degree degree)
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("getDuration", con);
            cmd.Parameters.AddWithValue("GroupID", degree.GroupID);
            cmd.CommandType = CommandType.StoredProcedure;
            int duration = Convert.ToInt32(cmd.ExecuteScalar());
            return duration;

        }

        public static void insertDegree(EntStudent student,Degree degree)
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("insertGroup", con);
            cmd.Parameters.AddWithValue("@regid", student.RegisterationID);
            cmd.Parameters.AddWithValue("@groupid", degree.GroupID);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }

        public static DataTable allStudents()
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_allStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public static void deleteStudent(EntStudent student)
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_deleteStudent", con);
            cmd.Parameters.AddWithValue("@regid", student.RegisterationID);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

        }

        public static EntStudent searchStudent(EntStudent student)
        {
            EntStudent student1 = new EntStudent();
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_searchStudent", con);
            cmd.Parameters.AddWithValue("@regid", student.RegisterationID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                student1.RegisterationID = Convert.ToInt32(dr["RegID"]);
                student1.FirstName = dr["FirstName"].ToString();
                student1.LastName = dr["LastName"].ToString();
                student1.MotherName = dr["MotherName"].ToString();
                student1.FatherName = dr["FatherName"].ToString();
                student1.Gender = dr["Gender"].ToString();
                student1.CurrentAddress = dr["CurrentAddress"].ToString();
                student1.PermanentAddress = dr["PermanentAddress"].ToString();
                student1.FirstName = dr["FirstName"].ToString();
                student1.DOB = Convert.ToDateTime(dr["DOB"]);
                student1.FatherCNIC = Convert.ToInt32(dr["FatherCNIC"]);
                student1.FatherPhoneNumber = dr["FatherNumber"].ToString();
                student1.MotherCNIC = Convert.ToInt32(dr["MotherCNIC"]);
                student1.MotherPhoneNumber = dr["MotherPhoneNumber"].ToString();
                student1.Age = Convert.ToInt32(dr["Age"]);
                student1.Siblings = Convert.ToInt32(dr["Siblings"]);
            }
            else
            {
                student1 = null;
            }
            return student1;
        }

        public static void updateStudent(EntStudent st)
        {
            SqlConnection con = DBHelper.openCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_updateStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RegID", st.RegisterationID);
            cmd.Parameters.AddWithValue("firstname", st.FirstName);
            cmd.Parameters.AddWithValue("@lastname", st.LastName);
            cmd.Parameters.AddWithValue("@mothername", st.MotherName);
            cmd.Parameters.AddWithValue("@fathername", st.FatherName);
            cmd.Parameters.AddWithValue("@gender", st.Gender);
            cmd.Parameters.AddWithValue("@currentaddress", st.CurrentAddress);
            cmd.Parameters.AddWithValue("@permanentaddress", st.PermanentAddress);
            cmd.Parameters.AddWithValue("@dob", st.DOB);
            cmd.Parameters.AddWithValue("fCNIC", st.FatherCNIC);
            cmd.Parameters.AddWithValue("@fatherphone", st.FatherPhoneNumber);
            cmd.Parameters.AddWithValue("@mCNIC", st.MotherCNIC);
            cmd.Parameters.AddWithValue("@motherphone", st.MotherPhoneNumber);
            cmd.Parameters.AddWithValue("age", st.Age);
            cmd.Parameters.AddWithValue("@siblings", st.Siblings);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }

    }

}
