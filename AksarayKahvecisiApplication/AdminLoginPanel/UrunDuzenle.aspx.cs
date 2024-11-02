using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.AdminLoginPanel
{
    public partial class UrunDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["uid"]);
                    Urunler ur = dm.UrunGetir(id);
                    tb_isim.Text = ur.Isim;
                    tb_satici.Text = ur.Satici;
                    tb_ureticiUlke.Text = ur.UreticiUlke;
                    tb_fiyat.Text = ur.Fiyat.ToString();
                    tb_stok.Text = ur.Stok.ToString();
                    cb_durum.Checked = ur.Satistami;
                }
            }
            else
            {
                Response.Redirect("UrunListesi.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            Yonetici y = (Yonetici)Session["GirisYapanYonetici"];
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (tb_isim.Text.Length < 50)
                {
                    int id = Convert.ToInt32(Request.QueryString["uid"]);
                    Urunler ur = dm.UrunGetir(id);
                    ur.Isim = tb_isim.Text;
                    ur.Satici = tb_satici.Text;
                    ur.UreticiUlke = tb_ureticiUlke.Text;
                    ur.Fiyat = Convert.ToDecimal(tb_fiyat.Text);
                    ur.Stok = int.Parse(tb_stok.Text);
                    ur.Satistami = cb_durum.Checked;
                    if (dm.UrunGuncelle(ur))
                    {
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        lbl_mesaj.Text = "Ürün düzenlenirken bir hata oluştu";
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                    }
                }
                else
                {
                    lbl_mesaj.Text = "Ürün adı 50 karakterden büyük olamaz";
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                }
            }
            else
            {
                lbl_mesaj.Text = "Ürün Adı boş bırakılamaz";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
        }
    }
}