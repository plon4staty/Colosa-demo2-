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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Demo_1
{
    public partial class FormEdit : Form
    {
        DbConnect db = new DbConnect();
        public FormEdit()
        {
            InitializeComponent();
            db.Open();
            SqlCommand exec = new SqlCommand("SELECT * FROM PRODUCT", db.GetSqlConnection());
            DataTable dt = new DataTable();
            var reader = exec.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            textBox1.Text = dr.Cells[0].Value.ToString();
            textBox2.Text = dr.Cells[1].Value.ToString();
            textBox3.Text = dr.Cells[2].Value.ToString();
            textBox4.Text = dr.Cells[3].Value.ToString();
            textBox5.Text = dr.Cells[3].Value.ToString();
            textBox6.Text = dr.Cells[3].Value.ToString();
            textBox7.Text = dr.Cells[3].Value.ToString();
            textBox8.Text = dr.Cells[3].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand edit = new SqlCommand($"UPDATE PRODUCT WHERE ID ={dataGridView1.SelectedRows[0]} ({textBox2.Text}, {textBox3.Text}, {textBox4.Text}, {textBox5.Text}, {textBox6.Text}, {textBox7.Text}, {textBox8.Text},");
            edit.ExecuteNonQuery();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
