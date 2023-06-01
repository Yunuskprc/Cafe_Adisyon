using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Adisyon_Sistemi
{
    public partial class KayitEkran : Form
    {
        static int cinsiyet, perosnelId = 2;
        public KayitEkran()
        {
            InitializeComponent();
        }

        private void KayitEkran_Load(object sender, EventArgs e)
        {
            ToolTip aciklama1 = new ToolTip();
            aciklama1.SetToolTip(pictureBox4, "En az 8 harfli olmalıdır.");

            ToolTip aciklama2 = new ToolTip();
            aciklama2.SetToolTip(pictureBox12, "En az 8 harfli olmalıdır.");

            ToolTip aciklama3 = new ToolTip();
            aciklama3.SetToolTip(pictureBox16, "XXXX-XX-XX şeklinde olmalıdır.");

            ToolTip aciklama4 = new ToolTip();
            aciklama4.SetToolTip(pictureBox17, "erkek/kadın şeklinde olmalıdır.");

            ToolTip aciklama5 = new ToolTip();
            aciklama5.SetToolTip(pictureBox18, "5XXXXXXXXX şeklinde olmalıdır.");

            ToolTip aciklama6 = new ToolTip();
            aciklama6.SetToolTip(pictureBox20, "en az 5 karakterli olmalı ve gmail/hotmail/outlook uzantısında olmalıdır");
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            GirisEkran nGirisEkran = new GirisEkran();
            nGirisEkran.Show();
            this.Hide();
        }

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            String Kadi = TxtKadi.Text; // yapıldı
            String Sifre = TxtSifre.Text;//yapıldı
            String SifreT = TxtSifreT.Text;
            String ad = TxtAd.Text;
            String soyad = TxtSoyad.Text;
            String DogumTarih = TxtDogumTarihi.Text;//yapıldı
            String Cinsiyet = TxtCinsiyet.Text;//yapıldı
            String TelNo = TxtTelNo.Text;//yapıldı
            String TC = TxtTC.Text;//yapıldı
            String Mail = TxtMail.Text;//yapıldı
            Boolean kontrol;


            if (BilgiKontrol(DogumTarih, DogumTarih.Length, "DogumTarih") && BilgiKontrol(TC, TC.Length, "TC") && BilgiKontrol(TelNo, TelNo.Length, "TelNo") && BilgiKontrol(Cinsiyet, Cinsiyet.Length, "Cinsiyet") && BilgiKontrol(Kadi, Kadi.Length, "Kadi") && BilgiKontrol(Sifre, Sifre.Length, "Sifre"))
            {
                String Sorgu = "SELECT *FROM Personel ";
                SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Restaurant_Otomasyon;Trusted_Connection=True;");
                SqlCommand comm = new SqlCommand(Sorgu, conn);

                if (Sifre == SifreT)
                {
                    kontrol = true;
                }
                else
                {
                    kontrol = false;
                }

                conn.Open();
                comm.ExecuteNonQuery();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    perosnelId = Int16.Parse(dr["PersonelId"].ToString());

                    if (dr["KullaniciAdi"].Equals(Kadi))
                    {
                        kontrol = false;
                        break;
                    }
                    else
                    {
                        if (dr["telNo"].Equals(TelNo))
                        {
                            kontrol = false;
                            break;
                        }
                        else
                        {
                            if (TC.Equals(dr["TC"]))
                            {
                                kontrol = false;
                                break;
                            }
                            else
                            {
                                if (Mail.Equals(dr["mail"]))
                                {
                                    kontrol = false;
                                    break;
                                }
                                else
                                {
                                    kontrol = true;
                                }
                            }
                        }
                    }
                }
                if (kontrol)
                {
                    MessageBox.Show("Kayıt Başarılı ");
                    KayitEkle(Kadi, Sifre, SifreT, ad, soyad, DogumTarih, Cinsiyet, TelNo, TC, Mail);
                }
                else
                {
                    MessageBox.Show("Hatalı veri girişi tekrar deneyin");
                }
                conn.Close();
            }
            else
                MessageBox.Show("Hatalı veri girişi tekrar deneyin");
        }

        private void KayitEkle(String Kadi, String Sifre, String SifreT, String ad, String soyad, String DogumTarih, String Cinsiyet, String TelNo, String TC, String Mail)
        {

            SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Restaurant_Otomasyon;Trusted_Connection=True;");
            conn.Open();
            SqlCommand comm = new SqlCommand("insert into Personel (PersonelId,KullaniciAdi,Sifre,Ad,Soyad,telNo,TC,mail,cinsiyet,dogumTarih) values ('" + (perosnelId + 1) + "','" + Kadi + "','" + ComputeSha256Hash(Sifre) + "','" + ad + "','" + soyad + "','" + TelNo + "','" + TC + "','" + Mail + "','" + cinsiyet + "','" + DogumTarih + "')", conn); // eksik
            comm.ExecuteNonQuery();
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

        static bool BilgiKontrol(string str, int lenght, string tur)
        {
            bool kontrol = false;
            switch (tur)
            {
                case "DogumTarih":

                    for (int i = 0; i < lenght; i++)
                    {
                        if (str[i] == '0' || str[i] == '1' || str[i] == '2' || str[i] == '3' || str[i] == '4' || str[i] == '5' || str[i] == '6' || str[i] == '7' || str[i] == '8' || str[i] == '9' || str[i] == '-')
                        {
                            kontrol = true;
                        }
                        else
                        {
                            kontrol = false;
                            break;
                        }
                    }
                    break;

                case "TC":

                    for (int i = 0; i < lenght; i++)
                    {
                        if (str[i] == '0' || str[i] == '1' || str[i] == '2' || str[i] == '3' || str[i] == '4' || str[i] == '5' || str[i] == '6' || str[i] == '7' || str[i] == '8' || str[i] == '9')
                        {
                            kontrol = true;
                        }
                        else
                        {
                            kontrol = false;
                            break;
                        }
                    }

                    if (str[0].ToString() == "0" || lenght != 11)
                        kontrol = false;
                    break;

                case "TelNo":

                    for (int i = 0; i < lenght; i++)
                    {
                        if (str[i] == '0' || str[i] == '1' || str[i] == '2' || str[i] == '3' || str[i] == '4' || str[i] == '5' || str[i] == '6' || str[i] == '7' || str[i] == '8' || str[i] == '9')
                        {
                            kontrol = true;
                        }
                        else
                        {
                            kontrol = false;
                            break;
                        }
                    }

                    if (str[0].ToString() != "5" || lenght != 10)
                        kontrol = false;
                    break;

                case "Cinsiyet":
                    if (str.Equals("erkek") || str.Equals("ERKEK") || str.Equals("Erkek"))
                    {
                        cinsiyet = 1;
                        kontrol = true;
                    }
                    else if (str.Equals("kadın") || str.Equals("KADIN") || str.Equals("Kadın") || str.Equals("kadin"))
                    {
                        cinsiyet = 0;
                        kontrol = false;
                    }
                    break;

                case "Kadi":
                    if (lenght >= 8)
                        kontrol = true;
                    else
                        kontrol = false;

                    break;

                case "Sifre":
                    if (lenght >= 8)
                        kontrol = true;
                    else
                        kontrol = false;
                    break;
            }

            return kontrol;
        }
    }
}
