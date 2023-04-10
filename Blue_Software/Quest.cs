using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Blue_Software
{
    public partial class Quest : Form
    {
        public Quest(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            int credit = AppData.CurrentUser.Credit;
            string answer = textAnswer.Text;
            string connectionString = @"Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand creditGainedCommand = new SqlCommand("SELECT CreditGained FROM SignUp_Blue WHERE Username = @id", connection);
                    creditGainedCommand.Parameters.AddWithValue("@id", AppData.CurrentUser.Username);
                    int creditGained = (int)creditGainedCommand.ExecuteScalar();

                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Texte WHERE Answer = @answer", connection);
                    checkCommand.Parameters.AddWithValue("@answer", answer);
                    int answerCount = (int)checkCommand.ExecuteScalar();

                    if (answerCount > 0)
                    {
                        SqlCommand updateCommand = new SqlCommand("UPDATE Texte SET AnswersNumber = AnswersNumber + 1 WHERE Answer = @answer", connection);
                        updateCommand.Parameters.AddWithValue("@answer", answer);
                        updateCommand.ExecuteNonQuery();

                        SqlCommand creditCommand = new SqlCommand("SELECT AnswersNumber FROM Texte WHERE Answer = @answer", connection);
                        creditCommand.Parameters.AddWithValue("@answer", answer);
                        int answerNumber = (int)creditCommand.ExecuteScalar();

                        if (answerNumber == 1)
                        {
                            User.UpdateCredit(credit += 30, creditGained += 30);
                            MessageBox.Show("The answer is correct!" +
                                "You won 30 credits!");
                        }
                        else if (answerNumber == 2)
                        {
                            User.UpdateCredit(credit += 20, creditGained += 20);
                            MessageBox.Show("The answer is correct!" +
                                "You won 20 credits!");
                        }
                        else if (answerNumber == 3)
                        {
                            User.UpdateCredit(credit += 10, creditGained += 10);
                            MessageBox.Show("The answer is correct!" +
                                "You won 10 credits!");
                        }
                        else if(answerNumber > 3)
                        {
                            MessageBox.Show("The answer is correct!" +
                                "Your answer is number:" + answerNumber +
                                "You did not win any credits!:(");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The answer is wrong!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
