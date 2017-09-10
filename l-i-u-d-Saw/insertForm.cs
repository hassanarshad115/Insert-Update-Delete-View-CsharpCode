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
            if (nametextBox.Text == "" || classtextBox.Text == "" || agetextBox.Text == "" || addresstextBox.Text == "" || emailtextBox1.Text == "")
            {
                MessageBox.Show("Fill Blank Box", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DialogResult res = MessageBox.Show("Press YES if You Want TO Enter Data?", "ENTER DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
               
                if (maleradioButton1.Checked == false && femaleradioButton2.Checked == false)
                {
                    MessageBox.Show("Please Select Gender !!", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (res == DialogResult.Yes)
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

                        //checked hoga text ni ayga . kbad iski type bit hoge
                        cmd.Parameters.AddWithValue("@cs", iscscheckBox1.Checked);
                        cmd.Parameters.AddWithValue("@java", isjavacheckBox2.Checked);
                        cmd.Parameters.AddWithValue("@php", isphpcheckBox3.Checked);
                        //method bnyga gender k lye iski type int
                        cmd.Parameters.AddWithValue("@genderid", getGender());
                        
                        //value ayga .text ki jga iski type datetime hoge value.Date lgana h q k jst date chaia ha
                        cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value.Date);
                        //time of day yad rkhna
                        cmd.Parameters.AddWithValue("@sdate", onedateTimePicker3.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@edate", twodateTimePicker2.Value.TimeOfDay);

                        //country name ka ak colom bnaygy table ma fr sp ma nvarcahr k sath lygy fr ider asy likhygy .text k sath likhna ha
                        cmd.Parameters.AddWithValue("@country", countrycomboBox1.Text);
                       
                        //agr int ma save krygy to selectedvalue krygy usky lye alg table bna k jsy foreign key k sath krty h
                        //wse uuski id ko agy ly kr jaygy 97 wla lacture ayga
                       // cmd.Parameters.AddWithValue("@countryid", countrycomboBox1.SelectedValue);


                        con.Open();
                        cmd.ExecuteNonQuery();//i.u.d k sath ExecuteNonQuery.r select k sath ExecuteScaller r fetch k sath SqlAdapter ya SqlReader obj bna k 
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
        }


        /// <summary>
        /// gender k lye amm tor pr int lty ha ak mgr ma jsy php java k dabby bnay ha wse bnaoga ab
        /// </summary>
        /// <returns></returns>

        private int getGender()
        { 
            if(maleradioButton1.Checked)
            {
                return 1;
            }
            if(femaleradioButton2.Checked)
            {
                return 2;
            }

            return 0;
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //PHLY table bnalia combobox k lye fr table ma data dala ha jo nzzr ayga fr ye kam krna ha nichy joarha ha
        private void insertForm_Load(object sender, EventArgs e)
        {
            countrycomboBox1.DataSource = GetData(); //apni trf sy ye method bnaya ha
            countrycomboBox1.DisplayMember = "Country Name";//ks colom ko dekhana ha uska name idr likhna ha
                                                            // timetablecomboBox1.DataSource = GetData();
                                                            //timetablecomboBox1.DisplayMember = "TimeTable"; alg table bna k r sp bna k krlyn jsy uper wala kia ha wse
                                                            //agr jb run kry to kch b na ho bl k gam khud usmy sy select kry
            countrycomboBox1.SelectedIndex = -1;
            //jb b combobox ma data dekhana hoto form ko load krty ha
            
        }

        private DataTable GetData()
        {//datatable ka obj lty he isko nechy return krwana hoga
            DataTable obj = new DataTable();


            string connect = ConfigurationManager.ConnectionStrings["logindb"].ConnectionString;
            SqlConnection con = new SqlConnection(connect);

           SqlDataAdapter adapter = new SqlDataAdapter("reading", con);//ma drct use kra ho sp ko use ni kr rha
           adapter.Fill(obj);
     /*
            SqlCommand cmd = new SqlCommand("reading", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader r = cmd.ExecuteReader();
            obj.Load(r);
            */
            return obj;
        }
    }
}
