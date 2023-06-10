using Cafe_Adisyon.Properties;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace Cafe_Adisyon
{
    public partial class EkranSatisTakip : Form
    {
        public EkranSatisTakip()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=deneme;Trusted_Connection=True;");
        private void EkranUrunTakip_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Visible = true;
            //DateTime.Now.Month
            DynamicObjet();
            anlikAy = 3;
            btnTumZamanlarSatis_Click(sender, e);
            AylikGrafikOlusturma();
            GunlukGrafikOlustur();
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

        private void btnAylikSatis_Click(object sender, EventArgs e)
        {
            // ay değişkeninde DATETIME.NOW.MOUNTH olacak.
            int ay = 2;
            int fiyat = 0;
            int adet = 0;

            //MessageBox.Show(dr["tarih"].ToString().Substring(5, 1) + "  " + dr["tarih"].ToString().Substring(6, 1));
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM GunlukSatisTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["ay"].ToString() == ay.ToString())
                {

                    fiyat += Int16.Parse(dr["fiyat"].ToString());
                    adet += Int16.Parse(dr["SatisSayisi"].ToString());

                }

            }
            lblSatilanUrunAdet.Text = adet.ToString();
            lblToplamCiro.Text = fiyat.ToString() + "TL";
            conn.Close();

        }

        private void btnGunlukSatis_Click(object sender, EventArgs e)
        {
            //ay 
            int gun = DateTime.Now.Day;
            int ay = 3;
            int yil = DateTime.Now.Year;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM GunlukSatisTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["yil"].ToString() == yil.ToString() && dr["ay"].ToString() == ay.ToString() && dr["gun"].ToString() == gun.ToString())
                {
                    lblSatilanUrunAdet.Text = dr["SatisSayisi"].ToString();
                    lblToplamCiro.Text = dr["fiyat"].ToString() + "TL";
                    break;
                }
            }
            conn.Close();
        }






        Chart chartAylik = new Chart();
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




        private static int anlikAy;
        Chart chartGunluk = new Chart();


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





    }
}
