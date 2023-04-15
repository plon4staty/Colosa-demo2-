using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_1
{
    public class PaneInitialization
    {

        DbConnect connect = new DbConnect();

        private PictureBox NewPictureBox = new PictureBox();
        private Label label = new Label();
        Panel NewPanel = new Panel();
        int i = 0;

        public void PanelAdd(Panel panrlcontrol, int stup) 
        {
           
            NewPanel.Location = new Point(4, 4 + stup);
            NewPanel.Size = new Size(750, 130);
            NewPanel.BackColor= Color.White;
            panrlcontrol.Controls.Add(NewPanel);


        }

        public void PictureBoxAdd(int index, string commandin) 
        {
            connect.Open();

            string[] img = new string[1000];

            SqlCommand command = new SqlCommand(commandin, connect.GetSqlConnection());

            using (var reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    img[i] = reader["Image"].ToString();
                    i++;
                }
                i = 0;

            }

            if (img[index] == "нет" || img[index] == "не указано" || img[index] == "отсутствует")
            {
                NewPictureBox.Location = new Point(15, 15);
                NewPictureBox.Size = new Size(135, 102);
                NewPanel.Controls.Add(NewPictureBox);
                Image image_2 = Image.FromFile($@"C:\Users\Тимофей\Desktop\Naughty-mature-lady-playing-with-her-toy-boy.jpg");
                NewPictureBox.Image = image_2;
                NewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                i = 0;
                return;
            }
 
            NewPictureBox.Location = new Point(15, 15);
            NewPictureBox.Size = new Size(135, 102);
            NewPanel.Controls.Add(NewPictureBox);
            Image image = Image.FromFile($@"C:\Users\Тимофей\Desktop\Study-practice-master\Сессия 1\products_k_import\{img[index]}");
            NewPictureBox.Image = image;
            NewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            i = 0;
            connect.Close();

        }

        public void TextBoxAdd(int index, string commandin) 
        {
            connect.Open();


            try
            {
                SqlCommand command = new SqlCommand(commandin, connect.GetSqlConnection());

                int[] indexprodukt = new int[100];
                string[] nameprodukt = new string[100];
                int[] artickul = new int[100];
                int[] Prise = new int[100];
                using (var reaer = command.ExecuteReader())
                {
                    while (reaer.Read())
                    {
                        indexprodukt[i] = Convert.ToInt32(reaer["ProductTypeID"]);
                        i++;

                    }
                }
                if (indexprodukt[index] == 1)
                {
                    Label label_TypeProdukt = new Label();
                    label_TypeProdukt.Text = "колесо";
                    label_TypeProdukt.Location = new Point(150, 15);
                    NewPanel.Controls.Add(label_TypeProdukt);
                    i = 0;
                }
                else if (indexprodukt[index] == 2)
                {
                    Label label_TypeProdukt = new Label();
                    label_TypeProdukt.Text = "диск";
                    label_TypeProdukt.Location = new Point(150, 15);
                    NewPanel.Controls.Add(label_TypeProdukt);
                    i = 0;
                }
                else if (indexprodukt[index] == 3)
                {
                    Label label_TypeProdukt = new Label();
                    label_TypeProdukt.Text = "запаска";
                    label_TypeProdukt.Location = new Point(150, 15);
                    NewPanel.Controls.Add(label_TypeProdukt);
                    i = 0;
                }
                else if (indexprodukt[index] == 4)
                {
                    Label label_TypeProdukt = new Label();
                    label_TypeProdukt.Text = "шина";
                    label_TypeProdukt.Location = new Point(150, 15);
                    NewPanel.Controls.Add(label_TypeProdukt);
                    i = 0;
                }

                using (var reaer = command.ExecuteReader())
                {
                    while (reaer.Read())
                    {
                        nameprodukt[i] = reaer["Description"].ToString();
                        i++;
                    }
                }

                Label label_NameProdukt = new Label();
                label_NameProdukt.Text = nameprodukt[index];
                label_NameProdukt.Size = new Size(132, 13);
                label_NameProdukt.Location = new Point(250, 13);
                NewPanel.Controls.Add(label_NameProdukt);
                i = 0;



                using (var reaer = command.ExecuteReader())
                {
                    while (reaer.Read())
                    {
                        artickul[i] = Convert.ToInt32(reaer["ArticleNumber"]);
                        i++;

                    }
                }

                Label label_Artickul = new Label();
                label_Artickul.Text = artickul[index].ToString();
                label_Artickul.Location = new Point(150, 40);
                NewPanel.Controls.Add(label_Artickul);
                i = 0;

                Label label_Matereal = new Label();
                label_Matereal.Text = "Материалы:";
                label_Matereal.Location = new Point(150, 67);
                NewPanel.Controls.Add(label_Matereal);

                Label label_MaterealType = new Label();
                label_MaterealType.Text = nameprodukt[index];
                label_MaterealType.Location = new Point(250, 67);
                NewPanel.Controls.Add(label_MaterealType);



                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        Prise[i] = Convert.ToInt32(reader["MinCostForAgent"]);
                        i++;
                    }

                }


                Label label_Cost = new Label();
                label_Cost.Text = Prise[index].ToString();
                label_Cost.Location = new Point(680, 30);
                NewPanel.Controls.Add(label_Cost);
                i = 0;



                connect.Close();
            }
            catch (Exception)
            {

                return;
            }
            

        }



    }
}