﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.AdminLoginPanel
{
    public partial class UrunEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)    
        {
            if (!IsPostBack)
            {
                cb_durum.Checked = true;
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (tb_isim.Text.Length < 50)
                {
                    Urunler ur = new Urunler();
                    ur.Isim = tb_isim.Text;
                    ur.Satici = tb_satici.Text;
                    ur.UreticiUlke = tb_ureticiUlke.Text;
                    ur.Fiyat = Math.Round(Convert.ToDecimal(tb_fiyat.Text), 2);
                    ur.Stok = int.Parse(tb_stok.Text);
                    ur.Satistami = cb_durum.Checked;
                    if (dm.UrunEkle(ur))
                    {
                        Response.Redirect("UrunListesi.aspx");
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        lbl_mesaj.Text = "Ürün eklenirken bir hata oluştu";
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
                lbl_mesaj.Text = "Ürün adı boş bırakılamaz";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
        }
    }
}