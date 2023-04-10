using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blue_Software
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            // Execută interogarea pentru a obține utilizatorii cu cele mai multe puncte
            string query = "SELECT TOP 3 Username, CreditGained FROM SignUp_Blue ORDER BY CreditGained DESC";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // Creează o listă de utilizatori din rezultatele interogării
            List<User> userList = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.Username = reader.GetString(0);
                user.CreditGained = reader.GetInt32(1);
                userList.Add(user);
            }
            reader.Close();
            connection.Close();

            // Afișează primii trei utilizatori în cele trei label-uri
            int i = 0;
            foreach (var user in userList)
            {
                switch (i)
                {
                    case 0:
                        label1.Text = user.Username + " - " + user.CreditGained;
                        break;
                    case 1:
                        label2.Text = user.Username + " - " + user.CreditGained;
                        break;
                    case 2:
                        label3.Text = user.Username + " - " + user.CreditGained;
                        break;
                    default:
                        break;
                }
                i++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.pictureBox2.Visible = true;
            form1.pictureBox2.Image = Image.FromFile(@"C:\Users\David Joldes\Downloads\Blue.png");
            form1.ShowDialog();
            this.Close();
        }
    }
}
