namespace Adisyon_Sistemi
{
    partial class GirisEkran
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox3 = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            checkBox1 = new CheckBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Cafe_Adisyon.Properties.Resources.YEDLogo;
            pictureBox3.Location = new Point(700, 78);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 100);
            pictureBox3.TabIndex = 15;
            pictureBox3.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(233, 234, 235);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.FromArgb(69, 179, 177);
            button2.Location = new Point(641, 476);
            button2.Name = "button2";
            button2.Size = new Size(220, 28);
            button2.TabIndex = 14;
            button2.Text = "Hesabınız yok mu? Üye olun";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackgroundImage = Cafe_Adisyon.Properties.Resources.girisButon;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(658, 409);
            button1.Name = "button1";
            button1.Size = new Size(180, 50);
            button1.TabIndex = 13;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.FromArgb(233, 234, 235);
            checkBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.ForeColor = Color.FromArgb(69, 179, 177);
            checkBox1.Location = new Point(713, 384);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(87, 19);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "Beni Hatırla";
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(199, 198, 198);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.ForeColor = Color.DimGray;
            textBox2.Location = new Point(672, 326);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(166, 21);
            textBox2.TabIndex = 11;
            textBox2.Text = "Şifre:";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(199, 198, 198);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = Color.DimGray;
            textBox1.Location = new Point(672, 240);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(166, 21);
            textBox1.TabIndex = 10;
            textBox1.Text = "Kullanıcı Adı:";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Cafe_Adisyon.Properties.Resources.RoundedRectangle;
            pictureBox2.Location = new Point(641, 311);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(225, 50);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Cafe_Adisyon.Properties.Resources.RoundedRectangle;
            pictureBox1.Location = new Point(641, 226);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(225, 50);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // GirisEkran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Cafe_Adisyon.Properties.Resources.girişEkranTasarım;
            ClientSize = new Size(984, 561);
            Controls.Add(pictureBox3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GirisEkran";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox3;
        private Button button2;
        private Button button1;
        private CheckBox checkBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}