namespace Satranc
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tictac = new System.Windows.Forms.TableLayoutPanel();
            this.btnSifirla = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BoyutSec = new System.Windows.Forms.ComboBox();
            this.ZorlukSec = new System.Windows.Forms.ComboBox();
            this.matrisiGor = new System.Windows.Forms.TextBox();
            this.lblKontrol = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tictac
            // 
            this.tictac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tictac.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tictac.ColumnCount = 1;
            this.tictac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.Location = new System.Drawing.Point(168, 12);
            this.tictac.Name = "tictac";
            this.tictac.RowCount = 1;
            this.tictac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tictac.Size = new System.Drawing.Size(418, 418);
            this.tictac.TabIndex = 0;
            // 
            // btnSifirla
            // 
            this.btnSifirla.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSifirla.Location = new System.Drawing.Point(13, 69);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(121, 69);
            this.btnSifirla.TabIndex = 2;
            this.btnSifirla.Text = "Sıfırla";
            this.btnSifirla.UseVisualStyleBackColor = true;
            this.btnSifirla.Click += new System.EventHandler(this.btnSifirla_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.lblKontrol);
            this.panel1.Controls.Add(this.matrisiGor);
            this.panel1.Controls.Add(this.ZorlukSec);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BoyutSec);
            this.panel1.Controls.Add(this.btnSifirla);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 419);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ayarlar";
            // 
            // BoyutSec
            // 
            this.BoyutSec.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BoyutSec.FormattingEnabled = true;
            this.BoyutSec.Items.AddRange(new object[] {
            "3x3",
            "4x4",
            "5x5",
            "6x6",
            "7x7",
            "8x8",
            "9x9"});
            this.BoyutSec.Location = new System.Drawing.Point(13, 39);
            this.BoyutSec.Name = "BoyutSec";
            this.BoyutSec.Size = new System.Drawing.Size(121, 26);
            this.BoyutSec.TabIndex = 1;
            // 
            // ZorlukSec
            // 
            this.ZorlukSec.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ZorlukSec.FormattingEnabled = true;
            this.ZorlukSec.Items.AddRange(new object[] {
            "Yok",
            "Rastgele Hamle Yapar"});
            this.ZorlukSec.Location = new System.Drawing.Point(13, 144);
            this.ZorlukSec.Name = "ZorlukSec";
            this.ZorlukSec.Size = new System.Drawing.Size(121, 26);
            this.ZorlukSec.TabIndex = 4;
            // 
            // matrisiGor
            // 
            this.matrisiGor.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.matrisiGor.Location = new System.Drawing.Point(13, 289);
            this.matrisiGor.Multiline = true;
            this.matrisiGor.Name = "matrisiGor";
            this.matrisiGor.ReadOnly = true;
            this.matrisiGor.Size = new System.Drawing.Size(121, 115);
            this.matrisiGor.TabIndex = 3;
            // 
            // lblKontrol
            // 
            this.lblKontrol.AutoSize = true;
            this.lblKontrol.Location = new System.Drawing.Point(20, 190);
            this.lblKontrol.Name = "lblKontrol";
            this.lblKontrol.Size = new System.Drawing.Size(44, 16);
            this.lblKontrol.TabIndex = 3;
            this.lblKontrol.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 443);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tictac);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(770, 490);
            this.Name = "Form1";
            this.Text = "TikTakTo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tictac;
        private System.Windows.Forms.Button btnSifirla;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox BoyutSec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ZorlukSec;
        private System.Windows.Forms.TextBox matrisiGor;
        private System.Windows.Forms.Label lblKontrol;
    }
}

