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

        private bool turXde;
        private string[,] matrisTahta;
        private int N=3;
        private int Nkosul;
        private bool dur;

        private void OyunTahtasiniOlustur(TableLayoutPanel tahta, int en, int boy)
        {
            // Bunlar ana işlevle alakasız ancak her yeni oyunda atanmaları gerekli.
            matrisTahta = new string[en,boy];
            dur = false;
            turXde = false;
            if(N >= 5)  Nkosul = 5;
            else        Nkosul = N;

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
                    Button kare = new Button
                    {
                        Dock = DockStyle.Fill,
                        Tag = new Point(i,j),
                        Margin = new Padding(0),
                        Font = new Font("Arial",fontBoyutu,FontStyle.Regular),
                        BackColor = Color.PaleTurquoise
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


    }
}
