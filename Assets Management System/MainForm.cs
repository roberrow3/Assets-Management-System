using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assets_Management_System
{
    public partial class MainFormDashboard : Form
    {
        public MainFormDashboard()
        {
            InitializeComponent();
        }

        public void movePanel(Control btn)
        {
            panelMove.Top = btn.Top;
            panelMove.Height = btn.Height;
        }

        private void bttnDashboard_Click(object sender, EventArgs e)
        {
            movePanel(bttnDashboard);
            userControlDashboard1.Visible = true;
            userControlAdmins1.Visible = false;
           // userControlAssets1.Visible = false;
        }

        private void bttnAssets_Click(object sender, EventArgs e)
        {
            movePanel(bttnAssets);
            userControlDashboard1.Visible = false;
            userControlAdmins1.Visible = false;
           // userControlAssets1.Visible = true;
        }

        private void bttnLocation_Click(object sender, EventArgs e)
        {
            movePanel(bttnLocation);
            userControlDashboard1.Visible = false;
            userControlAdmins1.Visible = false;
           // userControlAssets1.Visible = false;
        }

        private void bttnAdmins_Click(object sender, EventArgs e)
        {
            movePanel(bttnAdmins);
            userControlDashboard1.Visible = false;
            userControlAdmins1.Visible = true;
           // userControlAssets1.Visible = false;
        }

        private void MainFormDashboard_Load(object sender, EventArgs e)
        {

        }

        private void bttnLogout_Click(object sender, EventArgs e)
        {
            Form1 goToform = new Form1();
            goToform.Show();
            this.Hide();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult userchoice = MessageBox.Show("Are You Sure You Want To Exit?", "Exit...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(userchoice == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
