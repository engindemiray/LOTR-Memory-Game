using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOTR_Memory_Game
{
    public partial class Form1 : Form
    {
        Image[] images = {
            Properties.Resources.Sauron,
            Properties.Resources.Gandalf,
            Properties.Resources.Frodo,
            Properties.Resources.Bilbo,
            Properties.Resources.Gollum,
            Properties.Resources.Legolas,
            Properties.Resources.Aragorn,
            Properties.Resources.Gimli
        };

        int[] indexes = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        PictureBox firstbox;
        int firstIndex;
        int paired;
        int clicks;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mixImages();
        }

        private void mixImages()
        {
            Random rnd = new Random();

            for (int i = 0; i < 16; i++)
            {
                int number = rnd.Next(16);
                int casual = indexes[i];
                indexes[i] = indexes[number];
                indexes[number] = casual;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox Box = (PictureBox)sender;
            int boxNo = int.Parse(Box.Name.Substring(10));
            int indexNo = indexes[boxNo -1];
            Box.Image = images[indexNo];
            Box.Refresh();

            if (firstbox == null)
            {
                firstbox = Box;
                firstIndex = indexNo;
                clicks++;
            }

            else
            {
                System.Threading.Thread.Sleep(600);

                firstbox.Image = null;
                Box.Image = null;

                if (firstIndex == indexNo)
                {
                    paired++;
                    firstbox.Visible = false;
                    Box.Visible = false;

                    if (paired == 8)
                    {
                        MessageBox.Show("Congratulations! You Win \n \nClicks: " + clicks);
                        paired = 0;
                        clicks = 0;

                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }

                        mixImages();
                    }
                }

                firstbox = null;
            }
        }
    }
}
