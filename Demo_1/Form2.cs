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

namespace Demo_1
{
    public partial class Form2 : Form
    {

        DbConnect conn = new DbConnect();
        private int x = 0;
        private int y = 0;
        private int indexer = 0;
        private int ID;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();

            SelectDan selectDan = new SelectDan();

            selectDan.Fie();

            if (comboBox1.Text == "колесо")
            {
                ID = 1;
            }
            else if (comboBox1.Text == "диск")
            {
                ID = 2;
            }
            else if (comboBox1.Text == "запаска")
            {
                ID = 3;
            }
            else if (comboBox1.Text == "шина")
            {
                ID = 4;
            }

            string files = selectDan.ReturnPictureImg(Convert.ToInt32(textBox4.Text) + 1);

            SqlCommand command_1 = new SqlCommand($"insert into Product values ('{comboBox1.Text}',{ID},'{textBox2.Text}','{textBox3.Text}','{files}',{textBox5.Text},{textBox6.Text},{textBox7.Text});", conn.GetSqlConnection());
            command_1.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectDan selectDan = new SelectDan();

            selectDan.Fie();

            for (int i = 0; i < 65; i++)
            {

                selectDan.ReturnPicture(panel3, indexer, x, y);
                x += 119;
                indexer++;
                //119
                if (x >= 357)
                {
                    x = 3;
                    y += 78;
                }

            }
        }

    }
}
