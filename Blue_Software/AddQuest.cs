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
using Volo.Abp.Users;

namespace Blue_Software
{
    public partial class AddQuest : Form
    {

        SqlConnection connection = new SqlConnection("Data Source=desktop-07mhrb4;Initial Catalog=Users_Blue;Integrated Security=True");
        public AddQuest()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
                Form1 form1 = new Form1();
                form1.pictureBox2.Visible = true;
                form1.pictureBox2.Image = Image.FromFile(@"C:\Users\David Joldes\Downloads\Blue.png");
                form1.ShowDialog();
                this.Close();
        }
        private void CheckDatabase()
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("IF OBJECT_ID('Texte', 'U') IS NULL CREATE TABLE Texte (Id INT PRIMARY KEY IDENTITY, Text NVARCHAR(MAX))", connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        private void AddQuest_Load(object sender, EventArgs e)
        {
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            int credit = AppData.CurrentUser.Credit;
            int creditGained = AppData.CurrentUser.CreditGained;
            string textToSave = txtQuest.Text;
            string answer = txtAnswer.Text;
            if(credit >= 50)
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Texte (Text, Answer) VALUES (@text, @answer)", connection);
                    command.Parameters.AddWithValue("@text", textToSave);
                    command.Parameters.AddWithValue("@answer", answer);
                    command.ExecuteNonQuery();
                    User.UpdateCredit(credit -= 50, creditGained -= 0);
                    SqlCommand command2 = new SqlCommand("UPDATE Texte SET PostDate = @postDate WHERE Text = @text", connection);
                    command2.Parameters.AddWithValue("@postDate", DateTime.Now);
                    command2.Parameters.AddWithValue("@text", textToSave);
                    command2.ExecuteNonQuery();
                    SqlCommand command3 = new SqlCommand("UPDATE Texte SET AnswersNumber = 0 WHERE Text = @text", connection);
                    command3.Parameters.AddWithValue("@text", textToSave);
                    command3.ExecuteNonQuery();

                    MessageBox.Show("Text added succesfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                txtQuest.Text = "";
                txtAnswer.Text = "";
            }
            else
            {
                MessageBox.Show("Credit is too low to post a new quest." + " " + "Try to solve a quest to earn credit!");
            }
        }

    }
}
