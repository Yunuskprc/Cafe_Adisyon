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
            SqlCommand cmd = new SqlCommand("SELECT *FROM MENULER",conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Panel pnl = new Panel();
                panel4.Controls.Add(pnl);
                pnl.Location = new Point(0, 60*(sayac));
                pnl.Size = new System.Drawing.Size(1750, 60);

                // sıralı panelleri birbirinden ayırmak için yapılan renk değiştirme kontrolü
                if (sayac % 2 == 0)
                    pnl.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                else
                    pnl.BackColor = System.Drawing.Color.FromArgb(236, 236, 238);

                //
                // Menü Adının Yazdığı Textbox
                //
                TextBox txtYemekAd = new TextBox();
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

                sayac++;
            }

            conn.Close();
        }
    }
}
