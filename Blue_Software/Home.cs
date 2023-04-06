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
    public partial class Home : Form
    {
        public string TextPostare
        {
            get { return _textPostare; }
            set { _textPostare = value; labelPostare.Text = value; }
        }
        private string _textPostare;
        public Home()
        {
            InitializeComponent();
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new Point(10, 10);
            label.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Controls.Add(label);
            TextPostare = _textPostare;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.pictureBox2.Visible = true;
            form1.pictureBox2.Image = Image.FromFile(@"C:\Users\David Joldes\Downloads\Blue.png");
            form1.ShowDialog();
            this.Close();
        }
    }
}
