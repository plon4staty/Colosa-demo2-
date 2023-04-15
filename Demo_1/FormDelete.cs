using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_1
{
    public partial class FormDelete : Form
    {
        DbConnect db = new DbConnect();
        public FormDelete()
        {
            InitializeComponent();
            db.Open();
            SqlCommand exec = new SqlCommand("SELECT * FROM PRODUCT", db.GetSqlConnection());
            DataTable dt = new DataTable();
            var reader = exec.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;
            SqlCommand delete = new SqlCommand("DELETE FROM PRODUCTS WHERE ID =" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString() +"");
            delete.ExecuteNonQuery();
            db.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
