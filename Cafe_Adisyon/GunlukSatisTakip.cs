﻿using System;
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
        public void TabloDuzenle(int yil, int ay, int gun, int fiyat,int adet)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM GunlukSatisTakip", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            bool kontrol = false;
            int tempFiyat = 0;
            int tempAdet = 0;

            while (dr.Read())
            {
                if (Int16.Parse(dr["yil"].ToString()) == yil  &&  Int16.Parse(dr["ay"].ToString()) == ay  &&  Int16.Parse(dr["gun"].ToString()) == gun)
                {
                    kontrol = true;
                    tempFiyat = Int16.Parse(dr["fiyat"].ToString());
                    tempAdet = Int16.Parse(dr["SatisSayisi"].ToString());
                    break;
                }
            }
            dr.Close();
            fiyat += tempFiyat;
            tempAdet++;

            if(kontrol)
            {
                cmd = new SqlCommand("update GunlukSatisTakip set fiyat=" + fiyat + ", SatisSayisi=" + tempAdet + " WHERE yil=" + yil +" AND ay="+ay + " AND gun="+gun,conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd = new SqlCommand("insert into GunlukSatisTakip (yil,ay,gun,SatisSayisi,fiyat) values ("+yil+"," +ay +"," + gun +"," + adet + "," + fiyat + ")",conn);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

}
