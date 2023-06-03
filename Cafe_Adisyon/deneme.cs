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
    public partial class deneme : Form
    {
        public deneme()
        {
            InitializeComponent();
        }

        Panel pnlFis = new Panel();
        private void deneme_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            Controls.Add(pnlFis);
            pnlFis.BringToFront();
            pnlFis.BackColor = Color.FromArgb(232, 234, 234);
            pnlFis.BorderStyle = BorderStyle.FixedSingle;
            pnlFis.Location = new Point(404, 219);
            pnlFis.Size = new Size(357, 555);
            pnlFis.TabIndex = 176;
            pnlFis.Visible = true;

            PictureBox pctBxLogo = new PictureBox();
            pnlFis.Controls.Add(pctBxLogo);
            pctBxLogo.Image = Properties.Resources.YEDLogo;
            pctBxLogo.Location = new Point(126, 10);
            pctBxLogo.Size = new Size(100, 100);
            pctBxLogo.TabIndex = 0;
            pctBxLogo.TabStop = false;

            Panel pnlDateMasaAd = new Panel();
            pnlFis.Controls.Add(pnlDateMasaAd);
            pnlDateMasaAd.BorderStyle = BorderStyle.FixedSingle;
            pnlDateMasaAd.Location = new Point(20, 137);
            pnlDateMasaAd.Size = new Size(313, 29);
            pnlDateMasaAd.TabIndex = 1;

            Label lblFisDate = new Label();
            pnlDateMasaAd.Controls.Add(lblFisDate);
            lblFisDate.AutoSize = true;
            lblFisDate.Location = new Point(5, 7);
            lblFisDate.Size = new Size(61, 15);
            lblFisDate.TabIndex = 0;
            lblFisDate.Text = DateTime.Now.ToString();

            Label lbl1 = new Label();
            pnlDateMasaAd.Controls.Add(lblFisDate);
            lbl1.AutoSize = true;
            lbl1.Location = new Point(191, 7);
            lbl1.Size = new Size(59, 15);
            lbl1.TabIndex = 3;
            lbl1.Text = "Masa Adı:";

            Label lblFisMasaAd = new Label();
            pnlDateMasaAd.Controls.Add(lblFisMasaAd);
            lblFisMasaAd.AutoSize = true;
            lblFisMasaAd.Location = new Point(250, 7);
            lblFisMasaAd.Size = new Size(47, 15);
            lblFisMasaAd.TabIndex = 4;
            lblFisMasaAd.Text = "Masa1";

            Label lbl2 = new Label();
            pnlFis.Controls.Add(lbl2);
            lbl2.AutoSize = true;
            lbl2.Location = new Point(26, 186);
            lbl2.Size = new Size(46, 15);
            lbl2.TabIndex = 2;
            lbl2.Text = "Ürünler";

            Label lbl3 = new Label();
            pnlFis.Controls.Add(lbl3);
            lbl3.AutoSize = true;
            lbl3.Location = new Point(212, 186);
            lbl3.Size = new Size(32, 15);
            lbl3.TabIndex = 3;
            lbl3.Text = "Adet";

            Label lbl4 = new Label();
            pnlFis.Controls.Add(lbl4);
            lbl4.AutoSize = true;
            lbl4.Location = new Point(15, 201);
            lbl4.Size = new Size(312, 15);
            lbl4.TabIndex = 6;
            lbl4.Text = "-------------------------------------------------------------";

            Label lbl5 = new Label();
            pnlFis.Controls.Add(lbl5);
            lbl5.AutoSize = true;
            lbl5.Location = new Point(15, 396);
            lbl5.Size = new Size(312, 15);
            lbl5.TabIndex = 39;
            lbl5.Text = "-------------------------------------------------------------";

            Panel pnlFisUrunler = new Panel();
            pnlFis.Controls.Add(pnlFisUrunler);
            pnlFisUrunler.Location = new Point(24, 221);
            pnlFisUrunler.Size = new Size(295, 175);
            pnlFisUrunler.BackColor = Color.Khaki;
        }
    }
}
