using DAL;
using System;
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
    public partial class AllStudents : Form
    {
        public AllStudents()
        {
            InitializeComponent();
        }

        private void AllStudents_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DALStudent.allStudents();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm=new AddStudentForm();
            addStudentForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteStudent deleteStudent=new DeleteStudent();
            deleteStudent.Show();
            this.Hide();
        }
    }
}
