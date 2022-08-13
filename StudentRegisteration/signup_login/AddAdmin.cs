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
    public partial class AddAdmin : Form
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        private void AddAdmin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.username = textBox1.Text;
            admin.password = textBox2.Text;

            if (admin.username != string.Empty && admin.password != string.Empty && textBox3.Text != string.Empty)
            {
                if (textBox3.Text == admin.password)
                {
                    try
                    {
                        int check = DALAdmin.Signup(admin);
                        if (check == 1)
                        {
                            MessageBox.Show("Admin Added Successfully.");
                            HomePage homePage = new HomePage();
                            homePage.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Failed To Add Admin.");
                            textBox2.Text="";
                            textBox1.Text = "";
                            textBox3.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();
        }
    }
}
