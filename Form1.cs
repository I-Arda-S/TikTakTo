using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            OyunTahtasiniOlustur(tictac, 3, 3);
        }

        private bool turXde = false;
        private string[,] matrisTahta;
        private int N=3;
        private bool dur;

        private void OyunTahtasiniOlustur(TableLayoutPanel tahta, int en, int boy)
        {
            tahta.Controls.Clear();
            tahta.RowStyles.Clear();
            tahta.ColumnStyles.Clear();
            matrisTahta = new string[en, boy];
            dur = false;

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
                    Button kare = new Button
                    {
                        Dock = DockStyle.Fill,
                        Tag = new Point(i,j),
                        Margin = new Padding(0),
                        Font = new Font("Arial",fontBoyutu,FontStyle.Regular),
                        BackColor = Color.Brown
                    };
                    //if((j%2==0 && i%2==0) || (j%2!=0 && i%2!=0))
                    //kare.Text = "X";
                    //kare.BackColor = Color.SandyBrown;

                    kare.Click += Kare_click;
                    tahta.Controls.Add(kare,j,i);
                }
            }
        }

        private void btnSifirla_Click(object sender,EventArgs e)
        {
            N = BoyutSec.SelectedIndex+3;
            turXde = false;
            OyunTahtasiniOlustur(tictac,N,N);
        }

        private void Kare_click(object sender, EventArgs e)
        {
            if(dur) return;

            Button kare = sender as Button;
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

            if(KontrolEt(x,y,kare.Text))
            {
                MessageBox.Show("Kazandın.");
                dur=true;
            }
                
            kare.Enabled = false;
        }

        private bool KontrolEt(int satir,int sutun,string isaret)
        {
            int kazanmakİcinGerekenKareSayisi = N; // Mesela 3x3'te ardışık 3 tane aynı olunca kazanılır ya onu kast ettim. Çok kare olduuğnda da 5'i koşul sağlamak standart imiş.
            if(N>5)
                kazanmakİcinGerekenKareSayisi=5;

            if(YatayKontrol(satir,isaret,kazanmakİcinGerekenKareSayisi)) 
                return true;
            if(DikeyKontrol(sutun,isaret,kazanmakİcinGerekenKareSayisi)) 
                return true;
            if(CaprazKontrol(satir,sutun,isaret,kazanmakİcinGerekenKareSayisi)) 
                return true;

            return false;
        }
        /*private string GetCellText(int r,int c)
        {
            var ctrl = tableLayoutPanel1.GetControlFromPosition(c,r);
            return ctrl?.Text ?? "";
        }*/
        private bool DikeyKontrol(int sutun,string isaret,int gerekenSira)
        {
            int sayac = 0;
            for(int i = 0;i < N;i++)
            {
                if(matrisTahta[i,sutun] == isaret)
                {
                    sayac++;
                    if(sayac == gerekenSira) return true;
                }
                else
                    sayac = 0;

            }
            return false;
        }
        private bool YatayKontrol(int satir,string isaret, int gerekenSira)
        {
            int sayac = 0;
            for(int j=0;j<N;j++)
            {
                if(matrisTahta[satir,j] == isaret)
                {
                    sayac++;
                    if(sayac==gerekenSira) return true;
                }
                else
                    sayac = 0;
            }
            return false;
        }
        private bool CaprazKontrol(int x, int y, string isaret, int gerekenSira)
        {
            if(KareleriSay(x,y,-1,-1,isaret) + KareleriSay(x,y,1,1,isaret) + 1 >= gerekenSira) 
                return true; // '\'

            if(KareleriSay(x,y,-1,1,isaret) + KareleriSay(x,y,1,-1,isaret) + 1 >= gerekenSira) 
                return true; // '/'

            // Yatay ve Dikeyi de buna benzer şekilde kontrol edebilirmiş, gerekirse onları buna uyarla.

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

        /*private bool CaprazBak(string isaret)
        {
            bool solUst = true;
            for(int i = 0;i < tableLayoutPanel1.RowCount;i++)
            {
                if(GetCellText(i,i) != isaret) solUst = false;
            }
            // Sağ üstten sol alta olan diğer çaprazı da benzer şekilde kontrol etmelisin
            return solUst;
        }*/

    }
}
