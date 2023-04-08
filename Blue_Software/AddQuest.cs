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
                MessageBox.Show("A apărut o eroare: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        private void AddQuest_Load(object sender, EventArgs e)
        {
            txtQuest.Focus();
            CheckDatabase();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TOP 1 Text FROM Texte ORDER BY Id DESC", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string savedText = reader.GetString(0);
                    txtQuest.Text = savedText;
                }
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            int credit = AppData.CurrentUser.Credit;
            string textToSave = txtQuest.Text;
            if(credit >= 50)
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Texte (Text) VALUES (@text)", connection);
                    command.Parameters.AddWithValue("@text", textToSave);
                    command.ExecuteNonQuery();
                    AppData.CurrentUser.UpdateCredit(credit -= 50);
                    MessageBox.Show("Text salvat cu succes!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A apărut o eroare: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                txtQuest.ResetText();
                txtQuest.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Creditul este prea mic pentru a posta un quest nou." + " " + "Incearca sa rezolvi un quest pentru a castiga credit!");
            }
        }

    }
}
