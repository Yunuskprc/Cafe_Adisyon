using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Cafe_Adisyon.Properties;
using System.Resources;


namespace Cafe_Adisyon
{
    public partial class EkranMasa : Form
    {
        public EkranMasa()
        {
            InitializeComponent();
        }
        // to do -> masa rengi sorununu çözümü ✓✓
        // to do -> siparis ekleme sayfası kapatıldıktan sonra sol sekmedeki masa bilgileri(yapıldı) ve siparis bilgilerini gösterecek metot. ✓✓
        // to do -> sol alt ekranda ödeme işlemleri ✓✓
        // to do -> fiş yazdırma ✓✓
        // to do -> masa ekleme çıkarma ✓✓

        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Cafe_Adisyon;Trusted_Connection=True;");
        DateTime dt = DateTime.Now;

        /// <summary>
        /// Ürünün fiyat değişkenini tutar ve daha sağlıklı hesap yapmayı sağlar.
        /// </summary>
        int urunFiyat = 0;

        private void EkranMasa_Load(object sender, EventArgs e)
        {
            TimerDate.Start();
            MasalariBastir();
        }

        // sol pencere tuşlarına kodlar yazılacak
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

        private void btnGuncelleme_Click(object sender, EventArgs e)
        {

        }

        private void btnStok_Click(object sender, EventArgs e)
        {

        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {

        }

        private void TimerDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            lblDate.Visible = true;
        }


        //
        //
        //

        List<Label> listLblDk = new List<Label>();
        List<Label> listLblFiyat = new List<Label>();
        List<Button> listBtnMasa = new List<Button>();

        private void MasalariBastir()
        {
            pnlMain.Controls.Clear();
            listBtnMasa.Clear();
            listLblDk.Clear();
            listLblFiyat.Clear();
            int x = 10, y = 10;
            int sayac = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM MASALAR", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Button btn = new Button();
                pnlMain.Controls.Add(btn);
                btn.Size = new Size(235, 130);
                if (x < 1400)
                {
                    btn.Location = new Point(x, y);
                    x += 240;
                }
                else
                {
                    x = 10; y += 135;
                    btn.Location = new Point(x, y);
                }
                btn.BackColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Text = "MASA" + dr["masaId"].ToString();
                btn.TextAlign = ContentAlignment.TopCenter;
                btn.Font = new Font("arial", 12, FontStyle.Bold);
                btn.ForeColor = Color.Black;

                Label lblDk = new Label();
                btn.Controls.Add(lblDk);
                lblDk.Text = dr["masaOturmaSuresi"].ToString() + " dakika";
                lblDk.Location = new Point(97, 60);
                lblDk.ForeColor = Color.Black;
                lblDk.Font = new Font("arial", 8);
                lblDk.BackColor = Color.Transparent;

                Label lblFiyat = new Label();
                btn.Controls.Add(lblFiyat);
                lblFiyat.Text = dr["fiyat"].ToString() + " TL";
                lblFiyat.Location = new Point(105, 90);
                lblFiyat.ForeColor = Color.Black;
                lblFiyat.Font = new Font("arial", 8);
                lblFiyat.BackColor = Color.Transparent;

                btn.Click += new EventHandler(buttonCode);

                listBtnMasa.Add(btn);
                listLblDk.Add(lblDk);
                listLblFiyat.Add(lblFiyat);
                sayac++;
            }

            //
            // Masa Ekle tuşu ve Masa Sil tuşu kodları
            //
            Button btnMasaEkle = new Button();
            pnlMain.Controls.Add(btnMasaEkle);
            btnMasaEkle.BackColor = Color.FromArgb(0, 185, 169);
            btnMasaEkle.BackgroundImage = Cafe_Adisyon.Properties.Resources.btnMasaEkle;
            btnMasaEkle.FlatAppearance.BorderSize = 0;
            btnMasaEkle.FlatStyle = FlatStyle.Flat;
            btnMasaEkle.ForeColor = SystemColors.Control;
            btnMasaEkle.Location = new Point(1158, 938);
            btnMasaEkle.Size = new Size(110, 50);
            btnMasaEkle.TabIndex = 0;
            btnMasaEkle.Text = "Masa Ekle";
            btnMasaEkle.UseVisualStyleBackColor = false;
            btnMasaEkle.Visible = true;
            btnMasaEkle.Click += btnMasaEkle_Clik;

            Button btnMasaSil = new Button();
            pnlMain.Controls.Add(btnMasaSil);
            btnMasaSil.BackColor = Color.FromArgb(144, 52, 82);
            btnMasaSil.BackgroundImage = Cafe_Adisyon.Properties.Resources.btnMasaSil;
            btnMasaSil.FlatAppearance.BorderSize = 0;
            btnMasaSil.FlatStyle = FlatStyle.Flat;
            btnMasaSil.ForeColor = SystemColors.Control;
            btnMasaSil.Location = new Point(1304, 938);
            btnMasaSil.Size = new Size(110, 50);
            btnMasaSil.TabIndex = 1;
            btnMasaSil.Text = "Masa Sil";
            btnMasaSil.UseVisualStyleBackColor = false;
            btnMasaSil.Visible = true;
            btnMasaSil.Click += btnMasaSil_Clik;

            conn.Close();
            MasaGuncelle();
            timerUpdate.Start();
        }



        /// <summary>
        /// +1 Masa Ekler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMasaEkle_Clik(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string mesaj = "Masa eklemek istiyor musunuz?";
            string baslik = "Masa Ekleme";
            MessageBoxButtons buttonMB = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(mesaj, baslik, buttonMB);
            if (result == DialogResult.Yes)
            {
                int count = RowsCount("MASALAR") + 1;
                conn.Open();
                SqlCommand cmd = new SqlCommand("CREATE TABLE MASA"+count+"(masaId int,kategoriId int,isim nvarchar(50),fiyat int,siparisSayisi int)",conn);
                cmd.ExecuteNonQuery();
                // Tablo oluşturuldu Masalar tablosunda göstermek kaldı.
                cmd = new SqlCommand("insert into MASALAR(masaId,masaDoluluk,masaOturmaSuresi,fiyat) values ("+count+",0,0,0)",conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                mesaj = "Masa Eklendi...";
                MessageBox.Show(mesaj, baslik);
                MasalariBastir();
            }
        }

        /// <summary>
        /// -1 masa siler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMasaSil_Clik(object sender,EventArgs e)
        {
            Button btn = sender as Button;
            string mesaj = "Masayı kaldırmak istiyor musunuz?";
            string baslik = "Masa Kaldırma";
            MessageBoxButtons buttonMB = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(mesaj, baslik, buttonMB);
            if (result == DialogResult.Yes)
            {
                int count = RowsCount("MASALAR");
                conn.Open();
                SqlCommand cmd = new SqlCommand("DROP TABLE MASA" + count, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM MASALAR WHERE masaId="+count, conn);
                cmd.ExecuteNonQuery();
                mesaj = "Masa Kaldırıldı...";
                MessageBox.Show(mesaj, baslik);
                conn.Close();
                MasalariBastir();
            }
        }




        /// <summary>
        /// Dolu olan masaların arka plan rengini değiştirir.
        /// </summary>
        private void MasaGuncelle()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM MASALAR", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int sayac = 0;
            while (dr.Read())
            {
                if (dr["masaDoluluk"].ToString() == "1")
                {
                    listBtnMasa[sayac].BackColor = System.Drawing.Color.FromArgb(255, 86, 86);
                }
                sayac++;
            }
            conn.Close();
        }

        /// <summary>
        /// Masaların oturma süresini okur ve günceller.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM MASALAR", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int sayac = 1;
            List<int> masaSure = new List<int>();
            List<int> masaYer = new List<int>();
            while (dr.Read())
            {
                if (dr["masaDoluluk"].ToString() == "1")
                {
                    masaSure.Add(Int16.Parse(dr["masaOturmaSuresi"].ToString()) + 1);
                    masaYer.Add(sayac);
                }
                sayac++;
            }
            conn.Close();

            conn.Open();

            for (int i = 0; i < masaSure.Count; i++)
            {
                SqlCommand cmd2 = new SqlCommand("UPDATE MASALAR set masaOturmaSuresi='" + masaSure[i].ToString() + "' WHERE masaID='" + masaYer[i].ToString() + "'", conn);
                cmd2.ExecuteNonQuery();
            }

            conn.Close();
            masaSure.Clear();
            masaYer.Clear();

            pnlMain.Controls.Clear();
            MasalariBastir();
        }



        // global tanımlanma sebebi dinamik yapıda nesneler üretilemediği için diğer metotlarda kullanamıyoruz. Kullanamabilmek için global tanımlandı.
        Panel pnlSiparis = new Panel();
        ComboBox cmbBxSiparisKategori = new ComboBox();
        ComboBox cmbBxSiparisUrun = new ComboBox();
        ComboBox cmbBxSiparisCarpan = new ComboBox();
        Label lblSiparisFiyat = new Label();
        Label lblMasaAd = new Label();
        Label lblSiparisEkleDurum = new Label(); // siparis eklendiğinde visiable true olacak.

        /// <summary>
        /// Masalara Tıklandığında Sipraiş verme Panelini oluşturur. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCode(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            pnlSiparis.Visible = true;
            pnlMain.Controls.Add(pnlSiparis);


            pnlSiparis.Size = new Size(600, 400);
            pnlSiparis.Location = new Point(300, 275);
            pnlSiparis.BackColor = System.Drawing.Color.FromArgb(226, 226, 226);
            //
            //
            lblMasaAd = new Label();
            pnlSiparis.Controls.Add(lblMasaAd);
            lblMasaAd.AutoSize = true;
            lblMasaAd.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblMasaAd.Location = new Point(273, 24);
            lblMasaAd.Size = new Size(99, 30);
            lblMasaAd.TabIndex = 13;
            lblMasaAd.Text = btn.Text;
            //
            //
            Label lbl1 = new Label();
            lbl1.AutoSize = true;
            pnlSiparis.Controls.Add(lbl1);
            lbl1.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl1.Location = new Point(61, 88);
            lbl1.Size = new Size(87, 25);
            lbl1.TabIndex = 0;
            lbl1.Text = "Kategori:";
            //
            //
            Label lbl2 = new Label();
            pnlSiparis.Controls.Add(lbl2);
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl2.Location = new Point(90, 126);
            lbl2.Size = new Size(58, 25);
            lbl2.TabIndex = 2;
            lbl2.Text = "Ürün:";
            //
            //
            Label lbl3 = new Label();
            pnlSiparis.Controls.Add(lbl3);
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl3.Location = new Point(59, 163);
            lbl3.Size = new Size(89, 25);
            lbl3.TabIndex = 5;
            lbl3.Text = "Çarpan:";
            //
            //
            Label lbl4 = new Label();
            pnlSiparis.Controls.Add(lbl4);
            lbl4.AutoSize = true;
            lbl4.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl4.Location = new Point(71, 200);
            lbl4.Size = new Size(89, 25);
            lbl4.TabIndex = 5;
            lbl4.Text = "Fiyat:";

            //
            //combobox kdoları
            //
            cmbBxSiparisKategori = new ComboBox();
            pnlSiparis.Controls.Add(cmbBxSiparisKategori);
            cmbBxSiparisKategori.FormattingEnabled = true;
            cmbBxSiparisKategori.Items.Clear();

            SqlCommand cmd = new SqlCommand("SELECT *FROM MENULER", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBxSiparisKategori.Items.Add(dr["isim"].ToString());
            }
            conn.Close();

            cmbBxSiparisKategori.Location = new Point(178, 90);
            cmbBxSiparisKategori.Size = new Size(140, 23);
            cmbBxSiparisKategori.TabIndex = 1;
            cmbBxSiparisKategori.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbBxSiparisKategori.SelectedIndexChanged += cmbBxSiparisKategori_SelectedIndexChanged;
            //
            //
            cmbBxSiparisUrun = new ComboBox();
            pnlSiparis.Controls.Add(cmbBxSiparisUrun);
            cmbBxSiparisUrun.FormattingEnabled = true;
            cmbBxSiparisUrun.Location = new Point(178, 128);
            cmbBxSiparisUrun.Size = new Size(140, 23);
            cmbBxSiparisUrun.TabIndex = 3;
            cmbBxSiparisUrun.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbBxSiparisUrun.SelectedIndexChanged += cmbBxSiparisUrun_SelectedIndexChanged;
            //
            //
            cmbBxSiparisCarpan = new ComboBox();
            pnlSiparis.Controls.Add(cmbBxSiparisCarpan);
            cmbBxSiparisCarpan.FormattingEnabled = true;
            cmbBxSiparisCarpan.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbBxSiparisCarpan.Location = new Point(178, 164);
            cmbBxSiparisCarpan.Size = new Size(140, 23);
            cmbBxSiparisCarpan.TabIndex = 8;
            cmbBxSiparisCarpan.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbBxSiparisCarpan.SelectedIndexChanged += cmbBxSiparisCarpan_SelectedIndexChanged;
            //
            // Buttonlar
            //
            Button btnSiparisTemizle = new Button();
            pnlSiparis.Controls.Add(btnSiparisTemizle);
            btnSiparisTemizle.BackColor = Color.FromArgb(245, 171, 47);
            btnSiparisTemizle.FlatAppearance.BorderSize = 0;
            btnSiparisTemizle.FlatStyle = FlatStyle.Flat;
            btnSiparisTemizle.Location = new Point(91, 290);
            btnSiparisTemizle.Size = new Size(87, 32);
            btnSiparisTemizle.TabIndex = 11;
            btnSiparisTemizle.UseVisualStyleBackColor = false;
            btnSiparisTemizle.Text = "Temizle";
            btnSiparisTemizle.Click += btnSiparisTemizle_Click;
            //
            //
            Button btnSiparisEkle = new Button();
            pnlSiparis.Controls.Add(btnSiparisEkle);
            btnSiparisEkle.BackColor = Color.FromArgb(245, 171, 47);
            btnSiparisEkle.FlatAppearance.BorderSize = 0;
            btnSiparisEkle.FlatStyle = FlatStyle.Flat;
            btnSiparisEkle.Location = new Point(215, 290);
            btnSiparisEkle.Size = new Size(87, 32);
            btnSiparisEkle.TabIndex = 4;
            btnSiparisEkle.Text = "Ekle";
            btnSiparisEkle.UseVisualStyleBackColor = false;
            btnSiparisEkle.Click += btnSiparisEkle_Click;
            //
            //
            Button btnSiparisEkleClose = new Button();
            pnlSiparis.Controls.Add(btnSiparisEkleClose);
            btnSiparisEkleClose.BackgroundImage = Properties.Resources.buttonClose;
            btnSiparisEkleClose.FlatAppearance.BorderSize = 0;
            btnSiparisEkleClose.FlatStyle = FlatStyle.Flat;
            btnSiparisEkleClose.Location = new Point(563, 8);
            btnSiparisEkleClose.Size = new Size(20, 20);
            btnSiparisEkleClose.TabIndex = 15;
            btnSiparisEkleClose.UseVisualStyleBackColor = true;
            btnSiparisEkleClose.Click += btnSiparisEkleClose_Click;
            //
            lblSiparisFiyat = new Label();
            pnlSiparis.Controls.Add(lblSiparisFiyat);
            lblSiparisFiyat.AutoSize = true;
            lblSiparisFiyat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblSiparisFiyat.Location = new Point(178, 202);
            lblSiparisFiyat.Size = new Size(0, 25);
            lblSiparisFiyat.TabIndex = 12;
            //
            //
            pnlSiparis.Controls.Add(lblSiparisEkleDurum);
            lblSiparisEkleDurum.AutoSize = true;
            lblSiparisEkleDurum.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSiparisEkleDurum.Location = new Point(415, 317);
            lblSiparisEkleDurum.Size = new Size(111, 21);
            lblSiparisEkleDurum.TabIndex = 16;
            lblSiparisEkleDurum.Text = "Sipariş Eklendi";
            lblSiparisEkleDurum.Visible = false;
            //
            //
            PictureBox pictureBox1 = new PictureBox();
            pnlSiparis.Controls.Add(pictureBox1);
            pictureBox1.Image = Properties.Resources.SiparisEklemeFoto;
            pictureBox1.Location = new Point(392, 106);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            //

        }


        /// <summary>
        /// Sipariş verme panelinde ki comboBoxların methodudur.Kategoriye göre ürünleri diğer combobox a taşır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBxSiparisKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbBx = sender as ComboBox;
            cmbBxSiparisUrun.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT *FROM " + cmbBx.Text, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBxSiparisUrun.Items.Add(dr["isim"].ToString());
            }
            conn.Close();
        }

        /// <summary>
        /// Sipariş verme panelindeki comboBoxların methodudur.Ürün seçimine göre ürünün fiyat değerini urunFiyat değişkenine atar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBxSiparisUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbBx = sender as ComboBox;
            SqlCommand cmd = new SqlCommand("SELECT *FROM " + cmbBxSiparisKategori.Text + " WHERE isim='" + cmbBxSiparisUrun.Text + "'", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                urunFiyat = Int16.Parse(dr["fiyat"].ToString());
            }
            conn.Close();
            lblSiparisFiyat.Text = urunFiyat.ToString();
        }

        /// <summary>
        /// Sipariş verme panelindeki ComboBoxların methodudur.Çarpan sayısına göre toplam fiyatı label da saklar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBxSiparisCarpan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbBx = sender as ComboBox;
            int s1 = Int16.Parse(cmbBx.Text);

            lblSiparisFiyat.Text = (s1 * urunFiyat).ToString();
        }

        /// <summary>
        /// Siparis ekleme panelindeki tüm verileri temizler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSiparisTemizle_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            cmbBxSiparisKategori.Text = "";
            cmbBxSiparisUrun.Text = "";
            cmbBxSiparisCarpan.Text = "";
            lblSiparisFiyat.Text = "";
        }

        /// <summary>
        /// Siparis ekleme panelinde seçili yemeği ilgili tablolara ekler ve masayı dolu gösterir. Toplam dk ve fiyat labellerda gözükür.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int kategoriId = 0;
            string deger = "";
            int toplamfiyat = 0;
            if (cmbBxSiparisUrun.Text != "" && cmbBxSiparisKategori.Text != "" && cmbBxSiparisCarpan.Text != "")
            {
                conn.Open();
                // kategoriId değişkenine ulaştık.
                SqlCommand cmd = new SqlCommand("SELECT *FROM MENULER WHERE isim='" + cmbBxSiparisKategori.Text + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    kategoriId = Int16.Parse(dr["kategoriId"].ToString());
                }

                cmd.Dispose(); dr.Close();

                cmd = new SqlCommand("insert into " + lblMasaAd.Text + "(kategoriId,isim,fiyat,siparisSayisi) values (" + kategoriId + ",'" + cmbBxSiparisUrun.Text + "'," + urunFiyat + "," + Int16.Parse(cmbBxSiparisCarpan.Text) + ")", conn);
                cmd.ExecuteNonQuery();

                // Masa tablosuna eklendi


                deger = lblMasaAd.Text.Substring(4);


                // MASALAR tablosunda güncellemeler yapıldı
                cmd = new SqlCommand("SELECT *FROM MASALAR WHERE masaId=" + deger, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    toplamfiyat = Int16.Parse(dr["fiyat"].ToString());
                }
                toplamfiyat += urunFiyat * Int16.Parse(cmbBxSiparisCarpan.Text);
                dr.Close();
                cmd = new SqlCommand("update MASALAR set masaDoluluk=1, fiyat=" + toplamfiyat.ToString() + " WHERE masaId=" + deger, conn);
                cmd.ExecuteNonQuery();



                
                lblSiparisEkleDurum.Visible = true;
                conn.Close();
                
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurun!");
            }
        }

        /// <summary>
        /// Siparis ekleme panelini kapatır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSiparisEkleClose_Click(object sender, EventArgs e)
        {
            MasalariBastir();
            pnlSiparis.Controls.Clear();
            pnlSiparis.Visible = false;
            lblSiparisEkleDurum.Visible = false;
            pnlMasaBilgileri();
            lblMasaPnl1MasaAd.Text = lblMasaAd.Text;
            lblMasaPnl1MasaAd.Visible = true;
            pnlMasaOdeme.Visible = true;

            SqlCommand cmd = new SqlCommand("SELECT *FROM MASALAR WHERE masaID=" + lblMasaAd.Text.Substring(4), conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblMasaPnl4Toplam.Visible = true;
                label2.Visible = true;
                lblMasaPnl4Toplam.Text = dr["fiyat"].ToString();
            }
            conn.Close();
        }

        /// <summary>
        /// Bu metot masanın bilgilerini ilgili panelde gösterir
        /// </summary>
        private void pnlMasaBilgileri()
        {
            panel4.Controls.Clear();
            pnlMasaDetay.Visible = true;
            panel4.Visible = true;
            // masa ad labelleri
            Label lbl1 = new Label();
            panel4.Controls.Add(lbl1);
            lbl1.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.AutoSize = true;
            lbl1.Location = new Point(6, 27);
            lbl1.Size = new Size(65, 18);
            lbl1.TabIndex = 0;
            lbl1.Text = "Masa Adı:";
            //
            //
            Label lbl2 = new Label();
            panel4.Controls.Add(lbl2);
            lbl2.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.AutoSize = true;
            lbl2.Location = new Point(76, 26);
            lbl2.Size = new Size(65, 18);
            lbl2.TabIndex = 0;
            lbl2.Text = lblMasaAd.Text;
            //
            // fiyat labelleri
            //
            Label lbl3 = new Label();
            panel4.Controls.Add(lbl3);
            lbl3.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.AutoSize = true;
            lbl3.Location = new Point(166, 27);
            lbl3.Size = new Size(83, 18);
            lbl3.TabIndex = 0;
            lbl3.Text = "Toplam Ücret:";
            //
            //
            Label label4 = new Label();
            panel4.Controls.Add(label4);
            label4.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.AutoSize = true;
            label4.Location = new Point(266, 27);
            label4.Size = new Size(65, 18);
            label4.TabIndex = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM MASALAR WHERE masaID=" + lblMasaAd.Text.Substring(4), conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                label4.Text = dr["fiyat"].ToString();
            conn.Close(); dr.Close();
            //
            // Oturma Süresi Labelleri
            //
            Label label5 = new Label();
            panel4.Controls.Add(label5);
            label5.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.AutoSize = true;
            label5.Location = new Point(6, 69);
            label5.Size = new Size(83, 18);
            label5.TabIndex = 0;
            label5.Text = "Oturma Süresi:";
            //
            //
            Label label6 = new Label();
            panel4.Controls.Add(label6);
            label6.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.AutoSize = true;
            label6.Location = new Point(106, 69);
            label6.Size = new Size(83, 18);
            label6.TabIndex = 0;
            conn.Open();
            cmd = new SqlCommand("SELECT *FROM MASALAR WHERE masaID=" + lblMasaAd.Text.Substring(4), conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                label6.Text = dr["masaOturmaSuresi"].ToString();
            conn.Close();

            pnlMasaSiparis();
        }

        /// <summary>
        /// Bu metot masadaki tüm siparişlerin detaylarını ilgili panelde sıralayarak gösterir
        /// </summary>
        private void pnlMasaSiparis()
        {
            panel3.Controls.Clear();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM " + lblMasaAd.Text, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int sayac = 0;
            while (dr.Read())
            {
                Panel pnlSiparis = new Panel();
                panel3.Controls.Add(pnlSiparis);
                pnlSiparis.BackColor = SystemColors.ButtonHighlight;
                pnlSiparis.BorderStyle = BorderStyle.FixedSingle;
                pnlSiparis.Location = new Point(0, sayac);
                pnlSiparis.Size = new Size(350, 70);
                pnlSiparis.TabIndex = 7;
                pnlSiparis.Visible = true;
                //
                //
                Label lblYemekAd = new Label();
                pnlSiparis.Controls.Add(lblYemekAd);
                lblYemekAd.AutoSize = true;
                lblYemekAd.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
                lblYemekAd.ForeColor = Color.Firebrick;
                lblYemekAd.Location = new Point(46, 7);
                lblYemekAd.Size = new Size(80, 19);
                lblYemekAd.TabIndex = 1;
                lblYemekAd.Text = dr["isim"].ToString();
                //
                //
                Label lblYemekAdet = new Label();
                pnlSiparis.Controls.Add(lblYemekAdet);
                lblYemekAdet.AutoSize = true;
                lblYemekAdet.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
                lblYemekAdet.ForeColor = Color.Firebrick;
                lblYemekAdet.Location = new Point(17, 26);
                lblYemekAdet.Size = new Size(23, 26);
                lblYemekAdet.TabIndex = 0;
                lblYemekAdet.Text = dr["siparisSayisi"].ToString();
                //
                //
                Label lblStatic = new Label();
                pnlSiparis.Controls.Add(lblStatic);
                lblStatic.AutoSize = true;
                lblStatic.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
                lblStatic.ForeColor = Color.Firebrick;
                lblStatic.Location = new Point(46, 35); ;
                lblStatic.Size = new Size(28, 14);
                lblStatic.TabIndex = 5;
                lblStatic.Text = "A.D.";
                //
                //
                Label lblStatic2 = new Label();
                pnlSiparis.Controls.Add(lblStatic2);
                lblStatic2.AutoSize = true;
                lblStatic2.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
                lblStatic2.ForeColor = Color.Firebrick;
                lblStatic2.Location = new Point(219, 28);
                lblStatic2.Size = new Size(14, 14);
                lblStatic2.TabIndex = 2;
                lblStatic2.Text = "X";
                //
                //
                Label lblYemekFiyat = new Label();
                pnlSiparis.Controls.Add(lblYemekFiyat);
                lblYemekFiyat.AutoSize = true;
                lblYemekFiyat.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
                lblYemekFiyat.ForeColor = Color.Firebrick;
                lblYemekFiyat.Location = new Point(268, 10);
                lblYemekFiyat.Size = new Size(45, 19);
                lblYemekFiyat.TabIndex = 3;
                lblYemekFiyat.Text = dr["fiyat"].ToString();
                //
                //
                Label lblSiparisToplamFiyat = new Label();
                pnlSiparis.Controls.Add(lblSiparisToplamFiyat);
                lblSiparisToplamFiyat.AutoSize = true;
                lblSiparisToplamFiyat.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
                lblSiparisToplamFiyat.ForeColor = Color.Firebrick;
                lblSiparisToplamFiyat.Location = new Point(268, 38);
                lblSiparisToplamFiyat.Size = new Size(53, 19);
                lblSiparisToplamFiyat.TabIndex = 4;
                lblSiparisToplamFiyat.Text = (Int16.Parse(dr["fiyat"].ToString()) * Int16.Parse(dr["siparisSayisi"].ToString())).ToString();

                sayac += 70;
            }
            conn.Close();

        }




        private void btnOdemeNakit_Click(object sender, EventArgs e)
        {
            fisOlustur();
        }

        private void btnOdemeKart_Click(object sender, EventArgs e)
        {
            fisOlustur();
        }

        private void btnOdemeQR_Click(object sender, EventArgs e)
        {
            fisOlustur();
        }




        // her fiş oluştuğunda bu panel fiş temizlenecek.
        Panel pnlFis = new Panel();


        /// <summary>
        ///  Hesabı ödedikten sonra fiş oluşturur ve ekrana bastırır. Masayı siparislerini temizler ve Satiş tablosuna kaydeder.
        /// </summary>
        private void fisOlustur()
        {
            int count = RowsCount("SatisTakip");
            count++;
            string tarih = dt.Year + "-" + dt.Month + "-" + dt.Day;
            int fiyat = 0;

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT *FROM MASALAR WHERE masaId=" + lblMasaAd.Text.Substring(4), conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                fiyat = Int16.Parse(dr["fiyat"].ToString());
            }
            dr.Close();

            cmd = new SqlCommand("insert into SatisTakip(adisyonNo,tarih,fiyat) values (" + count + ",'" + tarih + "'," + fiyat + ")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            //
            // veritabanında SatisTakip Tablosuna ekleme yapıldı. Fiş oluşturulup Masa değerleri sıfırlanacak.
            //

            pnlMain.Controls.Add(pnlFis);
            pnlFis.BringToFront();
            pnlFis.BackColor = Color.FromArgb(232, 234, 234);
            pnlFis.BorderStyle = BorderStyle.FixedSingle;
            pnlFis.Location = new Point(404, 219);
            pnlFis.Size = new Size(357, 555);
            pnlFis.TabIndex = 176;
            pnlFis.Visible = true;
            //
            //
            PictureBox pctBxLogo = new PictureBox();
            pnlFis.Controls.Add(pctBxLogo);
            pctBxLogo.Image = Properties.Resources.YEDLogo;
            pctBxLogo.Location = new Point(126, 10);
            pctBxLogo.Size = new Size(100, 100);
            pctBxLogo.TabIndex = 0;
            pctBxLogo.TabStop = false;
            //
            //pnlFis içinde stabil olan tarih ve masa adı yazan panel bilgileri
            //
            Panel pnlDateMasaAd = new Panel();
            pnlFis.Controls.Add(pnlDateMasaAd);
            pnlDateMasaAd.BorderStyle = BorderStyle.FixedSingle;
            pnlDateMasaAd.Location = new Point(20, 137);
            pnlDateMasaAd.Size = new Size(313, 29);
            pnlDateMasaAd.TabIndex = 1;
            //
            //
            Label lblFisDate = new Label();
            pnlDateMasaAd.Controls.Add(lblFisDate);
            lblFisDate.AutoSize = true;
            lblFisDate.Location = new Point(5, 7);
            lblFisDate.Size = new Size(61, 15);
            lblFisDate.TabIndex = 0;
            lblFisDate.Text = DateTime.Now.ToString();
            //
            //
            Label lbl1 = new Label();
            pnlDateMasaAd.Controls.Add(lblFisDate);
            lbl1.AutoSize = true;
            lbl1.Location = new Point(191, 7);
            lbl1.Size = new Size(59, 15);
            lbl1.TabIndex = 3;
            lbl1.Text = "Masa Adı:";
            //
            //
            Label lblFisMasaAd = new Label();
            pnlDateMasaAd.Controls.Add(lblFisMasaAd);
            lblFisMasaAd.AutoSize = true;
            lblFisMasaAd.Location = new Point(250, 7);
            lblFisMasaAd.Size = new Size(47, 15);
            lblFisMasaAd.TabIndex = 4;
            lblFisMasaAd.Text = lblMasaAd.Text;
            //
            // ürünlerin, adetlerin ve fiyatlarının başlık konumlandırılması
            //
            Label lbl2 = new Label();
            pnlFis.Controls.Add(lbl2);
            lbl2.AutoSize = true;
            lbl2.Location = new Point(26, 186);
            lbl2.Size = new Size(46, 15);
            lbl2.TabIndex = 2;
            lbl2.Text = "Ürünler";
            //
            //
            Label lbl3 = new Label();
            pnlFis.Controls.Add(lbl3);
            lbl3.AutoSize = true;
            lbl3.Location = new Point(212, 186);
            lbl3.Size = new Size(32, 15);
            lbl3.TabIndex = 3;
            lbl3.Text = "Adet";
            //
            //
            Label lbl4 = new Label();
            pnlFis.Controls.Add(lbl4);
            lbl4.AutoSize = true;
            lbl4.Location = new Point(277, 186);
            lbl4.Size = new Size(34, 15);
            lbl4.TabIndex = 4;
            lbl4.Text = "Tutar";
            //
            // Veritabanında sorgu yaparak ürünleri fise yazdırma işlemini rahat göstermek için yapılan tasarım 
            //
            Label lbl5 = new Label();
            pnlFis.Controls.Add(lbl5);
            lbl5.AutoSize = true;
            lbl5.Location = new Point(15, 201);
            lbl5.Size = new Size(312, 15);
            lbl5.TabIndex = 6;
            lbl5.Text = "-------------------------------------------------------------";
            //
            //
            Label lbl6 = new Label();
            pnlFis.Controls.Add(lbl6);
            lbl6.AutoSize = true;
            lbl6.Location = new Point(15, 396);
            lbl6.Size = new Size(312, 15);
            lbl6.TabIndex = 39;
            lbl6.Text = "-------------------------------------------------------------";
            //
            // Veritabanında sorgu yaparak ürünleri fise yazdırma işlemi
            //
            Panel pnlFisUrunler = new Panel();
            pnlFis.Controls.Add(pnlFisUrunler);
            pnlFisUrunler.Location = new Point(24, 221);
            pnlFisUrunler.Size = new Size(310, 175);
            pnlFisUrunler.BackColor = Color.FromArgb(232, 234, 234);
            pnlFisUrunler.AutoScroll = true;

            conn.Open();
            cmd = new SqlCommand("SELECT *FROM " + lblMasaAd.Text, conn);
            dr = cmd.ExecuteReader();
            fiyat = 0;
            int y = 0; // masadaki siparişlerin konumunu değiştirmek için kullanılır.
            int ToplamUCret = 0; // Masanın toplam ücretini gösterir.
            while (dr.Read())
            {
                // konum işlemlerine bak
                Label lblFisUrunAd = new Label();
                pnlFisUrunler.Controls.Add(lblFisUrunAd);
                lblFisUrunAd.AutoSize = true;
                lblFisUrunAd.Location = new Point(0, y);
                lblFisUrunAd.Size = new Size(44, 15);
                lblFisUrunAd.TabIndex = 7;
                lblFisUrunAd.Text = dr["isim"].ToString();
                if (dr["isim"].ToString().Length > 20)
                    lblFisUrunAd.Font = new Font("Segoe UI", 7);
                else
                    lblFisUrunAd.Font = new Font("Segoe UI", 9);
                //
                Label lblFisUrunAdet = new Label();
                pnlFisUrunler.Controls.Add(lblFisUrunAdet);
                lblFisUrunAdet.AutoSize = true;
                lblFisUrunAdet.Location = new Point(200, y);
                lblFisUrunAdet.Size = new Size(13, 15);
                lblFisUrunAdet.TabIndex = 17;
                lblFisUrunAdet.Text = dr["siparisSayisi"].ToString();
                lblFisUrunAdet.Font = new Font("Segoe UI", 9);
                //
                fiyat = Int16.Parse(dr["siparisSayisi"].ToString()) * Int16.Parse(dr["fiyat"].ToString());
                //
                Label lblFisUrunTutar = new Label();
                pnlFisUrunler.Controls.Add(lblFisUrunTutar);
                lblFisUrunTutar.AutoSize = true;
                lblFisUrunTutar.Location = new Point(260, y);
                lblFisUrunTutar.Size = new Size(13, 15);
                lblFisUrunTutar.TabIndex = 27;
                lblFisUrunTutar.Text = fiyat.ToString();
                lblFisUrunTutar.Font = new Font("Segoe UI", 9);

                ToplamUCret += fiyat;
                y += 20;
            }
            conn.Close();

            //
            // Toplam ucreti gösterip fişi kapatma buttonunu eklemek kaldı.
            //

            Label lbl7 = new Label();
            pnlFis.Controls.Add(lbl7);
            lbl7.AutoSize = true;
            lbl7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl7.Location = new Point(81, 433);
            lbl7.Size = new Size(145, 21);
            lbl7.TabIndex = 43;
            lbl7.Text = "Ödenecek Toplam:";
            //
            Label lblOdencekUcret = new Label();
            pnlFis.Controls.Add(lblOdencekUcret);
            lblOdencekUcret.AutoSize = true;
            lblOdencekUcret.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblOdencekUcret.Location = new Point(224, 433);
            lblOdencekUcret.Size = new Size(37, 21);
            lblOdencekUcret.TabIndex = 45;
            lblOdencekUcret.Text = ToplamUCret.ToString();
            //
            Label lbl8 = new Label();
            pnlFis.Controls.Add(lbl8);
            lbl8.AutoSize = true;
            lbl8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl8.Location = new Point(107, 463);
            lbl8.Size = new Size(132, 21);
            lbl8.TabIndex = 44;
            lbl8.Text = "İyi Günler Dileriz.";



            Button btnFisClose = new Button();
            pnlFis.Controls.Add(btnFisClose);
            btnFisClose.BackgroundImage = Properties.Resources.closeButton1;
            btnFisClose.FlatAppearance.BorderSize = 0;
            btnFisClose.FlatStyle = FlatStyle.Flat;
            btnFisClose.ForeColor = SystemColors.ControlText;
            btnFisClose.Location = new Point(332, 3);
            btnFisClose.Size = new Size(20, 20);
            btnFisClose.TabIndex = 46;
            btnFisClose.UseVisualStyleBackColor = true;
            btnFisClose.Click += btnFisClose_Click;

            //
            //MasaX tablosunu temizleme MASALAR TABLOSUNDAN verileri güncelleme
            //
            conn.Open();

            cmd = new SqlCommand("DELETE FROM " + lblMasaAd.Text + "", conn);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("UPDATE MASALAR SET masaDoluluk=0, masaOturmaSuresi=0, fiyat=0 WHERE masaId=" + lblMasaAd.Text.Substring(4), conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            
        }

        /// <summary>
        /// Oluşturulan fişi kapatma metodudur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFisClose_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MasalariBastir();
            MasaGuncelle();
            pnlFis.Visible = false;
            pnlFis.Controls.Clear();
            panel3.Controls.Clear();
            panel4.Controls.Clear();
            lblMasaPnl1MasaAd.Text = "";
            lblMasaPnl4Toplam.Text = "";
            lblMasaPnl4Toplam.Visible = false;
            label2.Visible = false;

        }

        /// <summary>
        /// İlgili tablonun satır sayısını geri döndürür.
        /// </summary>
        /// <param name="tableName">Tablo Adı</param>
        /// <returns></returns>
        public int RowsCount(string tableName)
        {
            string stmt = "SELECT COUNT(*) FROM " + tableName;
            int count = 0;
            SqlCommand cmdCount = new SqlCommand(stmt, conn);
            conn.Open();
            count = (int)cmdCount.ExecuteScalar();
            conn.Close();
            return count;
        }

    }
}
