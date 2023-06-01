using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Cafe_Adisyon;

namespace Adisyon_Sistemi
{
    public partial class GirisEkran : Form
    {
        public GirisEkran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String kadi = textBox1.Text;
            String sifre = ComputeSha256Hash(textBox2.Text);


            String Sorgu = "SELECT *FROM Personel where KullaniciAdi='" + kadi + "' AND Sifre='" + sifre + "'";

            SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Restaurant_Otomasyon;Trusted_Connection=True;");
            SqlCommand comm = new SqlCommand(Sorgu, conn);

            conn.Open();
            SqlDataReader rd = comm.ExecuteReader();
            if (rd.Read())
            {
                MessageBox.Show("Giriþ Baþarýlý..");
                EkranMasa nEkranMasa = new EkranMasa();
                nEkranMasa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalý Bilgiler Tekrar Deneyin");
            }
            conn.Close();
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitEkran nKayýtEkran = new KayitEkran();
            nKayýtEkran.Show();
            this.Hide();
        }
    }
}