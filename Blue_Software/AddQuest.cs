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
    public partial class AddQuest : Form
    {

        
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

        private void AddQuest_Load(object sender, EventArgs e)
        {
            txtQuest.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.TextPostare = txtQuest.Text;
            home.Show();
        }
    }
}
