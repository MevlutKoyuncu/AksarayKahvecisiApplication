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

        public bool UyeEkle(Alicilar al)
        {
            try
            {
                //cmd.CommandText = "INSERT INTO Yonetici(Isim, Soyisim, Mail, KullaniciAdi, Sifre, YoneticiTur) VALUES(@isim, @soyisim, @mail, @kullaniciAdi, @sifre, @yoneticiTur)";
                //cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@isim", yon.Isim);
                //cmd.Parameters.AddWithValue("@soyisim", yon.Soyisim);
                //cmd.Parameters.AddWithValue("@mail", yon.Mail);
                //cmd.Parameters.AddWithValue("@kullaniciAdi", yon.KullaniciAdi);
                //cmd.Parameters.AddWithValue("@sifre", yon.Sifre);
                //cmd.Parameters.AddWithValue("@yoneticiTur", yon.YoneticiTur);
                //con.Open();
                //cmd.ExecuteNonQuery();
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

        public List<News> DuyurulariGetir()
        {

            List<News> news = new List<News>();
            try
            {
                cmd.CommandText = "SELECT ID, Baslik, Icerik, Tarih FROM Duyurular";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                News n;
                while (okuyucu.Read())
                {
                    n = new News();
                    n.ID = okuyucu.GetInt32(0);
                    n.Baslik = okuyucu.GetString(1);
                    n.Icerik = okuyucu.GetString(2);
                    n.Tarih = okuyucu.GetDateTime(3);

                    news.Add(n);
                }
                return news;
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

        public List<News> DuyurulariGetir(bool d)
        {

            List<News> news = new List<News>();
            try
            {
                cmd.CommandText = "SELECT TOP(5) * FROM Duyurular ORDER BY ID DESC";
                //cmd.CommandText = "SELECT ID, Baslik, Icerik, Tarih FROM Duyurular";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                News n;
                while (okuyucu.Read())
                {
                    n = new News();
                    n.ID = okuyucu.GetInt32(0);
                    n.Baslik = okuyucu.GetString(1);
                    n.Icerik = okuyucu.GetString(2);
                    n.Tarih = okuyucu.GetDateTime(3);

                    news.Add(n);
                }
                return news;
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

        public bool DuyuruEkle(News n)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Duyurular(Baslik, Icerik, Tarih) VALUES(@baslik, @icerik, @tarih)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@baslik", n.Baslik);
                cmd.Parameters.AddWithValue("@icerik", n.Icerik);
                cmd.Parameters.AddWithValue("@tarih", n.Tarih);
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

        public void DuyuruSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Duyurular WHERE ID = @id";
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
            List<Urunler> urun = new List<Urunler>();
            try
            {
                cmd.CommandText = "SELECT P.Satistami, P.ID, P.Isim, P.Satici, P.Fiyat, P.Stok, UU.ID, UU.Isim FROM Urunler AS P JOIN UreticiUlkeler AS UU ON P.UreticiUlke = UU.ID";
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
                    ur.UreticiUlkeID = okuyucu.GetInt32(6);
                    ur.UreticiUlke = okuyucu.GetString(7);
                    ur.Fiyat = okuyucu.GetDecimal(4);
                    ur.Stok = okuyucu.GetInt32(5);
                    urun.Add(ur);
                }
                return urun;
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

        public List<Urunler> UrunleriGetir(bool durum)
        {
            string d = durum ? "1" : "0";
            List<Urunler> urun = new List<Urunler>();
            try
            {
                cmd.CommandText = "SELECT P.Satistami, P.ID, P.Isim, P.Satici, P.Fiyat, P.Stok, UU.ID, UU.Isim FROM Urunler AS P JOIN UreticiUlkeler AS UU ON P.UreticiUlke = UU.ID";
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
                    ur.UreticiUlkeID = okuyucu.GetInt32(6);
                    ur.UreticiUlke = okuyucu.GetString(7);
                    ur.Fiyat = okuyucu.GetDecimal(4);
                    ur.Stok = okuyucu.GetInt32(5);
                    urun.Add(ur);
                }
                return urun;
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

        public List<UreticiUlkeler> UreticiUlkeleriGetir()
        {

            try
            {
                List<UreticiUlkeler> uret = new List<UreticiUlkeler>();
                cmd.CommandText = "SELECT ID, Isim FROM UreticiUlkeler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                UreticiUlkeler uu;
                while (okuyucu.Read())
                {
                    uu = new UreticiUlkeler();
                    uu.ID = okuyucu.GetInt32(0);
                    uu.Isim = okuyucu.GetString(1);
                    uret.Add(uu);
                }
                return uret;
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

        public List<UreticiUlkeler> UreticiUlkeleriGetir(bool durum)
        {

            try
            {
                List<UreticiUlkeler> uret = new List<UreticiUlkeler>();
                cmd.CommandText = "SELECT ID, Isim FROM UreticiUlkeler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                UreticiUlkeler uu;
                while (okuyucu.Read())
                {
                    uu = new UreticiUlkeler();
                    uu.ID = okuyucu.GetInt32(0);
                    uu.Isim = okuyucu.GetString(1);

                }
                return uret;
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


        public List<Urunler> AzalanUrunleriGetir()
        {
            List<Urunler> urun = new List<Urunler>();
            try
            {
                cmd.CommandText = "SELECT Satistami, ID, Isim, Satici, UreticiUlke, Fiyat, Stok FROM Urunler WHERE Stok <= 10 AND Satistami = 1";
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
                    urun.Add(ur);
                }
                return urun;
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
                bool satistami = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Urunler SET Satistami = @d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !satistami);
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
                cmd.CommandText = "UPDATE Urunler SET Isim=@isim, Satici=@satici, UreticiUlke=@ureticiUlke, Fiyat=@fiyat, Stok=@stok, Satistami=@satistami WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", un.ID);
                cmd.Parameters.AddWithValue("@isim", un.Isim);
                cmd.Parameters.AddWithValue("@satici", un.Satici);
                cmd.Parameters.AddWithValue("@ureticiUlke", un.UreticiUlke);
                cmd.Parameters.AddWithValue("@fiyat", un.Fiyat);
                cmd.Parameters.AddWithValue("@stok", un.Stok);
                cmd.Parameters.AddWithValue("@satistami", un.Satistami);
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
                    al.Telefon = okuyucu.GetString(4);
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

        public Alicilar UyeGiris(string isim, string sifre)
        {
            cmd.CommandText = "SELECT U.ID, U.UyelikTur_ID, UT.Isim, U.Isim, U.GorusulenKisi, U.Telefon, U.Sehir, U.Adres, U.AktifMi, U.Mail, U.Sifre FROM Alicilar AS U JOIN UyelikTurleri AS UT ON U.UyelikTur_ID = UT.ID WHERE U.Isim = @isim AND U.Sifre = @sifre";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@isim", isim);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Alicilar u = null;
            while (reader.Read())
            {
                u = new Alicilar();
                u.ID = reader.GetInt32(0);
                u.UyelikTur_ID = reader.GetInt32(1);
                u.UyelikTur = reader.GetString(2);
                u.Isim = reader.GetString(3);
                u.GorusulenKisi = reader.GetString(4);
                u.Telefon = reader.GetString(5);
                u.Sehir = reader.GetString(6);
                u.Adres = reader.GetString(7);
            }
            con.Close();
            return u;
        }

        public bool SiparisOlustur(Siparisler s)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Satislar(UrunID, TurID, AliciID, Miktar, Durum, Tarih) VALUES(@urunID, @turID, @aliciID, @miktar, @durum, @tarih)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@urunID", s.UrunID);
                cmd.Parameters.AddWithValue("@TurID", s.TurID);
                cmd.Parameters.AddWithValue("@aliciID", s.AliciID);
                cmd.Parameters.AddWithValue("@miktar", s.Miktar);
                cmd.Parameters.AddWithValue("@durum", s.DurumID);
                cmd.Parameters.AddWithValue("@tarih", s.Tarih);
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

        public List<Siparisler> SiparisleriGetir(int id)
        {
            List<Siparisler> siparislers = new List<Siparisler>();
            try
            {

                cmd.CommandText = "SELECT S.ID, U.Isim, UU.Isim, SD.Isim, S.AliciID, S.Miktar, S.Tarih, U.Fiyat FROM Satislar AS S JOIN Urunler AS U ON S.UrunID=U.ID JOIN UreticiUlkeler AS UU ON S.TurID=UU.ID JOIN SiparisDurumlari AS SD ON SD.ID=S.Durum WHERE S.AliciID= " + id;
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Siparisler sip;
                while (okuyucu.Read())
                {
                    sip = new Siparisler();
                    sip.ID = okuyucu.GetInt32(0);
                    sip.UrunIsim = okuyucu.GetString(1);
                    sip.TurIsim = okuyucu.GetString(2);
                    sip.DurumIsim = okuyucu.GetString(3);
                    sip.AliciID = okuyucu.GetInt32(4);
                    sip.Miktar = okuyucu.GetInt32(5);
                    sip.Tarih = okuyucu.GetDateTime(6);
                    sip.Fiyat = okuyucu.GetDecimal(7);
                    sip.ToplamFiyat = sip.Miktar * sip.Fiyat;
                    siparislers.Add(sip);
                }

                return siparislers;
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

        #endregion
    }
}
