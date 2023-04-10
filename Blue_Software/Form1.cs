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
    
    public partial class Form1 : Form
    {
        bool sidebarExpand;
        Form home = new Home();
        Form addquest = new AddQuest();
        Form profile = new Profile();
        Form leaderboard = new Leaderboard();
        public Form1()
        {
            InitializeComponent();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            FormFunctions.LoadForm(home, panel3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormFunctions.LoadForm(addquest , panel3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppData.UpdateCurrentUser(AppData.CurrentUser);
            FormFunctions.LoadForm(profile, panel3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormFunctions.LoadForm(leaderboard, panel3);
        }
    }
}
