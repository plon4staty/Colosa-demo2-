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
    public partial class Form1 : Form
    {
        public int index = 0;
        public int newpos = 0;
        DbConnect connect = new DbConnect();
        public Form1()
        {
            InitializeComponent();
            
            for (int i = 0; i <= 20; i++)
            {
                PaneInitialization paneInitialization = new PaneInitialization();
                paneInitialization.PanelAdd(panel1, newpos);
                paneInitialization.PictureBoxAdd(index, "select * from Product;");
                paneInitialization.TextBoxAdd(index, "select * from Product;");
                newpos += 140;
                index++;
            }
            newpos = 0;
            index = 0;

        }
        //Сортирока по цене
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
            connect.Open();

            if (comboBox1.Text == "По возврастанию")
            {
                panel1.Controls.Clear();
                for (int i = 0; i <= 20; i++)
                {
                    PaneInitialization paneInitialization = new PaneInitialization();
                    paneInitialization.PanelAdd(panel1, newpos);
                    paneInitialization.PictureBoxAdd(index, "SELECT * FROM Product  ORDER BY MinCostForAgent");
                    paneInitialization.TextBoxAdd(index, "SELECT * FROM Product  ORDER BY MinCostForAgent");
                    newpos += 140;
                    index++;
                }
                newpos = 0;
                index = 0;
            }
            else
            {
                panel1.Controls.Clear();
                for (int i = 0; i <= 20; i++)
                {
                    PaneInitialization paneInitialization = new PaneInitialization();
                    paneInitialization.PanelAdd(panel1, newpos);
                    paneInitialization.PictureBoxAdd(index, "select * from Product order by MinCostForAgent DESC;");
                    paneInitialization.TextBoxAdd(index, "select * from Product order by MinCostForAgent DESC;");
                    newpos += 140;
                    index++;
                }
                newpos = 0;
                index = 0;
            }
            connect.Close();

        }

        //Сортировка по типу материала
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            

            if (comboBox2.Text == "Все типы")
            {
                panel1.Controls.Clear();
                for (int i = 0; i <= 20; i++)
                {
                    PaneInitialization paneInitialization = new PaneInitialization();
                    paneInitialization.PanelAdd(panel1, newpos);
                    paneInitialization.PictureBoxAdd(index, "select * from Product;");
                    paneInitialization.TextBoxAdd(index, "select * from Product;");
                    newpos += 140;
                    index++;
                }
                newpos = 0;
                index = 0;
            }
            else if (comboBox2.Text == "колесо")
            {
                panel1.Controls.Clear();
                for (int i = 0; i <= 18; i++)
                {
                    PaneInitialization paneInitialization = new PaneInitialization();
                    paneInitialization.PanelAdd(panel1, newpos);
                    paneInitialization.PictureBoxAdd(index, "select * from Product where ProductTypeID = 1;");
                    paneInitialization.TextBoxAdd(index, "select * from Product where ProductTypeID = 1;");
                    newpos += 140;
                    index++;
                }
                newpos = 0;
                index = 0;
            }
            else if (comboBox2.Text == "диск")
            {
                panel1.Controls.Clear();
                for (int i = 0; i <= 18; i++)
                {
                    PaneInitialization paneInitialization = new PaneInitialization();
                    paneInitialization.PanelAdd(panel1, newpos);
                    paneInitialization.PictureBoxAdd(index, "select * from Product where ProductTypeID = 2;");
                    paneInitialization.TextBoxAdd(index, "select * from Product where ProductTypeID = 2;");
                    newpos += 140;
                    index++;
                }
                newpos = 0;
                index = 0;
            }
            else if (comboBox2.Text == "запаска")
            {
                panel1.Controls.Clear();
                for (int i = 0; i <= 18; i++)
                {
                    PaneInitialization paneInitialization = new PaneInitialization();
                    paneInitialization.PanelAdd(panel1, newpos);
                    paneInitialization.PictureBoxAdd(index, "select * from Product where ProductTypeID = 3;");
                    paneInitialization.TextBoxAdd(index, "select * from Product where ProductTypeID = 3;");
                    newpos += 140;
                    index++;
                }
                newpos = 0;
                index = 0;
            }
            else if (comboBox2.Text == "шина")
            {
                panel1.Controls.Clear();
                for (int i = 0; i <= 18; i++)
                {
                    PaneInitialization paneInitialization = new PaneInitialization();
                    paneInitialization.PanelAdd(panel1, newpos);
                    paneInitialization.PictureBoxAdd(index, "select * from Product where ProductTypeID = 4;");
                    paneInitialization.TextBoxAdd(index, "select * from Product where ProductTypeID = 4;");
                    newpos += 140;
                    index++;
                }
                newpos = 0;
                index = 0;
            }
        }

        //Динамически поиск
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            connect.Open();
                    panel1.Controls.Clear();
                    SqlCommand command= new SqlCommand($"SELECT * FROM Product WHERE Description LIKE '%{textBox1.Text}%'", connect.GetSqlConnection());
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    PaneInitialization paneInitialization = new PaneInitialization();
                    paneInitialization.PanelAdd(panel1, newpos);
                    paneInitialization.PictureBoxAdd(index, $"SELECT * FROM Product WHERE Description LIKE '%{textBox1.Text}%'");
                    paneInitialization.TextBoxAdd(index, $"SELECT * FROM Product WHERE Description LIKE '%{textBox1.Text}%'");
                    newpos += 140;
                    index++;
                }

            }
                newpos = 0;
                index = 0;
            connect.Close();
        }

        //Кнопка добавить
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            
        }

        //Удаление
        private void button2_Click(object sender, EventArgs e)
        {
            FormDelete delete = new FormDelete();
            delete.Show();
        }

        //Изменение
        private void button3_Click(object sender, EventArgs e)
        {
            FormEdit edit = new FormEdit();
            edit.Show();
        }
    }
}
