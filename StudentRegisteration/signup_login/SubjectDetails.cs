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
    public partial class SubjectDetails : Form
    {
        EntStudent student1 = new EntStudent();   
        public SubjectDetails(EntStudent student)
        {
            InitializeComponent();
            populateDegree();
            student1=student;
            
        }
        
        Degree degree=new Degree();

        public EntStudent Student { get; }

        private void SubjectDetails_Load(object sender, EventArgs e)
        {
            textBox3.Text = student1.RegisterationID.ToString();
            comboBox2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;

        }

        private void populateDegree()
        {
            DataTable dt=DALStudent.subjectDetails();
            comboBox1.DisplayMember = "GroupName";
            comboBox1.ValueMember = "GroupID";
            comboBox1.DataSource = dt;
            degree.GroupID =Convert.ToInt32(comboBox1.SelectedValue);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue.ToString()!=null)
            {
                degree.GroupID = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                populateSubjects();
                comboBox2.Enabled = true;
                
                textBox1.Text = DALStudent.getFees(degree).ToString();
               
                textBox2.Text = DALStudent.getDuration(degree).ToString();
            }
           

        }
        private void populateSubjects()
        {
            DataTable dt = DALStudent.allSubjects(degree);
            comboBox2.DisplayMember = "SubjectsList";
            comboBox2.ValueMember = "SubjectsID";
            comboBox2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DALStudent.insertDegree(student1, degree);
                MessageBox.Show("Student Registered Successfully.");
                HomePage homePage = new HomePage();
                homePage.Show();
                this.Hide();
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
        }

        
    }
}
