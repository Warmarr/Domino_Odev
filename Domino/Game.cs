using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Domino
{
    internal class Game : IMove
    {


        public List<Image> karisikTas = new List<Image>();
        public List<Image> player1Tas = new List<Image>();
        public List<Image> player2Tas = new List<Image>();
        Image player1resim;
        Image player2resim;
        Random random = new Random();
        PictureBox[,] dominatas;
        PictureBox[,] player1Tahta = new PictureBox[2, 15];
        PictureBox[,] player2Tahta = new PictureBox[2, 15];

        public event EventHandler Click;

        public Game(PictureBox[,] dominatas, PictureBox[,] player1, PictureBox[,] player2)
        {
            this.dominatas = dominatas;
            player1Tahta = player1;
            player2Tahta = player2;


            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    this.dominatas[i, j].Click += orta_Click;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    player1Tahta[i, j].Click += player1_Click;
                    player2Tahta[i, j].Click += player2_Click;
                }
            }

        }

        private void player2_Click(object sender, EventArgs e)
        {
            
              
            PictureBox player2click = (PictureBox)sender;
            if (player2click.Image != null)
            {
                Bitmap bitmap = (Bitmap)player2click.Image;

                player2resim = bitmap;

            }

        }
        
        private void player1_Click(object sender, EventArgs e)
        {
                  
            PictureBox player1click = (PictureBox)sender;
            if (player1click.Image != null)
            {
                Bitmap bitmap = (Bitmap)player1click.Image;
                
                player1resim = bitmap;

            }

        }
        private void orta_Click(object sender, EventArgs e)
        {
            

            PictureBox orta = (PictureBox)sender;

            //Player1 ve player2'nin koyduğu taşı önünden silmek için bitmapi string ifadeye çevirmek
            if(player1resim != null)
            {
                orta.Image = player1resim;

                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                player1resim.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] tasv = stream.ToArray();
                string player1resimstr = Convert.ToBase64String(tasv);
                oyuncu1kaldır(player1resimstr);
                player1resim = null;
            }
            else if (player2resim != null)
            {
                orta.Image = player2resim;

                System.IO.MemoryStream stream1 = new System.IO.MemoryStream();
                player2resim.Save(stream1, System.Drawing.Imaging.ImageFormat.Png);
                byte[] tasv = stream1.ToArray();
                string player2resimstr = Convert.ToBase64String(tasv);
                oyuncu2kaldır(player2resimstr);
                player2resim = null;

            }
            


        }

        public void karistir(List<Image> taslar)
        {
            karisikTas = taslar.OrderBy(a => random.Next()).ToList();

        }
        public void tasDagit()
        {
            while (player1Tas.Count < 14)
            {

                int index = random.Next(0, karisikTas.Count);
                player1Tas.Add(karisikTas[index]);
                karisikTas.Remove(karisikTas[index]);

            }


            while (player2Tas.Count < 14)
            {
                int index = random.Next(0, karisikTas.Count);
                player2Tas.Add(karisikTas[index]);
                karisikTas.Remove(karisikTas[index]);
            }
            oyuncu1Dagit();
        }
        public void oyuncu1Dagit()
        {
            while (player1Tas.Count > 0)
            {
                int x = random.Next(0, 2); //Rastgele x koordinatı alıyor
                int y = random.Next(0, 14); //Rastgele y koordinatı alıyor
                int tasİndex = random.Next(0, player1Tas.Count);
                if (Oyuncu1yerKontrol(x, y))
                {
                    player1Tahta[x, y].Image = player1Tas[tasİndex];
                    player1Tas.Remove(player1Tas[tasİndex]);

                    Bitmap bitmap = (Bitmap)player1Tahta[x, y].Image;
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] tasv = stream.ToArray();
                    string tasresim = Convert.ToBase64String(tasv);
                    ortadanTasKaldir(tasresim);
                }
            }
            oyuncu2Dagit();
        }
        public void oyuncu2Dagit()
        {
            while (player2Tas.Count > 0)
            {
                int x = random.Next(0, 2); //Rastgele x koordinatı alıyor
                int y = random.Next(0, 14); //Rastgele y koordinatı alıyor
                int tasİndex = random.Next(0, player2Tas.Count);
                if (Oyuncu2yerKontrol(x, y))
                {
                    player2Tahta[x, y].Image = player2Tas[tasİndex];
                    player2Tas.Remove(player2Tas[tasİndex]);

                    Bitmap bitmap = (Bitmap)player2Tahta[x, y].Image;
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] tasv = stream.ToArray();
                    string tasresim = Convert.ToBase64String(tasv);
                    ortadanTasKaldir(tasresim);
                }
            }
        }


        void ortadanTasKaldir(string resimBit)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Bitmap bitmap = (Bitmap)dominatas[i, j].Image;
                    if (bitmap != null)
                    {
                        System.IO.MemoryStream stream = new System.IO.MemoryStream();
                        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] tasv = stream.ToArray();
                        string tasresim = Convert.ToBase64String(tasv);
                        if (tasresim == resimBit)
                        {
                            dominatas[i, j].Image = null;
                        }
                    }


                }
            }

        }
        bool Oyuncu2yerKontrol(int x, int y)
        {
            if (player2Tahta[x, y].Image != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        bool Oyuncu1yerKontrol(int x, int y)
        {
            if (player1Tahta[x, y].Image != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        void oyuncu1kaldır(string resimBit)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Bitmap bitmap = (Bitmap)player1Tahta[i, j].Image;
                    if (bitmap != null)
                    {
                        System.IO.MemoryStream stream = new System.IO.MemoryStream();
                        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] tasv = stream.ToArray();
                        string tasresim = Convert.ToBase64String(tasv);
                        if (tasresim == resimBit)
                        {
                            player1Tahta[i, j].Image = null;
                        }
                    }



                }

            }
        }
        void oyuncu2kaldır(string resimBit)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Bitmap bitmap = (Bitmap)player2Tahta[i, j].Image;
                    if (bitmap != null)
                    {
                        System.IO.MemoryStream stream = new System.IO.MemoryStream();
                        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] tasv = stream.ToArray();
                        string tasresim = Convert.ToBase64String(tasv);
                        if (tasresim == resimBit)
                        {
                            player2Tahta[i, j].Image = null;
                        }
                    }

                }

            }
        }
    }
}
