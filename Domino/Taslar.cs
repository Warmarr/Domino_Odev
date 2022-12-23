using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Domino
{
    internal class Taslar:Game
    {
        PictureBox[,] dominatas;
        System.Windows.Forms.Button karistir;
        System.Windows.Forms.Button dağit;
        List<Image> tasResimler = new List<Image>();
        List<Image> taslarr = new List<Image>();
        Random rndy = new Random();
        Random rndx = new Random();
        public Taslar(PictureBox[,] dominatas, PictureBox[,] player1, PictureBox[,] player2,PictureBox[,] tasl, List<Image> tasResim, System.Windows.Forms.Button karistir, System.Windows.Forms.Button dağit)
            : base(dominatas, player1, player2)
            
        {
            this.dominatas = tasl;
            tasResimler = tasResim;
            this.karistir = karistir;
            this.dağit = dağit;
            this.karistir.Click += Karistir_Click;
            this.dağit.Click += Dağit_Click;
            tasOlustur();
        }
        private void Dağit_Click(object sender, EventArgs e)
        {
            tasDagit();
        }

        private void Karistir_Click(object sender, EventArgs e)
        {
            karistir(taslarr);
            oyuncu1Dagit();
            dağit.Visible = true;
            
        }
        public void tasOlustur()
        {

            while(tasResimler.Count > 0)
            {
                int x = rndx.Next(0, 30); //Rastgele x koordinatı alıyor
                int y = rndy.Next(0, 30); //Rastgele y koordinatı alıyor
                int tasİndex = rndx.Next(0, tasResimler.Count);
                if (yerKontrol(x, y))
                {
                    dominatas[x, y].Image = tasResimler[tasİndex];
                    taslarr.Add(tasResimler[tasİndex]);                   
                    tasResimler.Remove(tasResimler[tasİndex]);
                }
                
            }
           
         
        }
        bool yerKontrol(int x,int y)
        {
           
            if (dominatas[x,y].Image != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
