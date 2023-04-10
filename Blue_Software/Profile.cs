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
    }
}
