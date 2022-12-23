using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PictureBox[,] button = new PictureBox[30, 30];
        PictureBox[,] player = new PictureBox[2, 15];
        PictureBox[,] player2 = new PictureBox[2, 15];
        Button karistir = new Button();
        Button dağit = new Button();
        List<Image> imageList = new List<Image>();
        Taslar tas;
        
        private void Form1_Load(object sender, EventArgs e)
        { 
        
            this.Width = 1300;
            this.Height = 800;
            this.StartPosition = FormStartPosition.CenterScreen;   
            butonOlustur();
            tasEkle();
            tahtaOlustur();
           
        }
        public void butonOlustur()
        {
            karistir.Width = 80;
            karistir.Height = 40;
            karistir.Left = 1200;
            karistir.Top = 100;
            karistir.Text = "Taşları Karıştır";
            karistir.Font = new Font("Impact", 8);
            karistir.BackColor = Color.DeepSkyBlue;
            this.Controls.Add(karistir);

            dağit.Width = 80;
            dağit.Height = 40;
            dağit.Location = new Point(1200, 160);
            dağit.Text = "Taşları Dağıt";
            dağit.Font = new Font("Impact", 8);
            dağit.BackColor = Color.SeaGreen;
            dağit.Visible = false;
            this.Controls.Add(dağit);
        }
        public void tasEkle()
        {
            imageList.Add(TasResim.altıAltı);
            imageList.Add(TasResim.ucAltı);
            imageList.Add(TasResim.besAltı);
            imageList.Add(TasResim.dörtAltı);
            imageList.Add(TasResim.ikiAltı);
            imageList.Add(TasResim.birAltı);
            imageList.Add(TasResim.besBes);
            imageList.Add(TasResim.dörtBes);
            imageList.Add(TasResim.ucBes);
            imageList.Add(TasResim.ikiBes);
            imageList.Add(TasResim.birBes);
            imageList.Add(TasResim.dörtDört);
            imageList.Add(TasResim.ucDört);
            imageList.Add(TasResim.ikiDört);
            imageList.Add(TasResim.birDört);
            imageList.Add(TasResim.ucUc);
            imageList.Add(TasResim.ikiUc);
            imageList.Add(TasResim.birUc);
            imageList.Add(TasResim.ikiİki);
            imageList.Add(TasResim.birİki);
            imageList.Add(TasResim.birBir);
            imageList.Add(TasResim.sıfırBir);
            imageList.Add(TasResim.sıfırAltı);
            imageList.Add(TasResim.sıfırBes);
            imageList.Add(TasResim.sıfırDört);
            imageList.Add(TasResim.sıfırUc);
            imageList.Add(TasResim.sıfırİki);
            imageList.Add(TasResim.sıfırSıfır);

        }
        public void tahtaOlustur()
        {
            int top = 80;
            int left = 0;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    button[i, j] = new PictureBox();
                    button[i, j].Width = 40;
                    button[i, j].Height = 20;
                    button[i, j].Left = left;
                    button[i, j].Top = top;
                    button[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    button[i, j].BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(button[i, j]);
                    left += 40;
                    if ((i + j) % 2 == 0)
                    {
                        button[i, j].BackColor = Color.DarkGreen;
                    }
                    else
                    {
                        button[i, j].BackColor = Color.Green;
                    }
                    Point koordinat = new Point();
                    koordinat.X = i;
                    koordinat.Y = j;
                    button[i, j].Tag = (Object)koordinat;
                }
                top += 20;
                left = 0;
            }
            int top1 = 680;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    
                    player[i, j] = new PictureBox();
                    player[i, j].Width = 80;
                    player[i, j].Height = 40;
                    player[i, j].Top = top1;
                    player[i,j].Left = left;
                    player[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    player[i, j].BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(player[i, j]);
                    left += 80;
                    player[i, j].BackColor = Color.SandyBrown;
                }
                top1 += 40;
                left= 0;
            }
            int top2 = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 15; j++)
                {

                    player2[i, j] = new PictureBox();
                    player2[i, j].Width = 80;
                    player2[i, j].Height = 40;
                    player2[i, j].Top = top2;
                    player2[i, j].Left = left;
                    player2[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    player2[i, j].BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(player2[i, j]);
                    left += 80;
                    player2[i, j].BackColor = Color.SandyBrown;
                }
                top2 += 40;
                left = 0;
            }

            tas = new Taslar(button, player, player2, button, imageList, karistir, dağit);
          
        }


    }
}
