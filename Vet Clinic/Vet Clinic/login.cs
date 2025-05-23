using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vet_Clinic
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "admin" && password.Text == "123")
            {
                this.Hide(); // اخفي اللوجين
                Dashboard dashboardForm = new Dashboard();
                dashboardForm.ShowDialog(); // اعرض الداشبورد كـ Dialog
                this.Close(); // لما تتقفل الداشبورد، قفل اللوجين
            }
            else
            {
                MessageBox.Show("The username or password you entered is incorrect, try again.");
                username.Clear();
                password.Clear();
                username.Focus();
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
