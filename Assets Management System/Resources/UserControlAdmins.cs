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

namespace Assets_Management_System.Resources
{
    public partial class UserControlAdmins : UserControl
    {
        SqlConnection connect = new SqlConnection("Data Source=NOTE-BOOK\\SQLEXPRESS02;Initial Catalog=AMS;Integrated Security=True");
        string gender, gender1;

        public UserControlAdmins()
        {
            InitializeComponent();
            countAdmin();
        }

        public void countAdmin()
        {
            connect.Open();

            string selectQuery = "SELECT COUNT (*) FROM AdminTable ";
            SqlCommand comm = new SqlCommand(selectQuery, connect);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblAdminCount.Text = dt.Rows[0][0].ToString();

            connect.Close();
            populate();
        }

        public void clearData()
        {
            txbIDNo.Text = txbFullnames.Text = txbEmail.Text = txbPhoneNo.Text = txbPassword.Text = string.Empty;
            checkBoxMale.Checked = false;
            checkBoxFemale.Checked = false;
        }

        public void clearData1()
        {
            txbIDNo1.Text = txbFullnames1.Text = txbEmail1.Text = txbPhoneNo1.Text = txbPassword1.Text = string.Empty;
            checkBoxMale1.Checked = false;
            checkBoxFemale1.Checked = false;
        }

        public void populate()
        {
            connect.Open();

            string selectQuery = "SELECT * FROM AdminTable ";
            SqlCommand comm = new SqlCommand(selectQuery, connect);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridViewAdmins.DataSource = ds.Tables[0];

            connect.Close();
        }

        private void UserControlAdmins_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bttnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                ////////////////////////////////////////////////////////
                if (checkBoxMale.Checked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                ////////////////////////////////////////////////////////
                if (txbIDNo.Text.Length <= 0)
                {
                    lblErrorMessageID.Text = "ID Required!";
                }
                else
                {
                    lblErrorMessageID.Text = "";
                }
                ////////////////////////////////////////////////////////
                if (txbFullnames.Text.Length <= 0)
                {
                    lblErrorMessageF.Text = "Fullnames Required!";
                }
                else
                {
                    lblErrorMessageF.Text = "";
                }
                ////////////////////////////////////////////////////////
                if (txbEmail.Text.Length <= 0)
                {
                    lblErrorMessageE.Text = "Email Required!";
                }
                else
                {
                    lblErrorMessageE.Text = "";
                }
                ////////////////////////////////////////////////////////
                if (txbPhoneNo.Text.Length <= 0)
                {
                    lblErrorMessagePNo.Text = "Phone No. Required!";
                }
                else
                {
                    lblErrorMessagePNo.Text = "";
                }
                ////////////////////////////////////////////////////////
                if (txbPassword.Text.Length <= 0)
                {
                    lblErrorMessageP.Text = "Password Required!";
                }
                else
                {
                    lblErrorMessageP.Text = "";
                }
                ////////////////////////////////////////////////////////
                if (checkBoxMale.Checked == false && checkBoxFemale.Checked == false)
                {
                    lblErrorMessageG.Text = "Gender Required!";
                }
                else if (txbEmail.Text.Contains("@") && txbEmail.Text.Contains(".com") || txbEmail.Text.Contains(".org") || txbEmail.Text.Contains(".co.za"))
                {
                    connect.Open();

                    string insertQuery = "INSERT INTO AdminTable VALUES('" + txbIDNo.Text + "', '" + txbFullnames.Text + "', '" + txbEmail.Text + "', '" + txbPhoneNo.Text + "', '" + txbPassword.Text + "', '" + gender + "', getdate() ) ";
                    SqlCommand comm = new SqlCommand(insertQuery, connect);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Admin Added Successfully!", "Asset Manangement System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connect.Close();
                    clearData();
                    populate();
                }
                else
                {
                    lblErrorMessageE.Text = "Invalid Email Address!";
                }
                ////////////////////////////////////////////////////////

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttnUpdate_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (checkBoxMale1.Checked == true)
                {
                    gender1 = "Male";
                }
                else
                {
                    gender1 = "Female";
                }
                ////////////////////////////////////////////////////////
                if (txbIDNo1.Text.Length <= 0)
                {
                    lblErrorID.Text = "Select ID You Want To Update!";
                }
                else
                {
                    connect.Open();

                    string updateQuery = "UPDATE AdminTable SET Fullnames = '" + txbFullnames1.Text + "', EmailAddress = '" + txbEmail1.Text + "', PhoneNo = '" + txbPhoneNo1.Text + "', Password = '" + txbPassword1.Text + "', Gender = '" + gender1 + "', Date = getdate() WHERE IDNo = '" + txbIDNo1.Text + "' ";
                    SqlCommand comm = new SqlCommand(updateQuery, connect);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Admin Update Successfully!", "Asset Manangement System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    connect.Close();
                    clearData1();
                    populate();
                    lblErrorID.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            if (checkBoxMale1.Checked == true)
                gender1 = "Male";
            else
                gender1 = "Female";

            try
            {
                if (txbIDNo1.Text.Length <= 0)
                {
                    lblErrorID.Text = "Select ID You Want To Delete!";
                }
                else
                {
                    connect.Open();

                    string updateQuery = "DELETE FROM AdminTable WHERE IDNo = '" + txbIDNo1.Text + "' ";
                    SqlCommand comm = new SqlCommand(updateQuery, connect);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Admin Deleted Successfully!", "Asset Manangement System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connect.Close();
                    clearData1();
                    populate();
                    lblErrorID.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbIDNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txbIDNo.Text, "[^0-9]"))
            {
                txbIDNo.Text = txbIDNo.Text.Remove(txbIDNo.Text.Length - 1);
                lblErrorMessageID.Text = "Enter Only Numbers";
            }
            else
            {
                lblErrorMessageID.Text = " ";
            }
        }

        private void txbPhoneNo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txbPhoneNo.Text, "[^0-9]"))
            {
                txbPhoneNo.Text = txbPhoneNo.Text.Remove(txbPhoneNo.Text.Length - 1);
                lblErrorMessagePNo.Text = "Enter Only Numbers";
            }
            else
            {
                lblErrorMessagePNo.Text = " ";
            }
        }

        private void dataGridViewAdmins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewAdmins.CurrentRow.Selected = true;
                txbIDNo1.Text = dataGridViewAdmins.Rows[e.RowIndex].Cells["IDNo"].Value.ToString();
                txbFullnames1.Text = dataGridViewAdmins.Rows[e.RowIndex].Cells["Fullnames"].Value.ToString();
                txbEmail1.Text = dataGridViewAdmins.Rows[e.RowIndex].Cells["EmailAddress"].Value.ToString();
                txbPhoneNo1.Text = dataGridViewAdmins.Rows[e.RowIndex].Cells["PhoneNo"].Value.ToString();
                txbPassword1.Text = dataGridViewAdmins.Rows[e.RowIndex].Cells["Password"].Value.ToString();

                if(dataGridViewAdmins.Rows[e.RowIndex].Cells["Gender"].Value.ToString() == "Male")
                {
                    checkBoxMale1.Checked = true;
                }
                else
                {
                    checkBoxMale1.Checked = false;
                }

                if (dataGridViewAdmins.Rows[e.RowIndex].Cells["Gender"].Value.ToString() == "Female")
                {
                    checkBoxFemale1.Checked = true;
                }
                else
                {
                    checkBoxFemale1.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbIDNo1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txbIDNo1.Text, "[^0-9]"))
            {
                txbIDNo1.Text = txbIDNo1.Text.Remove(txbIDNo1.Text.Length - 1);
                lblErrorID.Text = "Enter Only Numbers";
            }
            else
            {
                lblErrorID.Text = " ";
            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            connect.Open();

            string selectQuery = "SELECT * FROM AdminTable WHERE Fullnames LIKE '"+ txbSearch.Text +"%' ";
            SqlCommand comm = new SqlCommand(selectQuery, connect);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridViewAdmins.DataSource = ds.Tables[0];

            connect.Close();
        }

        private void txbPhoneNo1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txbPhoneNo1.Text, "[^0-9]"))
            {
                txbPhoneNo1.Text = txbPhoneNo1.Text.Remove(txbPhoneNo1.Text.Length - 1);
                lblErrorPNo.Text = "Enter Only Numbers";
            }
            else
            {
                lblErrorPNo.Text = " ";
            }
        }

    }
}
