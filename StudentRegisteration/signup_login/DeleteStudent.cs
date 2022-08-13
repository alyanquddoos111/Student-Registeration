using System;
using DAL;
using Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class DeleteStudent : Form
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void DeleteStudent_Load(object sender, EventArgs e)
        {

        }

        private void dltButton_Click(object sender, EventArgs e)
        {
            EntStudent student = new EntStudent();
            student.RegisterationID = Convert.ToInt32(idBox.Text);
            try
            {
                DALStudent.deleteStudent(student);
                MessageBox.Show("Deleted Successfully.");
                idBox.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage= new HomePage();
            homePage.Show();
            this.Hide();
        }
    }
}
