using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Blue_Software
{
    public partial class SignUp : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True");
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text; 
            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty || txtEmail.Text == string.Empty || txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty)
            {
                MessageBox.Show("Username and password must be filled out!");
                txtFirstName.Focus();
            }
            else
            {
                cmd.CommandText = "insert into SignUp_Blue values('" + txtFirstName.Text + "','" + txtLastName.Text + "', '" + txtEmail.Text + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data added succesfully");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void cbx_password_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_password.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtPasswordCheck.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtPasswordCheck.PasswordChar = '*';
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            this.Show();
            txtFirstName.Focus();
            txtPassword.PasswordChar = '*';
            txtPasswordCheck.PasswordChar = '*';
        }
    }
}
