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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).BeginInit();
            panel2.SuspendLayout();
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
            // EkranUrunTakip
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "EkranUrunTakip";
            Text = "EkranUrunTakip";
            Load += EkranUrunTakip_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).EndInit();
            panel2.ResumeLayout(false);
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
    }
}