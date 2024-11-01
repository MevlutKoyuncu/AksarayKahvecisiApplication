using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.AdminLoginPanel
{
    public partial class Duyurular : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_duyuruekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_baslik.Text))
            {
                if (tb_baslik.Text.Length < 50)
                {
                    Duyurular duy = new Duyurular();
                    duy.Baslik = tb_baslik.Text;
                    duy.Icerik = tb_icerik.Text;
                    duy.Tarih = DateTime.Now;
                    if (dm.DuyuruEkle(duy))
                    {
                        Response.Redirect("Duyurular.aspx");
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        lbl_mesaj.Text = "Duyuru eklenirken bir hata oluştu";
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                    }
                }
                else
                {
                    lbl_mesaj.Text = "Duyuru başlığı 50 karakterden büyük olamaz";
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                }
            }
            else
            {
                lbl_mesaj.Text = "Duyuru başlığı boş bırakılamaz";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
        }
    }
}