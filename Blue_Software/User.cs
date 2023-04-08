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

        public static User CurrentUser { get; set; } = new User();

        public User()
        {
        }
        public User(string username, int credit)
        {
            Username = username;
            Credit = credit;
        }

        public void UpdateCredit(int newCredit)
        {
            string connectionString = "Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            // Actualizarea valorii creditului utilizatorului în baza de date
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE SignUp_Blue SET Credit = @Credit WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Credit", newCredit);
                command.Parameters.AddWithValue("@Username", "aaa");
                command.ExecuteNonQuery();

                // Actualizarea valorii creditului utilizatorului în obiectul CurrentUser
                CurrentUser.Credit = newCredit;
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
    }
}
