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

namespace Cafe_Adisyon
{
    public partial class EkranMasa : Form
    {
        public EkranMasa()
        {
            InitializeComponent();
        }

        // saat labeli güncellendikten sonra button rengi gidiyor ??.
        // siparis eklendikten sonra o masanın doluluk değerini 1 yapacaz fiyat değerini hem db hem de lbl da gösterecez. yapıldı
        // hata 1 alınıyor button rengini değiştiremiyoruz.

        // to do -> masa rengi sorununu çözümü
        // to do -> siparis ekleme sayfası kapatıldıktan sonra sol sekmedeki masa bilgileri ve siparis bilgilerini gösterecek metot.
        // to do -> sol alt ekranda ödeme işlemleri
        // to do -> fiş yazdırma
        // to do -> masa ekleme çıkarma

        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Cafe_Adisyon;Trusted_Connection=True;");
        DateTime dt;

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

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

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
            MasaGuncelle();
        }


        //
        //
        //

        List<Label> listLblDk = new List<Label>();
        List<Label> listLblFiyat = new List<Label>();
        List<Button> listBtnMasa = new List<Button>();

        private void MasalariBastir()
        {
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
            conn.Close();
            MasaGuncelle();
            timerUpdate.Start();
        }


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
            lbl4.Location = new Point(71,200);
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

            SqlCommand cmd = new SqlCommand("SELECT *FROM MENULER",conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbBxSiparisKategori.Items.Add(dr["isim"].ToString());
            }
            conn.Close();

            cmbBxSiparisKategori.Location = new Point(178, 90);
            cmbBxSiparisKategori.Size = new Size(124, 23);
            cmbBxSiparisKategori.TabIndex = 1;
            cmbBxSiparisKategori.SelectedIndexChanged += cmbBxSiparisKategori_SelectedIndexChanged;
            //
            //
            cmbBxSiparisUrun = new ComboBox();
            pnlSiparis.Controls.Add(cmbBxSiparisUrun);
            cmbBxSiparisUrun.FormattingEnabled = true;
            cmbBxSiparisUrun.Location = new Point(178, 128);
            cmbBxSiparisUrun.Size = new Size(124, 23);
            cmbBxSiparisUrun.TabIndex = 3;
            cmbBxSiparisUrun.SelectedIndexChanged += cmbBxSiparisUrun_SelectedIndexChanged;
            //
            //
            cmbBxSiparisCarpan = new ComboBox();
            pnlSiparis.Controls.Add(cmbBxSiparisCarpan);
            cmbBxSiparisCarpan.FormattingEnabled = true;
            cmbBxSiparisCarpan.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbBxSiparisCarpan.Location = new Point(178, 164);
            cmbBxSiparisCarpan.Size = new Size(124, 23);
            cmbBxSiparisCarpan.TabIndex = 8;
            cmbBxSiparisCarpan.SelectedIndexChanged += cmbBxSiparisCarpan_SelectedIndexChanged;
            //
            // Buttonlar
            //
            Button btnSiparisTemizle = new Button();
            pnlSiparis.Controls.Add(btnSiparisTemizle);
            btnSiparisTemizle.BackColor = Color.FromArgb(245, 171, 47);
            btnSiparisTemizle.FlatAppearance.BorderSize = 0;
            btnSiparisTemizle.FlatStyle = FlatStyle.Flat;
            btnSiparisTemizle.Location = new Point(91, 313);
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
            btnSiparisEkle.Location = new Point(215, 313);
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
            SqlCommand cmd = new SqlCommand("SELECT *FROM " + cmbBx.Text,conn);
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
        private void cmbBxSiparisUrun_SelectedIndexChanged(object sender,EventArgs e)
        {
            ComboBox cmbBx = sender as ComboBox;
            SqlCommand cmd  = new SqlCommand("SELECT *FROM " + cmbBxSiparisKategori.Text + " WHERE isim='" + cmbBxSiparisUrun.Text + "'",conn);
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

            lblSiparisFiyat.Text = (s1*urunFiyat).ToString();
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
            if (cmbBxSiparisUrun.Text != " " && cmbBxSiparisKategori.Text != " " && cmbBxSiparisCarpan.Text != " ")
            {
                conn.Open();
                // kategoriId değişkenine ulaştık.
                SqlCommand cmd = new SqlCommand("SELECT *FROM MENULER WHERE isim='" + cmbBxSiparisKategori.Text + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    kategoriId = Int16.Parse(dr["kategoriId"].ToString());
                }

                cmd.Dispose();dr.Close();

                cmd = new SqlCommand("insert into " + lblMasaAd.Text + "(kategoriId,isim,fiyat,siparisSayisi) values (" + kategoriId + ",'" + cmbBxSiparisUrun.Text + "'," + urunFiyat + "," + Int16.Parse(cmbBxSiparisCarpan.Text) +")", conn);
                cmd.ExecuteNonQuery();

                // Masa tablosuna eklendi

                
                 deger = lblMasaAd.Text.Substring(4);
                
                
                // MASALAR tablosunda güncellemeler yapıldı
                cmd = new SqlCommand("SELECT *FROM MASALAR WHERE masaId="+deger,conn);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    toplamfiyat = Int16.Parse(dr["fiyat"].ToString()) ;
                }
                toplamfiyat += urunFiyat * Int16.Parse(cmbBxSiparisCarpan.Text);
                dr.Close();
                cmd = new SqlCommand("update MASALAR set masaDoluluk=1, fiyat="+toplamfiyat.ToString()+" WHERE masaId="+deger,conn);
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
            pnlSiparis.Controls.Clear();
            pnlSiparis.Visible = false;
            lblSiparisEkleDurum.Visible=false;
        }
    
    
    }
}
