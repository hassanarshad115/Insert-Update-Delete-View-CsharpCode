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
    public partial class sawForm : Form
    {
        public sawForm()
        {
            InitializeComponent();
        }

        private void sawForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getData();
        }

        private object getData()
        {
            DataTable dtbl = new DataTable();


            string conn = ConfigurationManager.ConnectionStrings["logindb"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);


            SqlDataAdapter adapter = new SqlDataAdapter("select * from t" , connection);
            adapter.Fill(dtbl);



            return dtbl;

        }

        private void goToMainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            firstForm o = new firstForm();
            o.ShowDialog();
        }
    }
}
