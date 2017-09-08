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
    public partial class firstForm : Form
    {
        public firstForm()
        {
            InitializeComponent();
        }

        private void firstForm_Load(object sender, EventArgs e)
        {
            maindataGridView1.DataSource = DataSaw();
        }

        private object DataSaw()
        {
            DataTable obj = new DataTable();

            string connectionstring = ConfigurationManager.ConnectionStrings["logindb"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionstring);

            SqlDataAdapter da = new SqlDataAdapter("select * from t", conn);
            da.Fill(obj);

            return obj;

        }

        private void signoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj = new Form1();
            obj.ShowDialog();
        }




        private void hassanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            insertForm o = new insertForm();
            o.ShowDialog();
        }
    }
}
