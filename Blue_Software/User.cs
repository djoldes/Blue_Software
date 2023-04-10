using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Software
{
    public class User
    {
        public string Username { get; set; }
        public int Credit { get; set; }
        public int CreditGained { get; set; }

        public static User CurrentUser { get; set; } = new User();

        public User()
        {
        }
        public User(string username, int credit, int creditGained)
        {
            Username = username;
            Credit = credit;
            CreditGained = creditGained;
        }

        public static void UpdateCredit(int newCredit, int creditGained)
        {
            string connectionString = "Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE SignUp_Blue SET Credit = @Credit, CreditGained = @CreditGained WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Credit", newCredit);
                command.Parameters.AddWithValue("@CreditGained", creditGained);
                command.Parameters.AddWithValue("@Username", AppData.CurrentUser.Username);
                command.ExecuteNonQuery();

                AppData.CurrentUser.Credit = newCredit;
                AppData.CurrentUser.CreditGained = creditGained;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static int GetCreditsGainedForUser(string username)
        {
            string connString = @"Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT CreditGained FROM SignUp_Blue WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                int credits = (int)cmd.ExecuteScalar();

                conn.Close();

                return credits;
            }
        }
        public static int GetCreditsForUser(string username)
        {
            string connString = @"Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT Credit FROM SignUp_Blue WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                int credits = (int)cmd.ExecuteScalar();

                conn.Close();

                return credits;
            }
        }
    }
}
