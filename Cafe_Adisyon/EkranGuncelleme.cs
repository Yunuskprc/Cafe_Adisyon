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

            MessageBox.Show("update " + cmbBxKategori.Text + " set isim='" + isim + "',fiyat=" + Int16.Parse(fiyat) + ",aciklama='" + aciklama + "' where urunId=" + btn.Name);


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
                    MessageBox.Show(txtYeniFiyat.Text);
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

        private void btnMenuEkle_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            panel4.Visible = false;
            panel5.Visible = false;

            Panel pnl = new Panel();
            Controls.Add(pnl);
            pnl.Size = new Size(500, 350);
            pnl.Location = new Point(800, 380);
            pnl.BackColor = Color.Aqua;
        }

        private void btnMenuSil_Click(object sender, EventArgs e)
        {

        }
    }
}
