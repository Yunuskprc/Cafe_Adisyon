using Cafe_Adisyon.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cafe_Adisyon
{
    public partial class EkranSatisTakip : Form
    {
        public EkranSatisTakip()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Cafe_Adisyon;Trusted_Connection=True;");
        private void EkranUrunTakip_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Visible = true;
            DynamicObjet();
            anlikAy = DateTime.Now.Month;
            btnTumZamanlarSatis_Click(sender, e);

            if (ChartSorgulama(1))
                AylikGrafikOlusturma();
            else
                BosGrafik(1);

            if (ChartSorgulama(2))
                GunlukGrafikOlustur();
            else
                BosGrafik(2);
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void btnGuncelleme_Click(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Dinamik form yapısı oluşturmak için kullanılır.
        /// </summary>
        private void DynamicObjet()
        {
            Panel pnlGenelBilgiler = new Panel();
            this.Controls.Add(pnlGenelBilgiler);
            pnlGenelBilgiler.BackColor = Color.FromArgb(26, 24, 51);
            pnlGenelBilgiler.BackgroundImage = Cafe_Adisyon.Properties.Resources.deneme;
            pnlGenelBilgiler.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            pnlGenelBilgiler.ForeColor = SystemColors.ControlText;
            pnlGenelBilgiler.Location = new Point(190, 115);
            pnlGenelBilgiler.Name = "pnlGenelBilgiler";
            pnlGenelBilgiler.Size = new Size(520, 330);
            pnlGenelBilgiler.TabIndex = 10;
            //
            //label1
            //
            Label label1 = new Label();
            pnlGenelBilgiler.Controls.Add(label1);
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(43, 22);
            label1.Size = new Size(91, 20);
            label1.TabIndex = 0;
            label1.Text = "Toplam Ciro";
            // 
            // lblToplamCiro
            // 
            pnlGenelBilgiler.Controls.Add(lblToplamCiro);
            lblToplamCiro.AutoSize = true;
            lblToplamCiro.Font = new Font("Segoe UI Symbol", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblToplamCiro.ForeColor = SystemColors.ButtonFace;
            lblToplamCiro.Location = new Point(43, 57);
            lblToplamCiro.Size = new Size(178, 65);
            lblToplamCiro.TabIndex = 1;
            lblToplamCiro.Text = "5,97 M";
            // 
            // label4
            // 
            Label label4 = new Label();
            pnlGenelBilgiler.Controls.Add(label4);
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(43, 177);
            label4.Size = new Size(138, 20);
            label4.TabIndex = 2;
            label4.Text = "Satılan Ürün Adedi";
            // 
            // lblSatilanUrunAdet
            // 
            pnlGenelBilgiler.Controls.Add(lblSatilanUrunAdet);
            lblSatilanUrunAdet.AutoSize = true;
            lblSatilanUrunAdet.Font = new Font("Segoe UI Symbol", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblSatilanUrunAdet.ForeColor = SystemColors.ButtonFace;
            lblSatilanUrunAdet.Location = new Point(43, 216);
            lblSatilanUrunAdet.Size = new Size(109, 65);
            lblSatilanUrunAdet.TabIndex = 3;
            lblSatilanUrunAdet.Text = "412";
            // 
            // btnTumZamanlarSatis
            // 
            Button btnTumZamanlarSatis = new Button();
            pnlGenelBilgiler.Controls.Add(btnTumZamanlarSatis);
            btnTumZamanlarSatis.FlatAppearance.BorderColor = Color.White;
            btnTumZamanlarSatis.FlatStyle = FlatStyle.Flat;
            btnTumZamanlarSatis.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnTumZamanlarSatis.ForeColor = SystemColors.ButtonFace;
            btnTumZamanlarSatis.Location = new Point(370, 70);
            btnTumZamanlarSatis.Size = new Size(120, 31);
            btnTumZamanlarSatis.TabIndex = 4;
            btnTumZamanlarSatis.Text = "Tüm Zamanlar";
            btnTumZamanlarSatis.UseVisualStyleBackColor = true;
            btnTumZamanlarSatis.Click += btnTumZamanlarSatis_Click;
            // 
            // btnAylikSatis
            // 
            Button btnAylikSatis = new Button();
            pnlGenelBilgiler.Controls.Add(btnAylikSatis);
            btnAylikSatis.FlatAppearance.BorderColor = Color.White;
            btnAylikSatis.FlatStyle = FlatStyle.Flat;
            btnAylikSatis.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAylikSatis.ForeColor = SystemColors.ButtonFace;
            btnAylikSatis.Location = new Point(370, 150);
            btnAylikSatis.Size = new Size(120, 31);
            btnAylikSatis.TabIndex = 5;
            btnAylikSatis.Text = "Aylık Satış";
            btnAylikSatis.UseVisualStyleBackColor = true;
            btnAylikSatis.Click += btnAylikSatis_Click;
            // 
            // btnGunlukSatis
            // 
            Button btnGunlukSatis = new Button();
            pnlGenelBilgiler.Controls.Add(btnGunlukSatis);
            btnGunlukSatis.FlatAppearance.BorderColor = Color.White;
            btnGunlukSatis.FlatStyle = FlatStyle.Flat;
            btnGunlukSatis.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnGunlukSatis.ForeColor = SystemColors.ButtonFace;
            btnGunlukSatis.Location = new Point(370, 230);
            btnGunlukSatis.Size = new Size(120, 31);
            btnGunlukSatis.TabIndex = 6;
            btnGunlukSatis.Text = "Günlük Satış";
            btnGunlukSatis.UseVisualStyleBackColor = true;
            btnGunlukSatis.Click += btnGunlukSatis_Click;

        }


        Label lblToplamCiro = new Label();
        Label lblSatilanUrunAdet = new Label();



        /// <summary>
        /// Tüm zamanalar için yapılmış satışlarla ilgili bilgilendirme yapar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTumZamanlarSatis_Click(object sender, EventArgs e)
        {
            int fiyat = 0;
            int adet = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM GunlukSatisTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                fiyat += Int32.Parse(dr["fiyat"].ToString());
                adet += Int16.Parse(dr["SatisSayisi"].ToString());
            }
            dr.Close();

            lblToplamCiro.Text = fiyat.ToString() + "TL";
            lblSatilanUrunAdet.Text = adet.ToString();
            conn.Close();
        }

        /// <summary>
        /// anlık ayki aylık kazanç için yapılmış satışlarla ilgili bilgilendirme yapar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAylikSatis_Click(object sender, EventArgs e)
        {
            int fiyat = 0;
            int adet = 0;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM GunlukSatisTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["ay"].ToString() == anlikAy.ToString())
                {

                    fiyat += Int16.Parse(dr["fiyat"].ToString());
                    adet += Int16.Parse(dr["SatisSayisi"].ToString());

                }

            }
            lblSatilanUrunAdet.Text = adet.ToString();
            lblToplamCiro.Text = fiyat.ToString() + "TL";
            conn.Close();

        }

        /// <summary>
        /// anlık günün tüm kazanç için yapılmış satışlarla ilgili bilgilendirme yapar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGunlukSatis_Click(object sender, EventArgs e)
        {
            //ay 
            int gun = DateTime.Now.Day;
            int yil = DateTime.Now.Year;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM GunlukSatisTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["yil"].ToString() == yil.ToString() && dr["ay"].ToString() == anlikAy.ToString() && dr["gun"].ToString() == gun.ToString())
                {
                    lblSatilanUrunAdet.Text = dr["SatisSayisi"].ToString();
                    lblToplamCiro.Text = dr["fiyat"].ToString() + "TL";
                    break;
                }
            }
            conn.Close();
        }





        private static int anlikAy;
        Chart chartGunluk = new Chart();
        Chart chartAylik = new Chart();


        /// <summary>
        /// Chart oluşturmak için gerekli değerleri listlerde saklar
        /// </summary>
        private void AylikGrafikOlusturma()
        {
            List<int> listAy = new List<int>();
            List<int> listAylikKazanc = new List<int>();

            conn.Open();

            // tablodaki aylar liste kaydedildi
            SqlCommand cmd = new SqlCommand("SELECT ay FROM GunlukSatisTakip WHERE yil=" + DateTime.Now.Year + " GROUP BY ay HAVING COUNT(*) >= 1", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                listAy.Add(Int16.Parse(dr["ay"].ToString()));
            dr.Close();


            // en yüksek ve en düşük kazanç için aylık satışlar liste kaydedildi
            for (int i = 0; i < listAy.Count; i++)
            {
                cmd = new SqlCommand("SELECT SUM(fiyat) FROM GunlukSatisTakip WHERE yil=" + DateTime.Now.Year + " AND ay=" + listAy[i], conn);
                listAylikKazanc.Add((int)cmd.ExecuteScalar());
            }


            ChartsAylik(listAylikKazanc, listAy);
            conn.Close();
        }

        /// <summary>
        /// Aylik chart oluşturmayı sağlar.
        /// </summary>
        /// <param name="aylikKazanc">ayların aylık kazançlarını saklayan list</param>
        /// <param name="aylar">ayların değerlerini saklayan list</param>
        private void ChartsAylik(List<int> aylikKazanc, List<int> aylar)
        {
            InitializeComponent();

            chartAylik.ChartAreas.Add(new ChartArea());

            Title title = new Title();
            title.Font = new Font("Segoe UI Semibold", 14, FontStyle.Regular);
            title.Text = "Aylık Kazanç Grafiği";
            chartAylik.Titles.Add(title);


            for (int i = 0; i < aylar.Count; i++)
            {
                var series = new Series();
                series.Name = AyStringDondur(aylar[i]);
                series.Points.AddXY(aylar[i], aylikKazanc[i]);
                series.Color = Color.FromArgb(37, 150, 190);
                series.BorderWidth = 1;
                series.BorderDashStyle = ChartDashStyle.Solid;
                series.BorderColor = Color.Black;
                chartAylik.Series.Add(series);
            }

            chartAylik.Location = new System.Drawing.Point(830, 119);
            chartAylik.Size = new System.Drawing.Size(894, 330);
            this.Controls.Add(chartAylik);




            chartAylik.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartAylik.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartAylik.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartAylik.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

        }

        /// <summary>
        /// Chart oluşturmak için gerekli değerleri listlerde saklar
        /// </summary>
        private void GunlukGrafikOlustur()
        {
            List<int> listgunler = new List<int>();
            List<int> listGunlukKazanc = new List<int>();

            conn.Open();

            // tablodaki günleri liste kaydedildi
            SqlCommand cmd = new SqlCommand("SELECT  *FROM GunlukSatisTakip WHERE yil=" + DateTime.Now.Year + " AND ay=" + anlikAy, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                listgunler.Add(Int16.Parse(dr["gun"].ToString()));
            dr.Close();


            // en yüksek ve en düşük kazanç için aylık satışlar liste kaydedildi
            for (int i = 0; i < listgunler.Count; i++)
            {
                cmd = new SqlCommand("SELECT SUM(fiyat) FROM GunlukSatisTakip WHERE yil=" + DateTime.Now.Year + " AND ay=" + anlikAy + " AND gun=" + listgunler[i], conn);
                listGunlukKazanc.Add((int)cmd.ExecuteScalar());
            }


            ChartsGunluk(listGunlukKazanc, listgunler);

            conn.Close();
        }

        /// <summary>
        /// Günlük chart oluşturmayı sağlar.
        /// </summary>
        /// <param name="listgunlukKazanc">günlerin günlük kazançlarını saklayan list</param>
        /// <param name="gunler">günlerin değerlerini saklayan list</param>
        private void ChartsGunluk(List<int> listgunlukKazanc, List<int> gunler)
        {
            InitializeComponent();

            chartGunluk.ChartAreas.Add(new ChartArea());

            Title title = new Title();
            title.Font = new Font("Segoe UI Semibold", 14, FontStyle.Regular);
            title.Text = AyStringDondur(anlikAy) + " Ayı Kazanç Grafiği";
            chartGunluk.Titles.Add(title);


            for (int i = 0; i < gunler.Count; i++)
            {
                var series = new Series();
                series.Points.AddXY(gunler[i], listgunlukKazanc[i]);
                series.Color = Color.FromArgb(37, 150, 190);
                series.BorderWidth = 1;
                series.BorderDashStyle = ChartDashStyle.Solid;
                series.BorderColor = Color.Black;
                chartGunluk.Series.Add(series);
            }

            chartGunluk.Location = new System.Drawing.Point(374, 554);
            chartGunluk.Size = new System.Drawing.Size(1286, 385);
            this.Controls.Add(chartGunluk);




            chartGunluk.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartGunluk.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartGunluk.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartGunluk.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        }



        /// <summary>
        /// girilen değere göre ay adını geriye döndürür.
        /// </summary>
        /// <param name="ay"></param>
        /// <returns></returns>
        private string AyStringDondur(int ay)
        {
            string ayAd = "";
            if (ay == 1)
                ayAd = "Ocak";
            else if (ay == 2)
                ayAd = "Şubat";
            else if (ay == 3)
                ayAd = "Mart";
            else if (ay == 4)
                ayAd = "Nisan";
            else if (ay == 5)
                ayAd = "Mayıs";
            else if (ay == 6)
                ayAd = "Haziran";
            else if (ay == 7)
                ayAd = "Temmuz";
            else if (ay == 8)
                ayAd = "Ağustos";
            else if (ay == 9)
                ayAd = "Eylül";
            else if (ay == 10)
                ayAd = "Ekim";
            else if (ay == 11)
                ayAd = "Kasım";
            else if (ay == 12)
                ayAd = "Mart";

            return ayAd;
        }




        /// <summary>
        /// Chart için yeterli veri olup olmadığını sorgular
        /// </summary>
        /// <param name="tip">tip 1 için aylık tip 2 için günlük chartlarla ilgili sorgulama yapar</param>
        /// <returns></returns>
        private bool ChartSorgulama(int tip)
        {
            // tip 1 ise aylik tablosu için sorgu tip 2 ise günlük tablosu için sorgu
            bool kontrol = false;
            int sayac = 0;
            conn.Open();
            switch(tip)
            {
                case 1:
                    SqlCommand cmd = new SqlCommand("SELECT ay FROM GunlukSatisTakip WHERE yil=" + DateTime.Now.Year + "  GROUP BY ay HAVING COUNT(*) >= 1 ", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        sayac++;
                    }
                    if(sayac != 0)
                        kontrol = true;
                    break;

                case 2:
                    cmd = new SqlCommand("SELECT gun FROM GunlukSatisTakip WHERE yil=" + DateTime.Now.Year + " AND ay="+ DateTime.Now.Month + " GROUP BY gun HAVING COUNT(*) >= 1 ", conn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        sayac++;
                    }
                    if (sayac != 0)
                        kontrol = true;
                    break;
            }
            conn.Close();

            return kontrol;
        }

        /// <summary>
        /// Chart ın oluşamadığı durumda bilgilendirme paneli oluşturur
        /// </summary>
        /// <param name="tip"></param>
        private void BosGrafik(int tip)
        {
            // 1 aylik boş grafik 2 günlük boş grafik
            switch(tip)
            {
                case 1:
                    Panel pnlAy = new Panel();
                    this.Controls.Add(pnlAy);
                    pnlAy.Location = new Point(830, 119);
                    pnlAy.Size = new System.Drawing.Size(894, 330);
                    pnlAy.BackColor = System.Drawing.Color.White;

                    

                    Label lbl1 = new Label();
                    pnlAy.Controls.Add(lbl1);  
                    lbl1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
                    lbl1.Text = "Grafik Oluşturmak için yeterli kayıt bulunamadı";
                    lbl1.Location = new Point(150, 150);
                    lbl1.Size = new System.Drawing.Size(1000, 100);
                    break;

                case 2:
                    Panel pnlGun = new Panel();
                    this.Controls.Add(pnlGun);
                    pnlGun.Location = new Point(374, 554);
                    pnlGun.Size = new System.Drawing.Size(1200, 330);
                    pnlGun.BackColor = System.Drawing.Color.White;



                    Label lbl2 = new Label();
                    pnlGun.Controls.Add(lbl2);
                    lbl2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
                    lbl2.Text = "Grafik Oluşturmak için yeterli kayıt bulunamadı";
                    lbl2.Location = new Point(300, 120);
                    lbl2.Size = new System.Drawing.Size(1000, 200);
                    break;
            }
        }



        /// <summary>
        /// Tüm siparişleri ayrıntılı listeler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAyrintiListe_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.AutoScaleDimensions = new SizeF(7F, 15F);
            form.AutoScaleMode = AutoScaleMode.Font;
            form.ClientSize = new Size(1172, 768);
            form.Text = "Tüm Günlük Satışlar";
            form.StartPosition = FormStartPosition.CenterParent;

            // pnl1
            // 
            Panel pnl1 = new Panel();
            form.Controls.Add(pnl1);
            pnl1.AutoScroll = true;
            pnl1.BackColor = Color.FromArgb(254, 255, 254);
            pnl1.Location = new Point(12, 62);
            pnl1.Size = new Size(1146, 694);
            pnl1.TabIndex = 1;
            // 
            // pnl2
            // 
            Panel pnl2 = new Panel();
            form.Controls.Add(pnl2);
            pnl2.BackColor = Color.FromArgb(249, 245, 244);
            pnl2.Location = new Point(12, 22);
            pnl2.Size = new Size(1146, 40);
            pnl2.TabIndex = 2;
            // 
            // lbl3
            // 
            Label lbl3 = new Label();
            pnl2.Controls.Add(lbl3);
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.ForeColor = Color.FromArgb(123, 133, 147);
            lbl3.Location = new Point(781, 10);
            lbl3.Size = new Size(44, 21);
            lbl3.TabIndex = 5;
            lbl3.Text = "Fiyat";
            // 
            // lbl2
            // 
            Label lbl2 = new Label();
            pnl2.Controls.Add(lbl2);
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.ForeColor = Color.FromArgb(123, 133, 147);
            lbl2.Location = new Point(381, 10);
            lbl2.Size = new Size(95, 21);
            lbl2.TabIndex = 4;
            lbl2.Text = "Adisyon No";
            // 
            // lbl1
            // 
            Label lbl1 = new Label();
            pnl2.Controls.Add(lbl1);
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.ForeColor = Color.FromArgb(123, 133, 147);
            lbl1.Location = new Point(49, 10);
            lbl1.Size = new Size(44, 21);
            lbl1.TabIndex = 3;
            lbl1.Text = "Tarih";

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM AdisyonTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            Color color1 = new Color();
            int sayac = 0;
            while (dr.Read())
            {
                if (sayac % 2 == 0)
                    color1 = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                else
                    color1 = System.Drawing.Color.FromArgb(236, 236, 238);

                Panel pnl = new Panel();
                pnl1.Controls.Add(pnl);
                pnl.BackColor = color1;
                pnl.Location = new Point(0, 60 * sayac);
                pnl.Size = new Size(1146, 60);
                pnl.TabIndex = 1;
                //
                // tarihlerin yazdığı label
                // 
                Label lblTarih = new Label();
                lblTarih.Size = new System.Drawing.Size(200, 20);
                lblTarih.BackColor = System.Drawing.Color.Transparent;
                lblTarih.Text = dr["yil"].ToString() + "-" + dr["ay"].ToString() + "-" + dr["gun"].ToString();
                lblTarih.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                lblTarih.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
                pnl.Controls.Add(lblTarih);
                lblTarih.Location = new System.Drawing.Point(40, 20);
                lblTarih.Visible = true;
                //
                // adisyon noların yazdığı textbox
                //
                Label lblAdisyonNo = new Label();
                lblAdisyonNo.Size = new System.Drawing.Size(80, 20);
                lblAdisyonNo.BackColor = System.Drawing.Color.Transparent;
                lblAdisyonNo.Text = dr["adisyonNo"].ToString();
                lblAdisyonNo.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                lblAdisyonNo.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
                pnl.Controls.Add(lblAdisyonNo);
                lblAdisyonNo.Location = new System.Drawing.Point(400, 20);
                lblAdisyonNo.Visible = true;
                //
                // fiyatların yazdığı textbox
                //
                Label lblFiyat = new Label();
                lblFiyat.Size = new System.Drawing.Size(500, 20);
                lblFiyat.BackColor = System.Drawing.Color.Transparent;
                lblFiyat.Text = dr["fiyat"].ToString();
                lblFiyat.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
                lblFiyat.ForeColor = System.Drawing.Color.FromArgb(118, 128, 143);
                pnl.Controls.Add(lblFiyat);
                lblFiyat.Location = new System.Drawing.Point(785, 20);
                lblFiyat.Visible = true;
                sayac++;
            }
            conn.Close();
            form.ShowDialog();
        }

        /// <summary>
        /// Kayıtlı tüm siparişleri temizler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKayitTemizle_Click(object sender, EventArgs e)
        {
            string message = "Gelir kayıtlarının hepsini silmek istediğinize emin misiniz?";
            string title = "Gelir Kayıtlarını Temizleme";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM GunlukSatisTakip",conn);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("DELETE FROM AdisyonTakip", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        

    }
}
