using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Yönetici Metotları

        public Yonetici YoneticiGiris(string mail, string sifre)
        {


            cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID, YT.Isim, Y.Isim, Y.Soyisim, Y.Mail, Y.Sifre, Y.KullaniciAdi FROM Yonetici AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID WHERE Y.Mail = @mail AND Y.Sifre = @sifre";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Yonetici y = null;
            while (reader.Read())
            {
                y = new Yonetici();
                y.ID = reader.GetInt32(0);
                y.YoneticiTur_ID = reader.GetInt32(1);
                y.YoneticiTur = reader.GetString(2);
                y.Isim = reader.GetString(3);
                y.Soyisim = reader.GetString(4);
                y.Mail = reader.GetString(5);
                y.Sifre = reader.GetString(6);
                y.KullaniciAdi = reader.GetString(7);
            }
            con.Close();
            return y;

        }

        public bool UyeEkle(Yonetici yon)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yonetici(Isim, Soyisim, Mail, KullaniciAdi, Sifre, YoneticiTur) VALUES(@isim, @soyisim, @mail, @kullaniciAdi, @sifre, @yoneticiTur)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", yon.Isim);
                cmd.Parameters.AddWithValue("@soyisim", yon.Soyisim);
                cmd.Parameters.AddWithValue("@mail", yon.Mail);
                cmd.Parameters.AddWithValue("@kullaniciAdi", yon.KullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", yon.Sifre);
                cmd.Parameters.AddWithValue("@yoneticiTur", yon.YoneticiTur);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }


        #endregion

        #region Ürün Metotları

        public bool UrunEkle(Urunler ur)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Urunler(Isim, Satici, UreticiUlke, Fiyat, Stok, Satistami) VALUES(@isim, @satici, @ureticiUlke, @fiyat, @stok, @satistami)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", ur.Isim);
                cmd.Parameters.AddWithValue("@satici", ur.Satici);
                cmd.Parameters.AddWithValue("@ureticiUlke", ur.UreticiUlke);
                cmd.Parameters.AddWithValue("@fiyat", ur.Fiyat);
                cmd.Parameters.AddWithValue("@stok", ur.Stok);
                cmd.Parameters.AddWithValue("@satistami", ur.Satistami);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Urunler> UrunleriGetir()
        {
            List<Urunler> urunler = new List<Urunler>();
            try
            {
                cmd.CommandText = "SELECT Satistami, ID, Isim, Satici, UreticiUlke, Fiyat, Stok FROM Urunler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Urunler ur;
                while (okuyucu.Read())
                {
                    ur = new Urunler();
                    ur.Satistami = okuyucu.GetBoolean(0);
                    ur.SatistamiStr = okuyucu.GetBoolean(0) ? "Evet" : "Hayır";
                    ur.ID = okuyucu.GetInt32(1);
                    ur.Isim = okuyucu.GetString(2);
                    ur.Satici = okuyucu.GetString(3);
                    ur.UreticiUlke = okuyucu.GetString(4);
                    ur.Fiyat = okuyucu.GetDecimal(5);
                    ur.Stok = okuyucu.GetInt32(6);
                    urunler.Add(ur);
                }
                return urunler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void UrunDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Satistami FROM Urunler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Urunler SET Satistami = @d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void UrunSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Urunler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Urunler UrunGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Satici, UreticiUlke, Fiyat, Stok, Satistami FROM Urunler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Urunler u = new Urunler();
                while (okuyucu.Read())
                {
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Satici = okuyucu.GetString(2);
                    u.UreticiUlke = okuyucu.GetString(3);
                    u.Fiyat = okuyucu.GetDecimal(4);
                    u.Stok = okuyucu.GetInt32(5);
                    u.Satistami = okuyucu.GetBoolean(6);

                }
                return u;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UrunGuncelle(Urunler un)
        {
            try
            {
                cmd.CommandText = "UPDATE Urunler SET Isim=@isim, Satistami=@satistami WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", un.ID);
                cmd.Parameters.AddWithValue("@isim", un.Isim);
                cmd.Parameters.AddWithValue("@durum", un.Satistami);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }


        #endregion

        #region AlıcıMetotları

        public List<Alicilar> AlicilariGetir()
        {

            List<Alicilar> alicilar = new List<Alicilar>();
            try
            {
                cmd.CommandText = "SELECT AktifMi, ID, Isim, GorusulenKisi, Telefon, Sehir, Adres FROM Alicilar";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Alicilar al;
                while (okuyucu.Read())
                {
                    al = new Alicilar();
                    al.AktifMi = okuyucu.GetBoolean(0);
                    al.AktifMiStr = okuyucu.GetBoolean(0) ? "Aktif" : "Pasif";
                    al.ID = okuyucu.GetInt32(1);
                    al.Isim = okuyucu.GetString(2);
                    al.GorusulenKisi = okuyucu.GetString(3);
                    al.Telefon = okuyucu.GetInt32(4);
                    al.Sehir = okuyucu.GetString(5);
                    al.Adres = okuyucu.GetString(6);

                    alicilar.Add(al);
                }
                return alicilar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AliciEkle(Alicilar al)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Urunler(Isim, GorusulenKisi, Telefon, Sehir, Adres, AktifMi) VALUES(@isim, @gorusulenKisi, @telefon, @sehir, @adres, @aktifMi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", al.Isim);
                cmd.Parameters.AddWithValue("@gorusulenKisi", al.GorusulenKisi);
                cmd.Parameters.AddWithValue("@telefon", al.Telefon);
                cmd.Parameters.AddWithValue("@sehir", al.Sehir);
                cmd.Parameters.AddWithValue("@adres", al.Adres);
                cmd.Parameters.AddWithValue("@aktifMi", al.AktifMi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AliciGuncelle(Alicilar al)
        {
            try
            {
                cmd.CommandText = "UPDATE Alicilar SET Isim=@isim, AktifMi=@aktifmi WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", al.ID);
                cmd.Parameters.AddWithValue("@isim", al.Isim);
                cmd.Parameters.AddWithValue("@durum", al.AktifMi);
                cmd.Parameters.AddWithValue("@gorusulenKisi", al.GorusulenKisi);
                cmd.Parameters.AddWithValue("@telefon", al.Telefon);
                cmd.Parameters.AddWithValue("@durum", al.AktifMi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Üye Metotları

        //public bool SiparisOlustur()
        //{
        //    //Database güncellemesi gerekli gibi
        //    try
        //    {
        //        //cmd.CommandText = "INSERT INTO Siparisler(Isim, Satici, UreticiUlke, Fiyat, Stok, Satistami) VALUES(@isim, @satici, @ureticiUlke, @fiyat, @stok, @satistami)";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@isim", ur.Isim);
        //        cmd.Parameters.AddWithValue("@satici", ur.Satici);
        //        cmd.Parameters.AddWithValue("@ureticiUlke", ur.UreticiUlke);
        //        cmd.Parameters.AddWithValue("@fiyat", ur.Fiyat);
        //        cmd.Parameters.AddWithValue("@stok", ur.Stok);
        //        cmd.Parameters.AddWithValue("@satistami", ur.Satistami);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //}

        #endregion
    }
}
