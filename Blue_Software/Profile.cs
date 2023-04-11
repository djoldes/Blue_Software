using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blue_Software
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            string username = AppData.CurrentUser.Username;
            txtUsername.Text = username;
            string credit = AppData.CurrentUser.Credit.ToString();
            txtCredit.Text = credit;
            string creditGained = AppData.CurrentUser.CreditGained.ToString();
            txtCreditGained.Text = creditGained;
        }
        
        private void logout_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Close();
            Form login = new Login();
            login.Show();
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
