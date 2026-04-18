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
        private int N=3;        // Kalan başlatıcıları OyunTahtasıOluştur halledecek
        private int Nkosul;
        private bool dur;
        private int zorluk;

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
                        Font = new Font("Consolas",fontBoyutu,FontStyle.Regular)
                    };

                    kare.Click += Kare_click;
                    tahta.Controls.Add(kare,j,i);
                }
            }
        }

        private void btnSifirla_Click(object sender,EventArgs e)
        {
            tmrBotHamle.Enabled = false;

            N = BoyutSec.SelectedIndex+3;
            OyunTahtasiniOlustur(tictac,N,N);

            zorluk = ZorlukSec.SelectedIndex;
            botuAktiflestir();

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
                turXde = false;


            }
            else
            {
                kare.Text = "O";
                matrisTahta[x,y] = "O";
                turXde = true;

            }

            kare.Enabled = false;

            matrisiTexteAktar(); // geçici

            if(KontrolEt(x,y,kare.Text))
            {
                dur=true; 
                MessageBox.Show("'"+kare.Text+"' kazandı.","Zafer",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
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

        private bool botuAktiflestir()
        {
            if(zorluk==0)
            {
                tmrBotHamle.Enabled = false;
                return false;
            }
            else
            {
                tmrBotHamle.Enabled = true;
                return true;
            }

        }

        private void BotRastgeleOynar()
        {
            List<Point> hamleyeMusait = new List<Point>(); // Buna her seferinde bakmasına gerek yok, tıklama yapıldıkça değişçek şekilde düzenleyeyim sonra
            for(int i=0; i<N;i++)
            {
                for(int j=0;j<N; j++)
                {
                    if(matrisTahta[i,j]==null)
                        hamleyeMusait.Add(new Point(i,j));
                }
            }
            if(hamleyeMusait.Count==0) return;

            Random rng = new Random();
            int defaHamleYap = rng.Next(0, hamleyeMusait.Count);
            int sx = hamleyeMusait[defaHamleYap].X;
            int sy = hamleyeMusait[defaHamleYap].Y;

            Control c = tictac.GetControlFromPosition(sy,sx);
            if(c is GameButton buton)
            {
                Kare_click(c,EventArgs.Empty);
            }
            matrisiTexteAktar(); // geçici
        }

        private void tmrBotHamle_Tick(object sender,EventArgs e) // Oyuncu yeterince hızlı basarsa timer tetiklenmeden bot yerine hamle yapmış olucak. Şimdilik aralık değerini düşürdüm bu yüzden.
        {
            if(turXde)
            {
                if(zorluk==1) // Rastgele
                {
                    BotRastgeleOynar();
                    turXde = false;
                }
            }
            else
                return;

        }
    }
}
