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
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void PAddressBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            FNameBox.Enabled = false;
            LNameBox.Enabled=false;
            ageBox.Enabled=false;
            DOBbox.Enabled=false;
            CAddressBox.Enabled=false;
            PAddressBox.Enabled=false;
            FatherBox.Enabled=false;
            FCNICBox.Enabled=false;
            FPhoneBox.Enabled=false;
            MotherBox.Enabled=false;
            MCNICBox.Enabled=false;
            MPhoneBox.Enabled = false;
            genderBox.Enabled=false;
            siblingsBox.Enabled=false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntStudent student = new EntStudent();
            student.RegisterationID = Convert.ToInt32(IDbox.Text);
            FNameBox.Enabled = true;
            LNameBox.Enabled = true;
            ageBox.Enabled = true;
            DOBbox.Enabled = true;
            CAddressBox.Enabled = true;
            PAddressBox.Enabled = true;
            FatherBox.Enabled = true;
            FCNICBox.Enabled = true;
            FPhoneBox.Enabled = true;
            MotherBox.Enabled = true;
            MCNICBox.Enabled = true;
            MPhoneBox.Enabled = true;
            siblingsBox.Enabled = true;
            try
            {
                EntStudent student1= DALStudent.searchStudent(student);
                FNameBox.Text = student1.FirstName;
                LNameBox.Text = student1.LastName;
                ageBox.Text = student1.Age.ToString();
                DOBbox.Text = student1.DOB.ToString();
                CAddressBox.Text = student1.CurrentAddress;
                PAddressBox.Text = student1.PermanentAddress;
                FatherBox.Text = student1.FatherName;
                genderBox.Text = student1.Gender;
                FCNICBox.Text = student1.FatherCNIC.ToString();
                FPhoneBox.Text = student1.FatherPhoneNumber;
                MotherBox.Text = student1.MotherName;
                MCNICBox.Text = student1.MotherCNIC.ToString();
                MPhoneBox.Text = student1.MotherPhoneNumber;
                siblingsBox.Text = student1.Age.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage homePage= new HomePage();
            homePage.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EntStudent student = new EntStudent();
            student.RegisterationID = Convert.ToInt32(IDbox.Text);
            student.FirstName = FNameBox.Text;
            student.LastName = LNameBox.Text;
            student.Age = Convert.ToInt32(ageBox.Text);
            student.DOB = Convert.ToDateTime(DOBbox.Text);
            student.CurrentAddress = CAddressBox.Text;
            student.PermanentAddress = PAddressBox.Text;
            student.Gender = genderBox.Text;
            student.FatherName = FatherBox.Text;
            student.FatherCNIC = Convert.ToInt32(FCNICBox.Text);
            student.FatherPhoneNumber = FPhoneBox.Text;
            student.MotherName = MotherBox.Text;
            student.MotherCNIC = Convert.ToInt32(MCNICBox.Text);
            student.MotherPhoneNumber = MPhoneBox.Text;
            student.Age = Convert.ToInt32(ageBox.Text);
            student.Siblings = Convert.ToInt32(siblingsBox.Text);
            try
            {
                DALStudent.updateStudent(student);
                MessageBox.Show("Data Updated Successfully.");

                UpdateStudent updateStudent=new UpdateStudent();
                updateStudent.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
