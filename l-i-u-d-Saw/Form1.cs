using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l_i_u_d_Saw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            if (authenticated(usernametextBox.Text, passwordtextBox.Text))
            {
                MessageBox.Show("Successfully login","Login",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                firstForm o = new firstForm();
                o.ShowDialog();
                saaf();
            }
            else
            {
                NewMethod();
                MessageBox.Show("Check Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                saaf();

            }

        }

        private void saaf()
        {
            usernametextBox.Text = "";
            passwordtextBox.Text = "";
        }

        private bool authenticated(string text1, string text2)
        {
            bool varr = false;
            try
            {
                if (usernametextBox.Text == "" || passwordtextBox.Text == "")
                {
                    NewMethod();
                    //  saaf();

                    //if (usernametextBox.Text == "")
                    //{
                    //    MessageBox.Show("Username Cannot Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //if (passwordtextBox.Text == "")
                    //{
                    //    MessageBox.Show("Password Cannot Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    usernametextBox.BackColor = Color.Teal;
                    passwordtextBox.BackColor = Color.Teal;
                    usernametextBox.ForeColor = Color.White;
                    passwordtextBox.ForeColor = Color.White;


                    string connectionstring = ConfigurationManager.ConnectionStrings["logindb"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connectionstring);
                    SqlCommand cmd = new SqlCommand("ldb", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = usernametextBox.Text;
                    cmd.Parameters.AddWithValue("@password", passwordtextBox.Text);
//                   cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = passwordtextBox.Text;

                    conn.Open();
                    varr = (bool)cmd.ExecuteScalar();
                    conn.Close();
                    // saaf();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in coding of login form"+ex.Message);
            }
            return varr;
        }

        private void NewMethod()
        {
            usernametextBox.BackColor = Color.Red;
            passwordtextBox.BackColor = Color.Red;
            usernametextBox.ForeColor = Color.White;
            passwordtextBox.ForeColor = Color.White;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://allice9554.000webhostapp.com/");
        }
    }
}
