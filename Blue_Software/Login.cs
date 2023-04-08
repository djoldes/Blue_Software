
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

                    int credits = GetCreditsForUser(username);
                    currentUser = new User { Username = username, Credit = credits };
                    AppData.CurrentUser = new User(username, credits);

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

        public int GetCreditsForUser(string username)
        {
            // Conectarea la baza de date
            string connString = @"Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // Interogarea bazei de date pentru a obține valoarea creditului pentru utilizatorul specificat
                string query = "SELECT Credit FROM SignUp_Blue WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                int credits = (int)cmd.ExecuteScalar();

                // Închiderea conexiunii la baza de date
                conn.Close();

                return credits;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new SignUp().Show();
            this.Hide();
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