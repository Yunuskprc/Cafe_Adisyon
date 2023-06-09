using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cafe_Adisyon
{
    public partial class deneme : Form
    {
        public deneme()
        {
            InitializeComponent();
        }

        private void deneme_Load(object sender, EventArgs e)
        {
            Charts();

        }

        private void denes(object sender, PaintEventArgs e)
        {

        }

        private void deneme_Paint(object sender, PaintEventArgs e)
        {
            Graphics gra = this.CreateGraphics();
            Pen blackPen = new Pen(Color.Red, 1);

            PointF pnt1 = new PointF(100, 100);
            PointF pnt2 = new PointF(500, 40);

            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        public void Charts()
        {
            InitializeComponent();

            var chart = new Chart();

            chart.ChartAreas.Add(new ChartArea());

            var series = new Series();
            series.Name = "deneme";
            series.Points.AddXY(1,42.0);
            series.Points.AddXY(2, 47.0);
            series.Points.AddXY(3,53.0);
            chart.Series.Add(series);

            var series2 = new Series();
            series2.Name = "tt";
            series2.Points.AddXY(1,50.0);
            series2.Points.AddXY(2,50.0);
            series2.Points.AddXY(3,50.0);
            series2.BorderColor = Color.Black;
            series2.BorderWidth = 5;
            series2.BorderDashStyle = ChartDashStyle.Solid;
            series2.Color = Color.Red;
            chart.Series.Add(series2);


            chart.Location = new System.Drawing.Point(10, 10);
            chart.Size = new System.Drawing.Size(400,300);

            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;


            this.Controls.Add(chart);

        }
    }
}
