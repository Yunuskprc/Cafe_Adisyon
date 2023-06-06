using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Adisyon
{
    internal class GunlukSatisTakip
    {
        SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Cafe_Adisyon;Trusted_Connection=True;");

        /// <summary>
        /// Bu metot veritabanında Adisyon Tablosundaki 1 günlük satışların toplamını tek bir sütünda kaydetmek için GünlükSatış tablosuna kayıt/düzenleme işlemi yapar.
        /// </summary>
        /// <param name="tarih">Anlık Tarih bilgisi</param>
        /// <param name="fiyat">İşlem yapılacak siparişin fiyat bilgisi</param>
        public void TabloDuzenle(string tarih, int fiyat)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM GunlukSatisTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool kontrol = false;
            int temp = 0;

            while (dr.Read())
            {
                if (dr["tarih"].ToString() == tarih)
                {
                    kontrol = true;
                    temp = Int16.Parse(dr["fiyat"].ToString());
                    break;
                }
            }
            dr.Close();
            fiyat += temp;

            if(kontrol)
            {
                cmd = new SqlCommand("update GunlukSatisTakip set fiyat=" + fiyat + " WHERE tarih='" + tarih + "'",conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd = new SqlCommand("insert into GunlukSatisTakip (tarih,fiyat) values ('" +  tarih + "'," + fiyat + ")",conn);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

}
