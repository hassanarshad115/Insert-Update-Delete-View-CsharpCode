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
    public partial class insertForm : Form
    {
        public insertForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void insertbutton_Click(object sender, EventArgs e)
        {
            if (nametextBox.Text == "" || classtextBox.Text == "" || agetextBox.Text == "" || addresstextBox.Text == "" || emailtextBox1.Text== "")
            {
                MessageBox.Show("Fill Blank Box","Error!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
               
               DialogResult res= MessageBox.Show("Press YES if You Want TO Enter Data?", "ENTER DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(res == DialogResult.Yes)
                {
                    string conn = ConfigurationManager.ConnectionStrings["logindb"].ConnectionString;
                    SqlConnection con = new SqlConnection(conn);
                    SqlCommand cmd = new SqlCommand("enter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = nametextBox.Text;
                    cmd.Parameters.Add("@class", SqlDbType.NVarChar, 50).Value = classtextBox.Text;
                    cmd.Parameters.Add("@age", SqlDbType.NVarChar, 50).Value = agetextBox.Text;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar, 50).Value = addresstextBox.Text;
                    cmd.Parameters.AddWithValue("@email", emailtextBox1.Text);
                    cmd.Parameters.AddWithValue("@cs",iscscheckBox1.Checked);
                    cmd.Parameters.AddWithValue("@java",isjavacheckBox2.Checked);
                    cmd.Parameters.AddWithValue("@php",isphpcheckBox3.Checked);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                  MessageBox.Show("Enter Data Successfully", "ENTER DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   

                    this.Hide();
                    sawForm sw = new sawForm();
                    sw.ShowDialog();
                    SAAF();

                }
                else
                {
                    MessageBox.Show("Data Not Enter", "NO ENTERING", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



            }
        }

        private void SAAF()
        {
            nametextBox.Text = "";
            agetextBox.Text = "";
            classtextBox.Text = "";
            addresstextBox.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
