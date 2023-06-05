namespace Cafe_Adisyon
{
    partial class EkranGuncelleme
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
            panel2 = new Panel();
            btnStok = new Button();
            btnGuncelleme = new Button();
            btnGrafik = new Button();
            btnMenu = new Button();
            btnMasa = new Button();
            panel1 = new Panel();
            lblDate = new Label();
            lblYEDAdisyonSistemi = new Label();
            pctbxYEDLogo = new PictureBox();
            panel3 = new Panel();
            btnAra = new Button();
            txtBxAra = new TextBox();
            label2 = new Label();
            btnMenuSil = new Button();
            btnMenuEkle = new Button();
            cmbBxKategori = new ComboBox();
            label1 = new Label();
            panel5 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel4 = new Panel();
            btnYeniYemekEkle = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).BeginInit();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
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
            panel2.TabIndex = 6;
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
            panel1.TabIndex = 7;
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(254, 255, 254);
            panel3.Controls.Add(btnAra);
            panel3.Controls.Add(txtBxAra);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(btnMenuSil);
            panel3.Controls.Add(btnMenuEkle);
            panel3.Controls.Add(cmbBxKategori);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(115, 45);
            panel3.Name = "panel3";
            panel3.Size = new Size(1775, 100);
            panel3.TabIndex = 8;
            // 
            // btnAra
            // 
            btnAra.BackgroundImage = Properties.Resources.ButtonAra;
            btnAra.FlatAppearance.BorderSize = 0;
            btnAra.FlatStyle = FlatStyle.Flat;
            btnAra.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAra.ForeColor = Color.FromArgb(254, 255, 254);
            btnAra.Location = new Point(891, 50);
            btnAra.Name = "btnAra";
            btnAra.Padding = new Padding(0, 0, 0, 2);
            btnAra.Size = new Size(75, 30);
            btnAra.TabIndex = 6;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // txtBxAra
            // 
            txtBxAra.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtBxAra.ForeColor = Color.FromArgb(175, 173, 172);
            txtBxAra.Location = new Point(520, 53);
            txtBxAra.Name = "txtBxAra";
            txtBxAra.Size = new Size(355, 27);
            txtBxAra.TabIndex = 5;
            txtBxAra.Text = "  Kategori seçmeyi unutmayın!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(23, 37, 55);
            label2.Location = new Point(520, 20);
            label2.Name = "label2";
            label2.Size = new Size(260, 21);
            label2.TabIndex = 4;
            label2.Text = "Aramak istediğiniz yemeği girin";
            // 
            // btnMenuSil
            // 
            btnMenuSil.BackColor = Color.LightCoral;
            btnMenuSil.BackgroundImage = Properties.Resources.ButtonMenuSil;
            btnMenuSil.FlatAppearance.BorderSize = 0;
            btnMenuSil.FlatStyle = FlatStyle.Flat;
            btnMenuSil.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenuSil.ForeColor = Color.FromArgb(254, 255, 254);
            btnMenuSil.Location = new Point(1635, 20);
            btnMenuSil.Name = "btnMenuSil";
            btnMenuSil.Size = new Size(100, 49);
            btnMenuSil.TabIndex = 3;
            btnMenuSil.Text = "Menü Sil";
            btnMenuSil.UseVisualStyleBackColor = false;
            btnMenuSil.Click += btnMenuSil_Click;
            // 
            // btnMenuEkle
            // 
            btnMenuEkle.BackgroundImage = Properties.Resources.ButtonMenuEkle;
            btnMenuEkle.FlatStyle = FlatStyle.Flat;
            btnMenuEkle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenuEkle.ForeColor = Color.FromArgb(254, 255, 254);
            btnMenuEkle.Location = new Point(1504, 20);
            btnMenuEkle.Name = "btnMenuEkle";
            btnMenuEkle.Size = new Size(101, 50);
            btnMenuEkle.TabIndex = 2;
            btnMenuEkle.Text = "Menü Ekle";
            btnMenuEkle.UseVisualStyleBackColor = true;
            btnMenuEkle.Click += btnMenuEkle_Click;
            // 
            // cmbBxKategori
            // 
            cmbBxKategori.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            cmbBxKategori.FormattingEnabled = true;
            cmbBxKategori.Location = new Point(66, 53);
            cmbBxKategori.Name = "cmbBxKategori";
            cmbBxKategori.Size = new Size(234, 28);
            cmbBxKategori.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(23, 37, 55);
            label1.Location = new Point(66, 20);
            label1.Name = "label1";
            label1.Size = new Size(150, 21);
            label1.TabIndex = 0;
            label1.Text = "Bir Kategori Seçin";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(248, 244, 244);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(label3);
            panel5.Location = new Point(115, 164);
            panel5.Name = "panel5";
            panel5.Size = new Size(1775, 40);
            panel5.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(675, 38);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 3;
            label6.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(123, 133, 147);
            label5.Location = new Point(651, 13);
            label5.Name = "label5";
            label5.Size = new Size(75, 21);
            label5.TabIndex = 2;
            label5.Text = "Açıklama";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(123, 133, 147);
            label4.Location = new Point(398, 13);
            label4.Name = "label4";
            label4.Size = new Size(44, 21);
            label4.TabIndex = 1;
            label4.Text = "Fiyat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(123, 133, 147);
            label3.Location = new Point(66, 13);
            label3.Name = "label3";
            label3.Size = new Size(87, 21);
            label3.TabIndex = 0;
            label3.Text = "Yemek Adı";
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.BackColor = Color.FromArgb(254, 255, 254);
            panel4.Controls.Add(btnYeniYemekEkle);
            panel4.Location = new Point(115, 202);
            panel4.Name = "panel4";
            panel4.Size = new Size(1775, 785);
            panel4.TabIndex = 11;
            // 
            // btnYeniYemekEkle
            // 
            btnYeniYemekEkle.FlatAppearance.BorderSize = 0;
            btnYeniYemekEkle.FlatStyle = FlatStyle.Flat;
            btnYeniYemekEkle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnYeniYemekEkle.ForeColor = Color.FromArgb(118, 128, 143);
            btnYeniYemekEkle.Location = new Point(66, 714);
            btnYeniYemekEkle.Name = "btnYeniYemekEkle";
            btnYeniYemekEkle.Size = new Size(164, 38);
            btnYeniYemekEkle.TabIndex = 2;
            btnYeniYemekEkle.Text = "+Yeni yemek ekle";
            btnYeniYemekEkle.UseVisualStyleBackColor = true;
            btnYeniYemekEkle.Visible = false;
            btnYeniYemekEkle.Click += btnYeniYemekEkle_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // EkranGuncelleme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "EkranGuncelleme";
            Text = "EkranGuncelleme";
            Load += EkranGuncelleme_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button btnStok;
        private Button btnGuncelleme;
        private Button btnGrafik;
        private Button btnMenu;
        private Button btnMasa;
        private Panel panel1;
        private Label lblDate;
        private Label lblYEDAdisyonSistemi;
        private PictureBox pctbxYEDLogo;
        private Panel panel3;
        private Button btnAra;
        private TextBox txtBxAra;
        private Label label2;
        private Button btnMenuSil;
        private Button btnMenuEkle;
        private ComboBox cmbBxKategori;
        private Label label1;
        private Panel panel5;
        private Label label5;
        private Label label4;
        private Label label3;
        private Panel panel4;
        private Button btnYeniYemekEkle;
        private System.Windows.Forms.Timer timer1;
        private Label label6;
    }
}