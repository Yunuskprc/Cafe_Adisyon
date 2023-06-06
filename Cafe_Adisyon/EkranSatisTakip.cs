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
                fiyat += Int16.Parse(dr["fiyat"].ToString());
                adet += Int16.Parse(dr["SatisSayisi"].ToString());
            }
            dr.Close();

            lblToplamCiro.Text = fiyat.ToString();
            lblSatilanUrunAdet.Text = adet.ToString();
            conn.Close();
        }

        private void btnAylikSatis_Click(object sender, EventArgs e)
        {
            int ay = 3;
            int fiyat = 0;
            int adet = 0;

            //MessageBox.Show(dr["tarih"].ToString().Substring(5, 1) + "  " + dr["tarih"].ToString().Substring(6, 1));
            MessageBox.Show(ay.ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM GunlukSatisTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["tarih"].ToString().Substring(5, 1) == "0")
                {
                    if (dr["tarih"].ToString().Substring(6, 1) == ay.ToString())
                    {
                        fiyat += Int16.Parse(dr["fiyat"].ToString());
                        adet += Int16.Parse(dr["SatisSayisi"].ToString());
                    }
                }
                else
                {
                    if (dr["tarih"].ToString().Substring(5, 1) == ay.ToString())
                    {
                        fiyat += Int16.Parse(dr["fiyat"].ToString());
                        adet += Int16.Parse(dr["SatisSayisi"].ToString());
                    }
                }
            }
            lblSatilanUrunAdet.Text = adet.ToString();
            lblToplamCiro.Text = fiyat.ToString();
            conn.Close();

        }

        private void btnGunlukSatis_Click(object sender, EventArgs e)
        {
            string str = "2023-01-7";
            MessageBox.Show(str.Substring(5, 1));

        }
    }
}
