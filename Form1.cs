using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Satranc
{
    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
            BoyutSec.SelectedIndex = 0;
            ZorlukSec.SelectedIndex = 0; zorluk = ZorlukSec.SelectedIndex;
            OyunTahtasiniOlustur(tictac, 3, 3);

            matrisiTexteAktar();//geçici
        }

        private bool turXde;
        private string[,] matrisTahta;
        private List<Point> bosKareler = new List<Point>();
        private int N=3;        // Kalan başlatıcıları OyunTahtasıOluştur halledecek
        private int Nkosul;
        private bool dur;
        private int zorluk;

        private Point sonHamleKonumu;

        public class GameButton:Button
        {
            public GameButton()
            {
                this.SetStyle(ControlStyles.Selectable,false);
                this.Margin = new Padding(1);
                this.Dock = DockStyle.Fill;
                this.FlatStyle = FlatStyle.Flat;
                this.BackColor = Color.PaleTurquoise;
                this.FlatAppearance.BorderSize = 0;
                this.NotifyDefault(false);

            }

        }

        private void OyunTahtasiniOlustur(TableLayoutPanel tahta, int en, int boy)
        {
            // Bunlar ana işlevle alakasız ancak her yeni oyunda atanmaları gerekli.
            matrisTahta = new string[en,boy];
            bosKareler.Clear();
            dur = false;
            turXde = false;
            if(N >= 5)  Nkosul = 5;
            else        Nkosul = N;

            // Ana işlev işte paneli tuşlarla dolduran
            tahta.Controls.Clear();
            tahta.RowStyles.Clear();
            tahta.ColumnStyles.Clear();

            tahta.RowCount = 0;
            tahta.ColumnCount = 0;
            for(int i = 0;i < boy;i++)
                tahta.RowStyles.Add(new RowStyle(SizeType.Percent,100f / boy));
            for(int j = 0;j < en;j++)
                tahta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100f / en));
            tahta.RowCount = boy;
            tahta.ColumnCount = en;

            float fontBoyutu = tahta.Height / tahta.ColumnCount * 0.4f;
            for(int i = 0; i<tahta.ColumnCount;i++)
            {
                for(int j = 0; j<tahta.RowCount;j++)
                {
                    GameButton kare = new GameButton
                    {
                        Font = new Font("Consolas",fontBoyutu,FontStyle.Regular),
                    };

                    kare.Click += Kare_click;
                    tahta.Controls.Add(kare,j,i);
                    bosKareler.Add(new Point(i,j));
                }
            }
        }

        private void btnSifirla_Click(object sender,EventArgs e)
        {
            N = BoyutSec.SelectedIndex+3;
            OyunTahtasiniOlustur(tictac,N,N);

            zorluk = ZorlukSec.SelectedIndex;

            matrisiTexteAktar(); // geçici
        }

        private void Kare_click(object sender, EventArgs e)
        {
            if(dur) return; 

            GameButton kare = sender as GameButton;
            var konum = tictac.GetPositionFromControl(kare);
            int x = konum.Row; 
            int y = konum.Column;

            if(turXde)
            {
                kare.Text = "X";
                matrisTahta[x,y] = "X";
            }
            else
            {
                kare.Text = "O";
                matrisTahta[x,y] = "O";
            }
            turXde = !turXde;
            bosKareler.Remove(new Point(x,y)); lblKontrol.Text = bosKareler.Count.ToString();
            kare.Enabled = false;

            matrisiTexteAktar(); // geçici

            if(KontrolEt(x,y,kare.Text))
            {
                dur=true;
                MessageBox.Show("'"+kare.Text+"' kazandı.","Zafer",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if(bosKareler.Count == 0)
            {
                dur = true;
                MessageBox.Show("Oyun bitti.","Berabere",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            sonHamleKonumu.X = x;
            sonHamleKonumu.Y = y;
            if(turXde)
                botHamleYapiyor(); // 'O' oynanır oynanmaz botHamle yapsın, kapalıyken bir şey olmaz zaten.
            
        }

        private bool KontrolEt(int x, int y, string isaret)
        {
            if(KareleriSay(x,y,-1,-1,isaret) + KareleriSay(x,y,1,1,isaret) + 1 >= Nkosul) return true; // '\'


            if(KareleriSay(x,y,-1,1,isaret) + KareleriSay(x,y,1,-1,isaret) + 1 >= Nkosul) return true; // '/'


            if(KareleriSay(x,y,-1,0,isaret) + KareleriSay(x,y,1,0,isaret) + 1 >= Nkosul) return true; // Dikey

            if(KareleriSay(x,y,0,-1,isaret) + KareleriSay(x,y,0,1,isaret) + 1 >= Nkosul) return true; // Yatay


            return false;
        }
        private int KareleriSay(int x, int y, int dx, int dy, string isaret)
        {
            int sayac = 0;
            int nx = x + dx;
            int ny = y + dy;

            while(nx >= 0 && nx<N && ny >= 0 && ny<N && matrisTahta[nx,ny]==isaret)
            {
                sayac++;
                nx += dx;
                ny += dy;
            }
            return sayac;
        }

        private void matrisiTexteAktar()// Tahta ve matris uyumlu mu diye kontrol etmek için, işim bitince kaldırıcam.
        {
            matrisiGor.Text = string.Empty;
            for(int i=0; i<N;i++)
            {
                for(int j=0; j<N;j++)
                {
                    if(matrisTahta[i,j]==null)
                        matrisiGor.Text += "-";
                    else
                        matrisiGor.Text += matrisTahta[i,j];
                } 
                matrisiGor.Text += Environment.NewLine;
            }
        }

        private bool botHamleYapiyor()
        {
            if(zorluk==0) return false;
            else if(zorluk==1) BotRastgeleOynar();
            else if(zorluk==2) BotKolayOynar();

                return true;
        }

        private void BotRastgeleOynar()
        {
            if(bosKareler.Count==0) return;

            Random rng = new Random();
            int hedefKare = rng.Next(0, bosKareler.Count);
            int sx = bosKareler[hedefKare].X;
            int sy = bosKareler[hedefKare].Y;

            Control c = tictac.GetControlFromPosition(sy,sx);
            if(c is GameButton buton)
            {
                Kare_click(c,EventArgs.Empty);
            }
            matrisiTexteAktar(); // geçici
        }

        private void BotKolayOynar() // Bitişik mi kontrolleri yapıyom mesela bitişik 2 yerine boşluklu 2 koyunca fark etmeycek
        {
            if(bosKareler.Count==0) return;

            int uyari1;
            if(N <= 5) uyari1 = Nkosul;
            else uyari1 = Nkosul-1;     // N 5'ten büyükken 3.kareden itibaren engellesin 4 değilde.

            /*if(KareleriSay(x,y,-1,-1,isaret) + KareleriSay(x,y,1,1,isaret) + 1 >= Nkosul) return true; // '\'
            if(KareleriSay(x,y,-1,1,isaret) + KareleriSay(x,y,1,-1,isaret) + 1 >= Nkosul) return true; // Bunlara göre çapraz kuralını eklicem */

            if(KareleriSay(sonHamleKonumu.X,sonHamleKonumu.Y,0,-1,"O") + KareleriSay(sonHamleKonumu.X,sonHamleKonumu.Y,0,1,"O") + 2 >= uyari1)
            {
                // Yatayda hamle yapçak, X konumunu sabit tutup uygun bir Y seçmeli.
                var bulunanNoktalar = bosKareler.Where(p => p.X == sonHamleKonumu.X).ToList();
                Random rng = new Random();
                Point hedefNokta = new Point(); // Seçilen noktayı tutmak için

                if(bulunanNoktalar.Count <= 2)
                {
                    // Elimizde zaten 0, 1 veya 2 nokta varsa doğrudan bunlardan birini seç
                    if(bulunanNoktalar.Count > 0)
                    {
                        int i = rng.Next(0,bulunanNoktalar.Count);
                        hedefNokta = bulunanNoktalar[i];
                    }
                }
                else
                {
                    // Hedefe en yakın alt ve üst komşuları bul
                    var ustKomsu = bulunanNoktalar.Where(p => p.Y > sonHamleKonumu.Y).OrderBy(p => p.Y).Cast<Point?>().FirstOrDefault();
                    var altKomsu = bulunanNoktalar.Where(p => p.Y < sonHamleKonumu.Y).OrderByDescending(p => p.Y).Cast<Point?>().FirstOrDefault();

                    // Sadece bulunanları (null olmayanları) yeni bir listeye al
                    var komsuListesi = new List<Point?> { ustKomsu,altKomsu }.Where(p => p.HasValue).Select(p => p.Value).ToList();

                    // Bu iki komşudan birini rastgele seç
                    if(komsuListesi.Count > 0)
                    {
                        hedefNokta = komsuListesi[rng.Next(0,komsuListesi.Count)];
                    }
                } // Olmadı tam, başka yöntemlere bak, rastgele indis seçme kullanmasam iyi olucak sorun ondan başlıyo

                try
                {
                    Control c = tictac.GetControlFromPosition(hedefNokta.Y ,sonHamleKonumu.X);
                    if(c is GameButton btn) Kare_click(c,EventArgs.Empty);
                }
                catch { BotRastgeleOynar(); }

            }
            else if(KareleriSay(sonHamleKonumu.X,sonHamleKonumu.Y,-1,0,"O") + KareleriSay(sonHamleKonumu.X,sonHamleKonumu.Y,1,0,"O") + 2 >= uyari1)
            { // Dikeyde, ters işte
                var bulunanNoktalar = bosKareler.Where(p => p.Y == sonHamleKonumu.Y).ToList();
                Random rng = new Random();
                int xHedef = rng.Next(0,bulunanNoktalar.Count); 

                try
                {
                    Control c = tictac.GetControlFromPosition(sonHamleKonumu.Y,bulunanNoktalar[xHedef].X);
                    if(c is GameButton btn) Kare_click(c,EventArgs.Empty);
                }
                catch { BotRastgeleOynar(); }


            }
            else
                BotRastgeleOynar();

            matrisiTexteAktar();
            /*
            Ardışık 2 (N-1) tane olunca engelle
            Bunların arasında 1 boşluk olursa engelle -farklı zorluk ayarı olur-
            Rastgele oyna, gibi bir şey planlıyom algoritmasında
            */
        }

    }
}
