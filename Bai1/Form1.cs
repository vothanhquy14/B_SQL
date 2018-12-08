using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           SqlConnection conn = new SqlConnection(@"Data Source=MT0107\SQLEXPRESS;Initial Catalog=QLNV;Integrated Security=True");
           DataSet ds;
           SqlDataAdapter da;
           string query = "Select * from nhanvien";
           da = new SqlDataAdapter(query, conn);
           ds = new DataSet();
           da.Fill(ds, "tblnhanvien");
           dataGridView1.DataSource = ds.Tables[0];


        }
    }
}
