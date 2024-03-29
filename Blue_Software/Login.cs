﻿
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Volo.Abp.Users;

namespace Blue_Software
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True");
        User currentUser;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '*';
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = txtUserName.Text;
            user_password = txtpassword.Text;
            
            try
            {
                String querry = "SELECT * FROM SignUp_Blue where Username = '" + txtUserName.Text + "' AND password = '" + txtpassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                
                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    username = txtUserName.Text;
                    user_password = txtpassword.Text;

                    InitialiseUser(username);

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtUserName.Clear();
                    txtpassword.Clear();

                    txtUserName.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }

        }

        public void InitialiseUser(string username)
        {
            AppData.CurrentUser = new User(username, User.GetCreditsForUser(username), User.GetCreditsGainedForUser(username));
        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new SignUp().ShowDialog();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}