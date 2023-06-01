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
        // siparis ekleme menüsünde fiyat label ına değer atayamıyoruz.


        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Cafe_Adisyon;Trusted_Connection=True;");
        DateTime dt;

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
        ComboBox cmbBxSiparisKategori = new ComboBox();
        ComboBox cmbBxSiparisUrun = new ComboBox();
        Label lblSiparisFiyat = new Label();


        private void buttonCode(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Panel pnlSiparis = new Panel();
            pnlMain.Controls.Add(pnlSiparis);

            pnlSiparis.Size = new Size(600, 400);
            pnlSiparis.Location = new Point(300, 275);
            pnlSiparis.BackColor = System.Drawing.Color.FromArgb(226, 226, 226);
            //
            //
            Label lblMasaAd = new Label();
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
            pnlSiparis.Controls.Add(cmbBxSiparisUrun);
            cmbBxSiparisUrun.FormattingEnabled = true;
            cmbBxSiparisUrun.Location = new Point(178, 128);
            cmbBxSiparisUrun.Size = new Size(124, 23);
            cmbBxSiparisUrun.TabIndex = 3;
            cmbBxSiparisUrun.SelectedIndexChanged += cmbBxSiparisUrun_SelectedIndexChanged;
            //
            //
            ComboBox cmbBxSiparisCarpan = new ComboBox();
            pnlSiparis.Controls.Add(cmbBxSiparisCarpan);
            cmbBxSiparisCarpan.FormattingEnabled = true;
            cmbBxSiparisCarpan.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbBxSiparisCarpan.Location = new Point(178, 164);
            cmbBxSiparisCarpan.Size = new Size(124, 23);
            cmbBxSiparisCarpan.TabIndex = 8;
            //
            //
            pnlSiparis.Controls.Add(lblSiparisFiyat);
            lblSiparisFiyat.AutoSize = true;
            lblSiparisFiyat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblSiparisFiyat.Location = new Point(178, 202);
            lblSiparisFiyat.Size = new Size(0, 25);
            lblSiparisFiyat.TabIndex = 12;
        }

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

        private void cmbBxSiparisUrun_SelectedIndexChanged(object sender,EventArgs e)
        {
            ComboBox cmbBx = sender as ComboBox;
            SqlCommand cmd  = new SqlCommand("SELECT *FROM " + cmbBxSiparisKategori.Text + " WHERE isim='" + cmbBxSiparisUrun.Text+"'",conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblSiparisFiyat.Text = dr["fiyat"].ToString();
            }
            conn.Close();
        }
    }
}
