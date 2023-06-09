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

        // btnAylikSatis_Click metodunda ay ı deneme yaptığımız için böyle yaptık normalde datetime.now.month olmalı
        // ve substringlerin parametreleri değişebilir.

        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=deneme;Trusted_Connection=True;");

        private void EkranUrunTakip_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Visible = true;
            btnTumZamanlarSatis_Click(sender, e);
            AylikGrafikOlusturma();
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

            lblToplamCiro.Text = fiyat.ToString();
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
            int ay = 2;
            int yil = DateTime.Now.Year;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM GunlukSatisTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["yil"].ToString() == yil.ToString() && dr["ay"].ToString() == ay.ToString() && dr["gun"].ToString() == gun.ToString())
                {
                    lblSatilanUrunAdet.Text = dr["SatisSayisi"].ToString();
                    lblToplamCiro.Text = dr["fiyat"].ToString();
                    break;
                }
            }
            conn.Close();
        }




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
            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            Title title = new Title();
            title.Font = new Font("Segoe UI Semibold", 14, FontStyle.Regular);
            title.Text = "Aylık Kazanç Grafiği";
            chart.Titles.Add(title);


            for (int i = 0; i < aylar.Count; i++)
            {
                var series = new Series();
                series.Name = AyStringDondur(aylar[i]);
                series.Points.AddXY(aylar[i], aylikKazanc[i]);
                series.Color = Color.FromArgb(37, 150, 190);
                series.BorderWidth = 1;
                series.BorderDashStyle = ChartDashStyle.Solid;
                series.BorderColor = Color.Black;
                chart.Series.Add(series);
            }

            chart.Location = new System.Drawing.Point(830, 119);
            chart.Size = new System.Drawing.Size(894, 330);
            this.Controls.Add(chart);




            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

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
