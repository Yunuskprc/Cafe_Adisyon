using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void EkranUrunTakip_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Visible = true;
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
    }
}
