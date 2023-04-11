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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Blue_Software
{
    public partial class SignUp : Form
    {
        Login login = new Login();
        Form1 form1 = new Form1();
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
            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty || txtEmail.Text == string.Empty || txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty || txtPasswordCheck.Text == string.Empty)
            {
                MessageBox.Show("Username and password must be filled out!");
                txtFirstName.Focus();
            }
            else if (txtPassword.Text != txtPasswordCheck.Text)
            {
                MessageBox.Show("Passwords don't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPasswordCheck.Clear();
                txtPassword.Focus();
            }

            else
            {
                cmd.CommandText = "INSERT INTO SignUp_Blue (FirstName, LastName, Email, Username, Password, Credit, CreditGained) VALUES('" + txtFirstName.Text + "','" + txtLastName.Text + "', '" + txtEmail.Text + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "', 100, 0)";
                cmd.ExecuteNonQuery();
                InitialiseUser(txtUsername.Text);
                MessageBox.Show("Data added succesfully");
                form1.ShowDialog();
                this.Close();
            }
            con.Close();
        }

        public void InitialiseUser(string username)
        {
            AppData.CurrentUser = new User(username, User.GetCreditsForUser(username), User.GetCreditsGainedForUser(username));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.ShowDialog();
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
