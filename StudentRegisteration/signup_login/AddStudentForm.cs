using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace Student
{
    public partial class AddStudentForm : Form
    {
       
        public AddStudentForm()
        {
            InitializeComponent();
            
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void regButton_Click(object sender, EventArgs e)
        {
            if (IDbox.Text != null || FNameBox.Text != null || LNameBox.Text != null || ageBox.Text != null || DOBpicker.Text != null || CAddressBox.Text != null || PAddressBox.Text != null || (!MButton.Checked && !FButton.Checked) || siblingsBox.Text != null || FatherBox.Text != null || FCNICBox.Text != null || FPhoneBox.Text != null || MotherBox.Text != null || MCNICBox.Text != null || MPhoneBox.Text != null)
            {
                EntStudent student = new EntStudent();
                student.RegisterationID = Convert.ToInt32(IDbox.Text);
                student.FirstName = FNameBox.Text;
                student.LastName = LNameBox.Text;
                student.Age = Convert.ToInt32(ageBox.Text);
                student.DOB = Convert.ToDateTime(DOBpicker.Text);
                student.CurrentAddress = CAddressBox.Text;
                student.PermanentAddress = PAddressBox.Text;
                if (MButton.Checked)
                {
                    student.Gender = MButton.Text;

                }
                else if (FButton.Checked)
                {
                    student.Gender = FButton.Text;
                }
                student.FatherName = FatherBox.Text;
                student.FatherCNIC = Convert.ToInt32(FCNICBox.Text);
                student.FatherPhoneNumber = FPhoneBox.Text;
                student.MotherName = MotherBox.Text;
                student.MotherCNIC = Convert.ToInt32(MCNICBox.Text);
                student.MotherPhoneNumber = MPhoneBox.Text;

                student.Siblings = Convert.ToInt32(siblingsBox.Text);
                try
                {
                    DALStudent.insertStudent(student);
                    MessageBox.Show("Data Entered Successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SubjectDetails subjectDetails = new SubjectDetails(student);
                subjectDetails.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Fill All The Data.");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
