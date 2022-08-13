using DAL;
using Entity;
using System;
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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudentForm f = new AddStudentForm();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteStudent deleteStudent= new DeleteStudent();
            deleteStudent.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateStudent updateStudent = new UpdateStudent();
            updateStudent.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllStudents allStudents=new AllStudents();
            allStudents.Show();
            this.Hide();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminForm adminForm=new AdminForm();
            adminForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddAdmin addAdmin=new AddAdmin();
            addAdmin.Show();
            this.Hide();
        }
    }
}
