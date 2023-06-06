namespace Cafe_Adisyon
{
    partial class EkranSatisTakip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EkranSatisTakip));
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
            timer1 = new System.Windows.Forms.Timer(components);
            pnlGenelBilgiler = new Panel();
            btnGunlukSatis = new Button();
            btnAylikSatis = new Button();
            btnTumZamanlarSatis = new Button();
            lblSatilanUrunAdet = new Label();
            label4 = new Label();
            lblToplamCiro = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).BeginInit();
            panel2.SuspendLayout();
            pnlGenelBilgiler.SuspendLayout();
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
            panel1.TabIndex = 8;
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
            panel2.TabIndex = 9;
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
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // pnlGenelBilgiler
            // 
            pnlGenelBilgiler.BackColor = Color.FromArgb(26, 24, 51);
            pnlGenelBilgiler.BackgroundImage = (Image)resources.GetObject("pnlGenelBilgiler.BackgroundImage");
            pnlGenelBilgiler.Controls.Add(btnGunlukSatis);
            pnlGenelBilgiler.Controls.Add(btnAylikSatis);
            pnlGenelBilgiler.Controls.Add(btnTumZamanlarSatis);
            pnlGenelBilgiler.Controls.Add(lblSatilanUrunAdet);
            pnlGenelBilgiler.Controls.Add(label4);
            pnlGenelBilgiler.Controls.Add(lblToplamCiro);
            pnlGenelBilgiler.Controls.Add(label1);
            pnlGenelBilgiler.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            pnlGenelBilgiler.Location = new Point(190, 115);
            pnlGenelBilgiler.Name = "pnlGenelBilgiler";
            pnlGenelBilgiler.Size = new Size(520, 330);
            pnlGenelBilgiler.TabIndex = 10;
            // 
            // btnGunlukSatis
            // 
            btnGunlukSatis.FlatAppearance.BorderColor = Color.White;
            btnGunlukSatis.FlatStyle = FlatStyle.Flat;
            btnGunlukSatis.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnGunlukSatis.ForeColor = SystemColors.ButtonFace;
            btnGunlukSatis.Location = new Point(370, 230);
            btnGunlukSatis.Name = "btnGunlukSatis";
            btnGunlukSatis.Size = new Size(120, 31);
            btnGunlukSatis.TabIndex = 6;
            btnGunlukSatis.Text = "Günlük Satış";
            btnGunlukSatis.UseVisualStyleBackColor = true;
            btnGunlukSatis.Click += btnGunlukSatis_Click;
            // 
            // btnAylikSatis
            // 
            btnAylikSatis.FlatAppearance.BorderColor = Color.White;
            btnAylikSatis.FlatStyle = FlatStyle.Flat;
            btnAylikSatis.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAylikSatis.ForeColor = SystemColors.ButtonFace;
            btnAylikSatis.Location = new Point(370, 150);
            btnAylikSatis.Name = "btnAylikSatis";
            btnAylikSatis.Size = new Size(120, 31);
            btnAylikSatis.TabIndex = 5;
            btnAylikSatis.Text = "Aylık Satış";
            btnAylikSatis.UseVisualStyleBackColor = true;
            btnAylikSatis.Click += btnAylikSatis_Click;
            // 
            // btnTumZamanlarSatis
            // 
            btnTumZamanlarSatis.FlatAppearance.BorderColor = Color.White;
            btnTumZamanlarSatis.FlatStyle = FlatStyle.Flat;
            btnTumZamanlarSatis.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnTumZamanlarSatis.ForeColor = SystemColors.ButtonFace;
            btnTumZamanlarSatis.Location = new Point(370, 70);
            btnTumZamanlarSatis.Name = "btnTumZamanlarSatis";
            btnTumZamanlarSatis.Size = new Size(120, 31);
            btnTumZamanlarSatis.TabIndex = 4;
            btnTumZamanlarSatis.Text = "Tüm Zamanlar";
            btnTumZamanlarSatis.UseVisualStyleBackColor = true;
            btnTumZamanlarSatis.Click += btnTumZamanlarSatis_Click;
            // 
            // lblSatilanUrunAdet
            // 
            lblSatilanUrunAdet.AutoSize = true;
            lblSatilanUrunAdet.Font = new Font("Segoe UI Symbol", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblSatilanUrunAdet.ForeColor = SystemColors.ButtonFace;
            lblSatilanUrunAdet.Location = new Point(43, 216);
            lblSatilanUrunAdet.Name = "lblSatilanUrunAdet";
            lblSatilanUrunAdet.Size = new Size(109, 65);
            lblSatilanUrunAdet.TabIndex = 3;
            lblSatilanUrunAdet.Text = "412";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(43, 177);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 2;
            label4.Text = "Satılan Ürün Adedi";
            // 
            // lblToplamCiro
            // 
            lblToplamCiro.AutoSize = true;
            lblToplamCiro.Font = new Font("Segoe UI Symbol", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblToplamCiro.ForeColor = SystemColors.ButtonFace;
            lblToplamCiro.Location = new Point(43, 57);
            lblToplamCiro.Name = "lblToplamCiro";
            lblToplamCiro.Size = new Size(178, 65);
            lblToplamCiro.TabIndex = 1;
            lblToplamCiro.Text = "5,97 M";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(43, 22);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 0;
            label1.Text = "Toplam Ciro";
            // 
            // EkranSatisTakip
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(pnlGenelBilgiler);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "EkranSatisTakip";
            Text = "EkranUrunTakip";
            Load += EkranUrunTakip_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).EndInit();
            panel2.ResumeLayout(false);
            pnlGenelBilgiler.ResumeLayout(false);
            pnlGenelBilgiler.PerformLayout();
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
        private System.Windows.Forms.Timer timer1;
        private Panel pnlGenelBilgiler;
        private Label lblSatilanUrunAdet;
        private Label label4;
        private Label lblToplamCiro;
        private Label label1;
        private Button btnGunlukSatis;
        private Button btnAylikSatis;
        private Button btnTumZamanlarSatis;
    }
}