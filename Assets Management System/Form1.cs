using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assets_Management_System
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=NOTE-BOOK\\SQLEXPRESS02;Initial Catalog=AMS;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        public void clearData()
        {
            txbEmail.Text = txbPassword.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbEmail.Text.Length <= 0)
                {
                    lblErrorMessageE.Text = "Email Required!";
                }
                else
                {
                    lblErrorMessageE.Text = " ";
                }
                //////////////////////////////////////////////////////
                if (txbPassword.Text.Length <= 0)
                {
                    lblErrorMessageP.Text = "Password Required!";
                }
                else
                {
                    lblErrorMessageP.Text = " ";
                }
                //////////////////////////////////////////////////////
                if (txbEmail.Text.Contains("@") && txbEmail.Text.Contains(".com") || txbEmail.Text.Contains(".co.za") || txbEmail.Text.Contains(".org"))
                {
                    connect.Open();

                    string selectQuery = "SELECT * FROM AdminTable WHERE EmailAddress = '" + txbEmail.Text + "' AND Password = '" + txbPassword.Text + "' ";
                    SqlCommand comm = new SqlCommand(selectQuery, connect);
                    SqlDataAdapter sda = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    connect.Close();

                    if (count == 1)
                    {
                        // username = txbUsernameEmaill.Text;
                        MainFormDashboard goToform = new MainFormDashboard();
                        goToform.Show();
                        this.Hide();
                    }

                    else
                    {
                        lblErrorMessageP.Text = "Incorrect Login Details!";
                        clearData();
                    }
                }
                else
                {
                    lblErrorMessageE.Text = "Invalid Email!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
           DialogResult userChoice = MessageBox.Show("Are You Sure You Want To Exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(userChoice == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            this.txbPassword.PasswordChar = this.chbShowPassword.Checked ? char.MinValue : '*';
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
