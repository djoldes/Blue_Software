using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Blue_Software
{
    public partial class SignUp : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Users_Blue;Integrated Security=True");
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*new Form1().Show();
            this.Hide();*/
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into SignUp_Blue values('" + txtFirstName + "','" + txtLastName + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data added succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
