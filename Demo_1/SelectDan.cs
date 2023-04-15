using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_1
{
    public class SelectDan
    {

        private string[] files = new string[65];

        public void Fie() 
        {
            
                string directoryPath = @"C:\Users\Тимофей\Desktop\Study-practice-master\Сессия 1\products_k_import\products";
                files = Directory.Exists(directoryPath) ? Directory.GetFiles(directoryPath) : new string[0];

        }

        public void ReturnPicture(Panel panel, int indexMass, int X, int Y) 
        {
        
            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(3 + X, 3 + Y);
            pictureBox.Size = new Size(92, 72);
            Image image = Image.FromFile($"{files[indexMass]}");
            pictureBox.Image = image;
            pictureBox.BackColor= Color.White;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            panel.Controls.Add(pictureBox);

        }

        public string ReturnPictureImg(int index) 
        {

            return files[index];

        
        }
    }
}
