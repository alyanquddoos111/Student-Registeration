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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            passBox.PasswordChar = '*';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Admin admin= new Admin();
            admin.username = userBox.Text;
            admin.password = passBox.Text;
            try
            {
                int check = DALAdmin.Login(admin);
                if (check == 1)
                {
                    HomePage hmp = new HomePage();
                    hmp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Admin Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
