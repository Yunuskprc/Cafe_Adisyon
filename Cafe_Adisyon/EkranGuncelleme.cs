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
    public partial class EkranGuncelleme : Form
    {
        public EkranGuncelleme()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Cafe_Adisyon;Trusted_Connection=True;");

        // to do -> btnKaydet✓✓ ve sil metotları✓✓
        // to do -> btnYeniYemek Ekle meotdu✓✓
        // to do -> kategori ekle ve sil butonları

        // pnl menüEkle tamamlandı, close butonu çalışıyor, ekle butonunda boolean hatası alıyoruz. Yarın menu sil ve menu kaydet i düzenle;



        private void btnMasa_Click(object sender, EventArgs e)
        {
            EkranMasa ekranMasa = new EkranMasa();
            ekranMasa.Show();
            this.Hide();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            EkranMenu ekranMenu = new EkranMenu();
            ekranMenu.Show();
            this.Hide();
        }

        private void btnGuncelleme_Click(object sender, EventArgs e)
        {
            EkranGuncelleme ekranGuncelleme = new EkranGuncelleme();
            ekranGuncelleme.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
        }

        private void EkranGuncelleme_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Visible = true;
            cmbBxKategori.Controls.Clear();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM MENULER", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBxKategori.Items.Add(dr["isim"].ToString());
            }
            conn.Close();

            cmbBxKategori.Text = cmbBxKategori.Items[0].ToString();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            listAd.Clear();
            listFiyat.Clear();
            listAciklama.Clear();
            yemekEkleBtnKonum = 0;
            // panellere butonları ekledik ve yerlerini değiştirdik;
            panel4.Controls.Add(btnYeniYemekEkle);

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
            btnYeniYemekEkle.Visible = true;

            UrunListeleme();

        }



        TextBox txtYemekAd = new TextBox();
        TextBox txtFiyat = new TextBox();
        TextBox txtAciklama = new TextBox();
        int yemekEkleBtnKonum = 0;

        List<TextBox> listAd = new List<TextBox>();
        List<TextBox> listFiyat = new List<TextBox>();
        List<TextBox> listAciklama = new List<TextBox>();

        private void UrunListeleme()
        {
            int sayac = 0;

            Color color1 = new Color();


            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM " + cmbBxKategori.Text + " ORDER BY urunId ASC", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                if (sayac % 2 == 0)
                    color1 = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                else
                    color1 = System.Drawing.Color.FromArgb(236, 236, 238);

                Panel pnl = new Panel();
                pnl.Size = new System.Drawing.Size(1750, 60);
                panel4.Controls.Add(pnl);
                pnl.Location = new System.Drawing.Point(0, 60 * sayac);
                pnl.Visible = true;
                pnl.BackColor = color1;

                //
                // yemek adlarının yazdığı textbox
                // 
                txtYemekAd = new TextBox();
                txtYemekAd.Size = new System.Drawing.Size(200, 20);
                txtYemekAd.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                txtYemekAd.Text = dr["isim"].ToString();
                txtYemekAd.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                txtYemekAd.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
                pnl.Controls.Add(txtYemekAd);
                txtYemekAd.Location = new System.Drawing.Point(34, 20);
                txtYemekAd.Visible = true;
                txtYemekAd.TextAlign = HorizontalAlignment.Center;
                txtYemekAd.BorderStyle = BorderStyle.Fixed3D;
                listAd.Add(txtYemekAd);
                //
                // yemek fiyatlarının yazdığı textbox
                //
                txtFiyat = new TextBox();
                txtFiyat.Size = new System.Drawing.Size(80, 20);
                txtFiyat.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                txtFiyat.Text = dr["fiyat"].ToString();
                txtFiyat.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                txtFiyat.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
                pnl.Controls.Add(txtFiyat);
                txtFiyat.Location = new System.Drawing.Point(380, 20);
                txtFiyat.Visible = true;
                txtFiyat.TextAlign = HorizontalAlignment.Center;
                txtFiyat.BorderStyle = BorderStyle.Fixed3D;
                listFiyat.Add(txtFiyat);
                //
                // yemek açıklamalarının yazdığı textbox
                //
                txtAciklama = new TextBox();
                txtAciklama.Size = new System.Drawing.Size(500, 20);
                txtAciklama.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                txtAciklama.Text = dr["aciklama"].ToString();
                txtAciklama.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                txtAciklama.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
                pnl.Controls.Add(txtAciklama);
                txtAciklama.Location = new System.Drawing.Point(570, 20);
                txtAciklama.Visible = true;
                txtAciklama.TextAlign = HorizontalAlignment.Center;
                txtAciklama.BorderStyle = BorderStyle.Fixed3D;
                listAciklama.Add(txtAciklama);
                //
                // kaydetmek için button
                //
                Button btnYemekKaydet = new Button();
                btnYemekKaydet.Size = new System.Drawing.Size(75, 33);
                btnYemekKaydet.Text = "Kaydet";
                btnYemekKaydet.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
                btnYemekKaydet.ForeColor = Color.White;
                pnl.Controls.Add(btnYemekKaydet);
                btnYemekKaydet.Location = new System.Drawing.Point(1200, 15);
                btnYemekKaydet.Visible = true;
                btnYemekKaydet.FlatStyle = FlatStyle.Flat;
                btnYemekKaydet.FlatAppearance.BorderSize = 0;
                if (sayac % 2 == 0)
                    btnYemekKaydet.BackgroundImage = Cafe_Adisyon.Properties.Resources.ButtonYemekDuzenle;
                else
                    btnYemekKaydet.BackgroundImage = Cafe_Adisyon.Properties.Resources.ButtonYemekDuzenleGri;
                btnYemekKaydet.Click += btnYemekKaydet_Clik;
                btnYemekKaydet.Name = dr["urunId"].ToString();
                //
                // yemeği kaldırmak için buton
                //
                Button btnYemekSil = new Button();
                btnYemekSil.Size = new System.Drawing.Size(75, 33);
                btnYemekSil.Text = "Sil";
                btnYemekSil.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
                btnYemekSil.ForeColor = Color.White;
                pnl.Controls.Add(btnYemekSil);
                btnYemekSil.Location = new System.Drawing.Point(1350, 15);
                btnYemekSil.Visible = true;
                btnYemekSil.FlatStyle = FlatStyle.Flat;
                btnYemekSil.FlatAppearance.BorderSize = 0;
                if (sayac % 2 == 0)
                    btnYemekSil.BackgroundImage = Cafe_Adisyon.Properties.Resources.ButtonYemekSil;
                else
                    btnYemekSil.BackgroundImage = Cafe_Adisyon.Properties.Resources.ButtonYemekSilGri;
                btnYemekSil.Click += btnYemekSil_Clik;
                btnYemekSil.Name = dr["urunId"].ToString();
                sayac++;
            }
            yemekEkleBtnKonum = sayac;
            conn.Close();
        }



        private void btnYemekKaydet_Clik(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            bool kontrol = true;


            string isim = listAd[Int16.Parse(btn.Name) - 1].Text;
            string fiyat = listFiyat[Int16.Parse(btn.Name) - 1].Text;
            string aciklama = listAciklama[Int16.Parse(btn.Name) - 1].Text;


            for (int i = 0; i < fiyat.Length; i++)
            {
                if (fiyat[i] == '0' || fiyat[i] == '1' || fiyat[i] == '2' || fiyat[i] == '3' || fiyat[i] == '4' || fiyat[i] == '5' || fiyat[i] == '6' || fiyat[i] == '7' || fiyat[i] == '8' || fiyat[i] == '9')
                    continue;
                else
                {
                    kontrol = false;
                    break;
                }

            }


            if (kontrol)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update " + cmbBxKategori.Text + " set isim='" + isim + "',fiyat=" + Int16.Parse(fiyat) + ",aciklama='" + aciklama + "' where urunId=" + btn.Name, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün başarılı bir şekilde güncellenmiştir..", "Ürün Güncelleme");
                conn.Close();
                listAciklama.Clear();
                listAd.Clear();
                listFiyat.Clear();
                txtAciklama.Clear();
                txtBxAra.Clear();
                txtFiyat.Clear();
                btnAra_Click(sender, e);
            }
        }

        private void btnYemekSil_Clik(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM " + cmbBxKategori.Text + " WHERE urunId=" + Int16.Parse(btn.Name), conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Ürün başarılı bir şekilde kaldırılmıştır..", "Ürün Kaldırma");
            btnAra_Click(sender, e);

        }




        TextBox txtYeniYemekAd = new TextBox();
        TextBox txtYeniFiyat = new TextBox();
        TextBox txtYeniAciklama = new TextBox();

        private void btnYeniYemekEkle_Click(object sender, EventArgs e)
        {

            Color color1 = new Color();
            if (yemekEkleBtnKonum % 2 == 0)
                color1 = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            else
                color1 = System.Drawing.Color.FromArgb(236, 236, 238);

            Panel pnl = new Panel();
            pnl.Size = new System.Drawing.Size(1750, 60);
            panel4.Controls.Add(pnl);
            pnl.Location = new System.Drawing.Point(0, 60 * yemekEkleBtnKonum);
            pnl.Visible = true;
            pnl.BackColor = color1;
            //
            // yemek adlarının yazdığı textbox
            // 
            txtYeniYemekAd = new TextBox();
            txtYeniYemekAd.Size = new System.Drawing.Size(200, 20);
            txtYeniYemekAd.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            txtYeniFiyat.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            txtYeniYemekAd.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
            pnl.Controls.Add(txtYeniYemekAd);
            txtYeniYemekAd.Location = new System.Drawing.Point(34, 20);
            txtYeniYemekAd.Visible = true;
            txtYeniYemekAd.TextAlign = HorizontalAlignment.Center;
            txtYeniYemekAd.BorderStyle = BorderStyle.Fixed3D;
            //
            // yemek fiyatlarının yazdığı textbox
            //
            txtYeniFiyat = new TextBox();
            txtYeniFiyat.Size = new System.Drawing.Size(80, 20);
            txtYeniFiyat.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            txtYeniFiyat.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            txtYeniFiyat.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
            pnl.Controls.Add(txtYeniFiyat);
            txtYeniFiyat.Location = new System.Drawing.Point(380, 20);
            txtYeniFiyat.Visible = true;
            txtYeniFiyat.TextAlign = HorizontalAlignment.Center;
            txtYeniFiyat.BorderStyle = BorderStyle.Fixed3D;
            //
            // yemek açıklamalarının yazdığı textbox
            //
            txtAciklama = new TextBox();
            txtAciklama.Size = new System.Drawing.Size(500, 20);
            txtAciklama.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            txtAciklama.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            txtAciklama.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
            pnl.Controls.Add(txtAciklama);
            txtAciklama.Location = new System.Drawing.Point(570, 20);
            txtAciklama.Visible = true;
            txtAciklama.TextAlign = HorizontalAlignment.Center;
            txtAciklama.BorderStyle = BorderStyle.Fixed3D;
            //
            // kaydetmek için button
            //
            Button btnYeniYemekEkleKaydet = new Button();
            btnYeniYemekEkleKaydet.Size = new System.Drawing.Size(75, 33);
            btnYeniYemekEkleKaydet.Text = "Kaydet";
            btnYeniYemekEkleKaydet.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            btnYeniYemekEkleKaydet.ForeColor = Color.White;
            pnl.Controls.Add(btnYeniYemekEkleKaydet);
            btnYeniYemekEkleKaydet.Location = new System.Drawing.Point(1200, 15);
            btnYeniYemekEkleKaydet.Visible = true;
            btnYeniYemekEkleKaydet.FlatStyle = FlatStyle.Flat;
            btnYeniYemekEkleKaydet.FlatAppearance.BorderSize = 0;
            if (yemekEkleBtnKonum % 2 == 0)
                btnYeniYemekEkleKaydet.BackgroundImage = Cafe_Adisyon.Properties.Resources.ButtonYemekDuzenle;
            else
                btnYeniYemekEkleKaydet.BackgroundImage = Cafe_Adisyon.Properties.Resources.ButtonYemekDuzenleGri;
            btnYeniYemekEkleKaydet.Click += btnYeniYemekEkleKaydet_Clik;

            yemekEkleBtnKonum++;
        }


        private void btnYeniYemekEkleKaydet_Clik(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            bool kontrol = true;
            string fiyat = txtYeniFiyat.Text;

            for (int i = 0; i < fiyat.Length; i++)
            {
                if (fiyat[i] == '0' || fiyat[i] == '1' || fiyat[i] == '2' || fiyat[i] == '3' || fiyat[i] == '4' || fiyat[i] == '5' || fiyat[i] == '6' || fiyat[i] == '7' || fiyat[i] == '8' || fiyat[i] == '9')
                    continue;
                else
                {
                    kontrol = false;
                    break;
                }

            }

            if (kontrol)
            {
                int urunId = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT *FROM " + cmbBxKategori.Text + " ORDER BY urunId ASC", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    urunId = Int16.Parse(dr["urunId"].ToString());
                }
                urunId++;
                dr.Close();

                cmd = new SqlCommand("insert into " + cmbBxKategori.Text + "(urunId,isim,fiyat,aciklama) values (" + urunId + ",'" + txtYeniYemekAd.Text + "'," + txtYeniFiyat.Text + ",'" + txtYeniAciklama.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Yeni ürün eklendi..", "Ürün Ekleme");
                conn.Close();
                urunId = 0;
            }

            txtYeniFiyat.Clear();
            txtYeniYemekAd.Clear();
            txtYeniAciklama.Clear();
            fiyat = "";

            btnAra_Click(sender, e);
        }






        TextBox txtMenuAd = new TextBox();
        TextBox txtMenuAciklama = new TextBox();
        Panel pnlMenuEkle = new Panel();
        private void btnMenuEkle_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Visible = false;
            panel5.Visible = false;


            Controls.Add(pnlMenuEkle);
            pnlMenuEkle.Size = new Size(460, 220);
            pnlMenuEkle.Location = new Point(760, 360);
            pnlMenuEkle.BackColor = Color.FromArgb(254, 254, 255);

            Label lbl1 = new Label();
            pnlMenuEkle.Controls.Add(lbl1);
            lbl1.Font = new Font("Segoe UI Semibold", 15, FontStyle.Bold);
            lbl1.Text = "Menü Ekleme Sayfası";
            lbl1.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
            lbl1.Visible = true;
            lbl1.Location = new Point(140, 20);
            lbl1.Size = new Size(250, 30);

            Label lbl2 = new Label();
            pnlMenuEkle.Controls.Add(lbl2);
            lbl2.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            lbl2.Text = "Menü Ad:";
            lbl2.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
            lbl2.Visible = true;
            lbl2.Location = new Point(50, 91);
            lbl2.Size = new Size(70, 30);

            pnlMenuEkle.Controls.Add(txtMenuAd);
            txtMenuAd.Size = new System.Drawing.Size(240, 20);
            txtMenuAd.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            txtMenuAd.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            txtMenuAd.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
            txtMenuAd.Location = new System.Drawing.Point(130, 90);
            txtMenuAd.Visible = true;
            txtMenuAd.TextAlign = HorizontalAlignment.Center;
            txtMenuAd.BorderStyle = BorderStyle.Fixed3D;
            txtMenuAd.Text = "Menu_MenuAd şeklinde olmalıdır.";

            Label lbl3 = new Label();
            pnlMenuEkle.Controls.Add(lbl3);
            lbl3.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            lbl3.Text = "Menü Açıklama:";
            lbl3.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
            lbl3.Visible = true;
            lbl3.Location = new Point(10, 120);
            lbl3.Size = new Size(120, 30);

            pnlMenuEkle.Controls.Add(txtMenuAciklama);
            txtMenuAciklama.Size = new System.Drawing.Size(240, 20);
            txtMenuAciklama.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            txtMenuAciklama.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            txtMenuAciklama.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
            txtMenuAciklama.Location = new System.Drawing.Point(130, 120);
            txtMenuAciklama.Visible = true;
            txtMenuAciklama.TextAlign = HorizontalAlignment.Center;
            txtMenuAciklama.BorderStyle = BorderStyle.Fixed3D;

            Button btnKaydet = new Button();
            pnlMenuEkle.Controls.Add(btnKaydet);
            btnKaydet.BackgroundImage = Properties.Resources.ButtonAra;
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnKaydet.ForeColor = Color.FromArgb(254, 255, 254);
            btnKaydet.Location = new Point(350, 165);
            btnKaydet.Padding = new Padding(0, 0, 0, 2);
            btnKaydet.Size = new Size(75, 30);
            btnKaydet.TabIndex = 6;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnYeniMenuKaydet_Clik;


            Button btnClose = new Button();
            pnlMenuEkle.Controls.Add(btnClose);
            btnClose.Size = new Size(24, 24);
            btnClose.Location = new Point(435, 1);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Text = "❌";
            btnClose.ForeColor = Color.FromArgb(238, 0, 0);
            btnClose.Font = new Font("", 10F);
            btnClose.Click += btnClose_Clik;
        }

        private void btnYeniMenuKaydet_Clik(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            bool kontrol = true;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM MENULER", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["isim"].ToString() == txtMenuAd.Text)
                {
                    kontrol = false;
                    break;
                }
            }
            conn.Close(); dr.Close();

            for (int i = 0; i < txtMenuAd.Text.Length; i++)
            {
                if (txtMenuAd.Text[i] == ' ')
                {
                    kontrol |= false;
                    break;
                }
            }

            if (txtMenuAd.Text.Length < 5)
            {
                kontrol = false;
            }
            else
            {
                if (txtMenuAd.Text.Substring(0, 5) != "Menu_")
                    kontrol = false;
            }

            if (kontrol)
            {
                conn.Open();
                cmd = new SqlCommand("CREATE TABLE " + txtMenuAd.Text + "(urunId int,isim nvarchar(50),fiyat int,aciklama text)", conn);
                cmd.ExecuteNonQuery();

                int kategoriId = 0;
                cmd = new SqlCommand("SELECT *FROM MENULER ORDER BY kategoriId", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                { kategoriId = Int16.Parse(dr["kategoriId"].ToString()); }
                kategoriId++;
                dr.Close();
                cmd = new SqlCommand("insert into MENULER(kategoriId,isim,aciklama,aktiflik) values (" + kategoriId + ",'" + txtMenuAd.Text + "','" + txtMenuAciklama.Text + "'," + 1 + ")", conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Menü başarılı bir şekilde eklenmiştir..", "Menü Ekleme");
                conn.Close();
            }
            else
                MessageBox.Show("Hatalı menü ad girişi tekrar deneyin", "Uyarı");

        }

        private void btnClose_Clik(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtMenuAciklama.Clear();
            txtMenuAd.Clear();
            pnlMenuEkle.Controls.Clear();

            panel4.Visible = true;
            panel5.Visible = true;
            EkranGuncelleme nEkranGuncelleme = new EkranGuncelleme();
            nEkranGuncelleme.Show();
            this.Hide();
        }



        Panel pnlMenuSil = new Panel();
        private void btnMenuSil_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Visible = false;
            panel5.Visible = false;


            //Menu Sil Paneli
            pnlMenuSil.BackColor = Color.FromArgb(254, 255, 254);
            Controls.Add(pnlMenuSil);
            pnlMenuSil.Location = new Point(650, 350);
            pnlMenuSil.Size = new Size(700, 416);
            pnlMenuSil.TabIndex = 3;
            pnlMenuSil.AutoScroll = true;
            //
            //Menu Sil paneli iç başlık paneli
            //
            Panel pnl2 = new Panel();
            pnl2.BackColor = Color.FromArgb(248, 244, 244);
            pnlMenuSil.Controls.Add(pnl2);
            pnl2.Location = new Point(0, 0);
            pnl2.Size = new Size(700, 40);
            pnl2.TabIndex = 3;
            //
            //
            Label lbl1 = new Label();
            pnl2.Controls.Add(lbl1);
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.ForeColor = Color.FromArgb(123, 133, 147);
            lbl1.Location = new Point(16, 10);
            lbl1.Size = new Size(77, 21);
            lbl1.TabIndex = 0;
            lbl1.Text = "Menü Ad";
            //
            //
            Label lbl2 = new Label();
            pnl2.Controls.Add(lbl2);
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.ForeColor = Color.FromArgb(123, 133, 147);
            lbl2.Location = new Point(242, 10);
            lbl2.Size = new Size(121, 21);
            lbl2.TabIndex = 2;
            lbl2.Text = "Menü Açıklama";
            //
            // paneli kapatan buton.
            //
            Button btnMenuSilClose = new Button();
            pnl2.Controls.Add(btnMenuSilClose);
            btnMenuSilClose.FlatAppearance.BorderSize = 0;
            btnMenuSilClose.FlatStyle = FlatStyle.Flat;
            btnMenuSilClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnMenuSilClose.ForeColor = Color.FromArgb(238, 0, 0);
            btnMenuSilClose.Location = new Point(660, 3);
            btnMenuSilClose.Size = new Size(22, 28);
            btnMenuSilClose.TabIndex = 3;
            btnMenuSilClose.Text = "❌";
            btnMenuSilClose.UseVisualStyleBackColor = true;
            btnMenuSilClose.Click += btnMenuSilClose_Clik;


            int y = 56;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM MENULER", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Label lblMenuAd = new Label();
                pnlMenuSil.Controls.Add(lblMenuAd);
                lblMenuAd.AutoSize = true;
                lblMenuAd.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
                lblMenuAd.Location = new Point(3, y);
                lblMenuAd.Size = new Size(116, 17);
                lblMenuAd.TabIndex = 1;
                lblMenuAd.Text = dr["isim"].ToString();
                //
                //
                Label lblMenuAciklama = new Label();
                pnlMenuSil.Controls.Add(lblMenuAciklama);
                lblMenuAciklama.AutoEllipsis = true;
                lblMenuAciklama.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
                lblMenuAciklama.Location = new Point(227, y);
                lblMenuAciklama.Size = new Size(116, 17);
                lblMenuAciklama.TabIndex = 7;
                lblMenuAciklama.Text = dr["aciklama"].ToString();
                //
                //
                Button btnPnlMenuSil = new Button();
                pnlMenuSil.Controls.Add(btnPnlMenuSil);
                btnPnlMenuSil.FlatAppearance.BorderSize = 0;
                btnPnlMenuSil.FlatStyle = FlatStyle.Flat;
                btnPnlMenuSil.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
                btnPnlMenuSil.ForeColor = Color.Red;
                btnPnlMenuSil.Location = new Point(551, y - 10);
                btnPnlMenuSil.Size = new Size(66, 29);
                btnPnlMenuSil.TabIndex = 4;
                btnPnlMenuSil.Text = "Sil";
                btnPnlMenuSil.UseVisualStyleBackColor = true;
                btnPnlMenuSil.Click += btnPnlMenuSil_Clik;
                btnPnlMenuSil.Name = dr["isim"].ToString();
                y += 39;
            }
            conn.Close();

        }


        private void btnPnlMenuSil_Clik(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            string message = "Menüyü silmek istediğinize emin misiniz?";
            string title = "Menü Sil";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM MENULER WHERE isim='" + btn.Name + "'", conn);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("DROP TABLE " + btn.Name, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Menü başarılı bir şekilde silindi..", "Menü Sil");
                conn.Close();
                pnlMenuSil.Controls.Clear();
                btnMenuSil_Click(sender, e);
            }
        }

        private void btnMenuSilClose_Clik(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            pnlMenuSil.Controls.Clear();
            panel4.Controls.Clear();
            panel4.Visible = true;
            panel5.Visible = true;

            EkranGuncelleme nEkranGuncelleme = new EkranGuncelleme();
            nEkranGuncelleme.Show();
            this.Hide();

        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            EkranSatisTakip nEkranSatisTakip = new EkranSatisTakip();
            nEkranSatisTakip.Show();
            this.Hide();
        }
    }
}
