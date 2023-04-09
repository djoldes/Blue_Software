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
            string connString = @"Data Source =.; Initial Catalog = Users_Blue; Integrated Security = True";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Texte WHERE Answer = @text", conn);
            cmd.Parameters.AddWithValue("@text", textAnswer.Text);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("The answer is correct! You won 50 credits!");
                AppData.CurrentUser.UpdateCredit(credit += 50);
            }
            else
            {
                MessageBox.Show("The answer is wrong!");
            }
            reader.Close();
            conn.Close();
        }
    }
}
