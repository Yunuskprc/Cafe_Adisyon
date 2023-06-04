using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Adisyon
{
    public partial class EkranMenu : Form
    {
        public EkranMenu()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Cafe_Adisyon;Trusted_Connection=True;");

        private void EkranMenu_Load(object sender, EventArgs e)
        {
            timerDate.Start();
            lblDate.Visible = true;
            menuSirala();
        }

        private void timerDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
        }

        private void btnMasa_Click(object sender, EventArgs e)
        {
            EkranMasa nEkranMasa = new EkranMasa();
            nEkranMasa.Show();
            this.Hide();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            EkranMenu nEkranMenu = new EkranMenu();
            nEkranMenu.Show();
            this.Hide();
        }

        private void menuSirala()
        {
            int sayac = 0;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM MENULER", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            Color color = new Color();
            while (dr.Read())
            {
                Panel pnl = new Panel();
                panel4.Controls.Add(pnl);
                pnl.Location = new Point(0, 60 * (sayac));
                pnl.Size = new System.Drawing.Size(1750, 60);

                // sıralı panelleri birbirinden ayırmak için yapılan renk değiştirme kontrolü
                if (sayac % 2 == 0)
                    color = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                else
                    color = System.Drawing.Color.FromArgb(236, 236, 238);
                pnl.BackColor = color;
                //
                // Menü Adının Yazdığı lbl
                //
                Label lblMenuAd = new Label();
                lblMenuAd.Size = new System.Drawing.Size(200, 20);
                lblMenuAd.BackColor = color;
                lblMenuAd.Text = dr["isim"].ToString();
                lblMenuAd.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                lblMenuAd.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
                pnl.Controls.Add(lblMenuAd);
                lblMenuAd.Location = new System.Drawing.Point(34, 20);
                lblMenuAd.Visible = true;
                lblMenuAd.BorderStyle = BorderStyle.None;
                //
                //
                Label lblMenuAciklama = new Label();
                lblMenuAciklama.Size = new System.Drawing.Size(400, 20);
                lblMenuAciklama.BackColor = color;
                lblMenuAciklama.Text = dr["aciklama"].ToString();
                lblMenuAciklama.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                lblMenuAciklama.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
                pnl.Controls.Add(lblMenuAciklama);
                lblMenuAciklama.Location = new System.Drawing.Point(421, 20);
                lblMenuAciklama.Visible = true;
                lblMenuAciklama.BorderStyle = BorderStyle.None;
                //
                //
                Button btnMenuGoster = new Button();
                pnl.Controls.Add(btnMenuGoster);
                btnMenuGoster.BackColor = Color.FromArgb(119, 208, 189);
                btnMenuGoster.FlatAppearance.BorderSize = 0;
                btnMenuGoster.FlatStyle = FlatStyle.Flat;
                btnMenuGoster.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
                btnMenuGoster.ForeColor = SystemColors.ButtonFace;
                btnMenuGoster.Location = new Point(1470, 10);
                btnMenuGoster.Size = new Size(110, 40);
                btnMenuGoster.TabIndex = 0;
                btnMenuGoster.Text = "Menü";
                btnMenuGoster.UseVisualStyleBackColor = false;
                btnMenuGoster.Name = lblMenuAd.Text;
                if (sayac % 2 == 0)
                    btnMenuGoster.BackgroundImage = Cafe_Adisyon.Properties.Resources.btnMenuGosterBeyaz;
                else
                    btnMenuGoster.BackgroundImage = Cafe_Adisyon.Properties.Resources.btnMenuGosterGri;

                btnMenuGoster.Click += btnMenuGoster_Clik;

                sayac++;
            }

            conn.Close();
        }

        private void btnMenuGoster_Clik(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            pnlMenu.Controls.Clear();
            pnlMenu.BringToFront();
            pnlMenu.Visible = true;

            Panel pnl = new Panel();
            pnlMenu.Controls.Add(pnl);
            pnl.BackColor = Color.FromArgb(18, 35, 60);
            pnl.Location = new Point(0, 0);
            pnl.Size = new Size(970, 50);
            pnl.TabIndex = 0;
            //
            // Sıralama Menüsünün kolon adları labelleri
            //
            Label lbl1 = new Label();
            pnl.Controls.Add(lbl1);
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.ForeColor = Color.FromArgb(255, 255, 255);
            lbl1.Location = new Point(40, 15);
            lbl1.Size = new Size(64, 21);
            lbl1.TabIndex = 1;
            lbl1.Text = "Ürünler";
            //
            //
            Label lbl2 = new Label();
            pnl.Controls.Add(lbl2);
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.ForeColor = Color.FromArgb(255, 255, 255);
            lbl2.Location = new Point(251, 15);
            lbl2.Size = new Size(114, 21);
            lbl2.TabIndex = 4;
            lbl2.Text = "Ürün Açıklama";
            //
            //
            Label lbl3 = new Label();
            pnl.Controls.Add(lbl3);
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.ForeColor = Color.FromArgb(255, 255, 255);
            lbl3.Location = new Point(844, 15);
            lbl3.Size = new Size(44, 21);
            lbl3.TabIndex = 5;
            lbl3.Text = "Fiyat";

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM " + btn.Name, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int sayac = 1;
            int y = 50; // kordinat
            Color color1 = new Color();
            Color color2 = new Color();
            while (dr.Read())
            {
                Panel pnlUrun = new Panel();
                pnlMenu.Controls.Add(pnlUrun);
                pnlUrun.Location = new Point(0, y);
                pnlUrun.Size = new System.Drawing.Size(1750, 40);

                // sıralı panelleri birbirinden ayırmak için yapılan renk değiştirme kontrolü
                if ((sayac - 1) % 2 == 0)
                {
                    color1 = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                    color2 = System.Drawing.Color.FromArgb(85, 128, 158);
                }
                else
                {
                    color1 = System.Drawing.Color.FromArgb(85, 120, 158);
                    color2 = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                }


                pnlUrun.BackColor = color1;

                //
                // Ürün Adının Yazdığı Lbl
                //
                Label lblUrunAd = new Label();
                lblUrunAd.AutoEllipsis = true;
                lblUrunAd.Size = new System.Drawing.Size(200, 20);
                lblUrunAd.BackColor = color1;
                lblUrunAd.Text = dr["isim"].ToString();
                lblUrunAd.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                lblUrunAd.ForeColor = color2;
                pnlUrun.Controls.Add(lblUrunAd);
                lblUrunAd.Location = new System.Drawing.Point(34, 10);
                lblUrunAd.Visible = true;
                lblUrunAd.BorderStyle = BorderStyle.None;
                //
                //
                Label lblUrunAciklama = new Label();
                lblUrunAciklama.AutoEllipsis = true;
                lblUrunAciklama.Size = new System.Drawing.Size(550, 20);
                lblUrunAciklama.BackColor = color1;
                lblUrunAciklama.Text = dr["aciklama"].ToString();
                lblUrunAciklama.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                lblUrunAciklama.ForeColor = color2;
                pnlUrun.Controls.Add(lblUrunAciklama);
                lblUrunAciklama.Location = new System.Drawing.Point(251, 10);
                lblUrunAciklama.Visible = true;
                lblUrunAciklama.BorderStyle = BorderStyle.None;
                //
                //
                Label lblUrunFiyat = new Label();
                pnlUrun.Controls.Add(lblUrunFiyat);
                lblUrunFiyat.BackColor = color1;
                lblUrunFiyat.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                lblUrunFiyat.ForeColor = color2;
                lblUrunFiyat.Location = new Point(850, 10);
                lblUrunFiyat.Size = new Size(110, 40);
                lblUrunFiyat.TabIndex = 0;
                lblUrunFiyat.Visible = true;
                lblUrunFiyat.BorderStyle = BorderStyle.None;
                lblUrunFiyat.Text = dr["fiyat"].ToString();

                sayac++;
                y += 40;
            }
            conn.Close();

            Button btnMenuKapat = new Button();
            pnlMenu.Controls.Add(btnMenuKapat);
            btnMenuKapat.FlatAppearance.BorderSize = 0;
            btnMenuKapat.FlatStyle = FlatStyle.Flat;
            btnMenuKapat.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenuKapat.ForeColor = Color.FromArgb(18, 35, 60);
            btnMenuKapat.Location = new Point(757, 441);
            btnMenuKapat.Size = new Size(171, 43);
            btnMenuKapat.TabIndex = 0;
            btnMenuKapat.Text = "Menüyü Kapat";
            btnMenuKapat.UseVisualStyleBackColor = true;
            btnMenuKapat.Click += btnMenuKapat_Clik;
        }

        private void btnMenuKapat_Clik(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            pnlMenu.Controls.Clear();
            pnlMenu.Visible = false;
        }
    }
}
