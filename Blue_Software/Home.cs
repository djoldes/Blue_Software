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

namespace Blue_Software
{
    public partial class Home : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=desktop-07mhrb4;Initial Catalog=Users_Blue;Integrated Security=True");
        
        public Home()
        {
            InitializeComponent();
        }
        private void DisplaySavedText()
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Texte", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string text = reader["Text"].ToString();

                    Label label = new Label();
                    label.AutoSize = true;
                    label.Text = text;
                    label.BackColor = Color.White;
                    label.ForeColor = Color.DarkBlue;
                    label.Font = new Font("Arial", 12, FontStyle.Regular);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Padding = new Padding(-10);
                    label.Click += new EventHandler(Label_Click);

                    flowLayoutPanel1.Controls.Add(label);
                }

                reader.Close();
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
        private void Label_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            string text = label.Text;
            
            Quest form2 = new Quest(text);
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.pictureBox2.Visible = true;
            form1.pictureBox2.Image = Image.FromFile(@"C:\Users\David Joldes\Downloads\Blue.png");
            form1.ShowDialog();
            this.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {   
            DisplaySavedText();
        }

       

    }
}
