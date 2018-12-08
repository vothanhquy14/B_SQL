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
namespace Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\qlnv.accdb");
        private void Form1_Load(object sender, EventArgs e)
        {
            cnn.Open();
            refesh();
        }

        public void refesh()
        {
            string str = "Select * from Chucvu";
            OleDbCommand cmd = new OleDbCommand(str, cnn);
            OleDbDataReader r = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(r);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "insert into chucvu values(@ma, @ten, @heso)";
            OleDbCommand cmd = new OleDbCommand(str, cnn);
            cmd.Parameters.AddWithValue("@ma", textBox1.Text);
            cmd.Parameters.AddWithValue("@ten", textBox2.Text);
            cmd.Parameters.AddWithValue("@heso", textBox3.Text);
            cmd.ExecuteNonQuery();
            refesh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "delete FROM chucvu where macv=@ma";
            OleDbCommand cmd = new OleDbCommand(str, cnn);
            cmd.Parameters.AddWithValue("@ma", textBox1.Text);
            cmd.ExecuteNonQuery();
            refesh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "update chucvu set tencv = '" + textBox2.Text + "', hsphucap = " + textBox3.Text + "',macv = " + textBox1.Text;
            OleDbCommand cmd = new OleDbCommand(str, cnn);
            cmd.Parameters.AddWithValue("@ma", textBox1.Text);
            cmd.Parameters.AddWithValue("@ten", textBox2.Text);
            cmd.Parameters.AddWithValue("@heso", textBox3.Text);
            cmd.ExecuteNonQuery();
            refesh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dataGridView1.SelectedRows[0];
            textBox1.Text = dgvr.Cells["macv"].Value.ToString();
            textBox2.Text = dgvr.Cells["tencv"].Value.ToString();
            textBox3.Text = dgvr.Cells["hsphucap"].Value.ToString();
        }

        

    }
}
