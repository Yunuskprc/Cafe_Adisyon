namespace Cafe_Adisyon
{
    partial class EkranMenu
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
            panel5 = new Panel();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            panel4 = new Panel();
            pnlMenu = new Panel();
            timerDate = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).BeginInit();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
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
            panel1.TabIndex = 4;
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
            panel2.TabIndex = 5;
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
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(248, 244, 244);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(label3);
            panel5.Location = new Point(117, 50);
            panel5.Name = "panel5";
            panel5.Size = new Size(1775, 40);
            panel5.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(123, 133, 147);
            label4.Location = new Point(490, 10);
            label4.Name = "label4";
            label4.Size = new Size(121, 21);
            label4.TabIndex = 3;
            label4.Text = "Menü Açıklama";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(123, 133, 147);
            label1.Location = new Point(1460, 10);
            label1.Name = "label1";
            label1.Size = new Size(129, 21);
            label1.TabIndex = 1;
            label1.Text = "Menü Görüntüle";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(123, 133, 147);
            label3.Location = new Point(40, 10);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 0;
            label3.Text = "Menüler";
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.BackColor = Color.FromArgb(254, 255, 254);
            panel4.Controls.Add(pnlMenu);
            panel4.Location = new Point(116, 90);
            panel4.Name = "panel4";
            panel4.Size = new Size(1775, 785);
            panel4.TabIndex = 10;
            // 
            // pnlMenu
            // 
            pnlMenu.Location = new Point(422, 136);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(970, 500);
            pnlMenu.TabIndex = 0;
            pnlMenu.Visible = false;
            // 
            // timerDate
            // 
            timerDate.Interval = 1000;
            timerDate.Tick += timerDate_Tick;
            // 
            // EkranMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "EkranMenu";
            Text = "EkranMenu";
            Load += EkranMenu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctbxYEDLogo).EndInit();
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
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
        private Panel panel5;
        private Label label3;
        private Panel panel4;
        private System.Windows.Forms.Timer timerDate;
        private Label label4;
        private Label label1;
        private Panel pnlMenu;
    }
}