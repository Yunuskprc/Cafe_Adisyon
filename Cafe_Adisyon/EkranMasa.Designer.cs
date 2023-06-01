namespace Cafe_Adisyon
{
    partial class EkranMasa
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
            if (disposing && (components != null))
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            lblDate = new Label();
            lblYEDAdisyonSistemi = new Label();
            pctbxYEDLogo = new PictureBox();
            panel2 = new Panel();
            btnStok = new Button();
            btnGuncelleme = new Button();
            btnGrafik = new Button();
            btnMenu = new Button();
            btnMasa = new Button();
            pnlMasa1 = new Panel();
            lblMasaPnl1MasaAd = new Label();
            pnlMasa4 = new Panel();
            btnOdemeKart = new Button();
            btnOdemeNakit = new Button();
            btnOdemeQR = new Button();
            label2 = new Label();
            lblMasaPnl4Toplam = new Label();
            panel4 = new Panel();
            TimerDate = new System.Windows.Forms.Timer(components);
            pnlMain = new Panel();
            timerUpdate = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).BeginInit();
            panel2.SuspendLayout();
            pnlMasa1.SuspendLayout();
            pnlMasa4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblDate);
            panel1.Controls.Add(lblYEDAdisyonSistemi);
            panel1.Controls.Add(pctbxYEDLogo);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 30);
            panel1.TabIndex = 3;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDate.Location = new Point(267, 4);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(176, 23);
            lblDate.TabIndex = 3;
            lblDate.Text = "19.10.2002-23.01.01";
            lblDate.Visible = false;
            // 
            // lblYEDAdisyonSistemi
            // 
            lblYEDAdisyonSistemi.AutoSize = true;
            lblYEDAdisyonSistemi.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblYEDAdisyonSistemi.Location = new Point(70, 4);
            lblYEDAdisyonSistemi.Name = "lblYEDAdisyonSistemi";
            lblYEDAdisyonSistemi.Size = new Size(172, 23);
            lblYEDAdisyonSistemi.TabIndex = 2;
            lblYEDAdisyonSistemi.Text = "YED Adisyon Sistemi";
            // 
            // pctbxYEDLogo
            // 
            pctbxYEDLogo.Image = Properties.Resources.YEDLogo30px;
            pctbxYEDLogo.Location = new Point(0, 0);
            pctbxYEDLogo.Name = "pctbxYEDLogo";
            pctbxYEDLogo.Size = new Size(30, 30);
            pctbxYEDLogo.TabIndex = 1;
            pctbxYEDLogo.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnStok);
            panel2.Controls.Add(btnGuncelleme);
            panel2.Controls.Add(btnGrafik);
            panel2.Controls.Add(btnMenu);
            panel2.Controls.Add(btnMasa);
            panel2.Location = new Point(0, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(100, 1050);
            panel2.TabIndex = 4;
            // 
            // btnStok
            // 
            btnStok.BackgroundImage = Properties.Resources.StockProduct;
            btnStok.FlatAppearance.BorderSize = 0;
            btnStok.FlatStyle = FlatStyle.Flat;
            btnStok.Location = new Point(0, 318);
            btnStok.Name = "btnStok";
            btnStok.Size = new Size(100, 100);
            btnStok.TabIndex = 7;
            btnStok.UseVisualStyleBackColor = true;
            btnStok.Click += btnStok_Click;
            // 
            // btnGuncelleme
            // 
            btnGuncelleme.BackgroundImage = Properties.Resources.updateProduct;
            btnGuncelleme.FlatAppearance.BorderSize = 0;
            btnGuncelleme.FlatStyle = FlatStyle.Flat;
            btnGuncelleme.Location = new Point(-1, 212);
            btnGuncelleme.Name = "btnGuncelleme";
            btnGuncelleme.Size = new Size(100, 100);
            btnGuncelleme.TabIndex = 5;
            btnGuncelleme.UseVisualStyleBackColor = true;
            btnGuncelleme.Click += btnGuncelleme_Click;
            // 
            // btnGrafik
            // 
            btnGrafik.BackgroundImage = Properties.Resources.graphics;
            btnGrafik.FlatAppearance.BorderSize = 0;
            btnGrafik.FlatStyle = FlatStyle.Flat;
            btnGrafik.Location = new Point(0, 424);
            btnGrafik.Name = "btnGrafik";
            btnGrafik.Size = new Size(100, 100);
            btnGrafik.TabIndex = 4;
            btnGrafik.UseVisualStyleBackColor = true;
            btnGrafik.Click += btnGrafik_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackgroundImage = Properties.Resources.Menu;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Location = new Point(0, 106);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(100, 100);
            btnMenu.TabIndex = 3;
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnMasa
            // 
            btnMasa.BackgroundImage = Properties.Resources.Masa;
            btnMasa.FlatAppearance.BorderSize = 0;
            btnMasa.FlatStyle = FlatStyle.Flat;
            btnMasa.Location = new Point(0, 0);
            btnMasa.Name = "btnMasa";
            btnMasa.Size = new Size(100, 100);
            btnMasa.TabIndex = 2;
            btnMasa.TextAlign = ContentAlignment.TopCenter;
            btnMasa.UseVisualStyleBackColor = true;
            btnMasa.Click += btnMasa_Click;
            // 
            // pnlMasa1
            // 
            pnlMasa1.BorderStyle = BorderStyle.FixedSingle;
            pnlMasa1.Controls.Add(lblMasaPnl1MasaAd);
            pnlMasa1.Controls.Add(pnlMasa4);
            pnlMasa1.Controls.Add(panel4);
            pnlMasa1.Location = new Point(100, 30);
            pnlMasa1.Name = "pnlMasa1";
            pnlMasa1.Size = new Size(350, 1050);
            pnlMasa1.TabIndex = 10;
            pnlMasa1.Visible = false;
            // 
            // lblMasaPnl1MasaAd
            // 
            lblMasaPnl1MasaAd.AutoSize = true;
            lblMasaPnl1MasaAd.Font = new Font("Calibri", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblMasaPnl1MasaAd.Location = new Point(78, 786);
            lblMasaPnl1MasaAd.Name = "lblMasaPnl1MasaAd";
            lblMasaPnl1MasaAd.Size = new Size(193, 59);
            lblMasaPnl1MasaAd.TabIndex = 8;
            lblMasaPnl1MasaAd.Text = "Masa 15";
            lblMasaPnl1MasaAd.Visible = false;
            // 
            // pnlMasa4
            // 
            pnlMasa4.BackColor = SystemColors.ButtonFace;
            pnlMasa4.BorderStyle = BorderStyle.FixedSingle;
            pnlMasa4.Controls.Add(btnOdemeKart);
            pnlMasa4.Controls.Add(btnOdemeNakit);
            pnlMasa4.Controls.Add(btnOdemeQR);
            pnlMasa4.Controls.Add(label2);
            pnlMasa4.Controls.Add(lblMasaPnl4Toplam);
            pnlMasa4.Location = new Point(0, 862);
            pnlMasa4.Name = "pnlMasa4";
            pnlMasa4.Size = new Size(350, 149);
            pnlMasa4.TabIndex = 7;
            pnlMasa4.Visible = false;
            // 
            // btnOdemeKart
            // 
            btnOdemeKart.BackgroundImage = Properties.Resources.pos;
            btnOdemeKart.FlatAppearance.BorderSize = 0;
            btnOdemeKart.FlatStyle = FlatStyle.Flat;
            btnOdemeKart.Location = new Point(136, 74);
            btnOdemeKart.Name = "btnOdemeKart";
            btnOdemeKart.Size = new Size(70, 70);
            btnOdemeKart.TabIndex = 6;
            btnOdemeKart.UseVisualStyleBackColor = true;
            // 
            // btnOdemeNakit
            // 
            btnOdemeNakit.BackgroundImage = Properties.Resources.cash;
            btnOdemeNakit.FlatAppearance.BorderSize = 0;
            btnOdemeNakit.FlatStyle = FlatStyle.Flat;
            btnOdemeNakit.ForeColor = SystemColors.ControlText;
            btnOdemeNakit.Location = new Point(36, 74);
            btnOdemeNakit.Name = "btnOdemeNakit";
            btnOdemeNakit.Size = new Size(70, 70);
            btnOdemeNakit.TabIndex = 5;
            btnOdemeNakit.UseVisualStyleBackColor = true;
            // 
            // btnOdemeQR
            // 
            btnOdemeQR.BackgroundImage = Properties.Resources.qr_code;
            btnOdemeQR.FlatAppearance.BorderSize = 0;
            btnOdemeQR.FlatStyle = FlatStyle.Flat;
            btnOdemeQR.Location = new Point(243, 74);
            btnOdemeQR.Name = "btnOdemeQR";
            btnOdemeQR.Size = new Size(70, 70);
            btnOdemeQR.TabIndex = 4;
            btnOdemeQR.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(187, 11);
            label2.Name = "label2";
            label2.Size = new Size(46, 39);
            label2.TabIndex = 1;
            label2.Text = "TL";
            // 
            // lblMasaPnl4Toplam
            // 
            lblMasaPnl4Toplam.AutoSize = true;
            lblMasaPnl4Toplam.Font = new Font("Calibri", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblMasaPnl4Toplam.Location = new Point(116, 11);
            lblMasaPnl4Toplam.Name = "lblMasaPnl4Toplam";
            lblMasaPnl4Toplam.Size = new Size(65, 39);
            lblMasaPnl4Toplam.TabIndex = 0;
            lblMasaPnl4Toplam.Text = "300";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonHighlight;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(350, 130);
            panel4.TabIndex = 6;
            // 
            // TimerDate
            // 
            TimerDate.Interval = 1000;
            TimerDate.Tick += TimerDate_Tick;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = SystemColors.ActiveCaption;
            pnlMain.Location = new Point(450, 30);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1459, 1050);
            pnlMain.TabIndex = 11;
            // 
            // timerUpdate
            // 
            timerUpdate.Interval = 60000;
            timerUpdate.Tick += timerUpdate_Tick;
            // 
            // EkranMasa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(pnlMain);
            Controls.Add(pnlMasa1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "EkranMasa";
            StartPosition = FormStartPosition.CenterParent;
            Text = "EkranMasa";
            Load += EkranMasa_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).EndInit();
            panel2.ResumeLayout(false);
            pnlMasa1.ResumeLayout(false);
            pnlMasa1.PerformLayout();
            pnlMasa4.ResumeLayout(false);
            pnlMasa4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblDate;
        private Label lblYEDAdisyonSistemi;
        private PictureBox pctbxYEDLogo;
        private Panel panel2;
        private Button btnStok;
        private Button btnGuncelleme;
        private Button btnGrafik;
        private Button btnMenu;
        private Button btnMasa;
        private Panel pnlMasa1;
        private Label lblMasaPnl1MasaAd;
        private Panel pnlMasa4;
        private Button btnOdemeKart;
        private Button btnOdemeNakit;
        private Button btnOdemeQR;
        private Label label2;
        private Label lblMasaPnl4Toplam;
        private Panel panel4;
        private System.Windows.Forms.Timer TimerDate;
        private Panel pnlMain;
        private System.Windows.Forms.Timer timerUpdate;
    }
}