using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.AdminLoginPanel
{
    public partial class DuyuruEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbtn_duyuruekle_Click(object sender, EventArgs e)
        {
            Yonetici y = (Yonetici)Session["GirisYapanYonetici"];
            if (!string.IsNullOrEmpty(tb_baslik.Text))
            {
                if (tb_baslik.Text.Length < 50)
                {
                    News n = new News();
                    n.Baslik = tb_baslik.Text;
                    n.Icerik = tb_icerik.Text;
                    n.Tarih = DateTime.Now;
                    if (dm.DuyuruEkle(n))
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
                    lbl_mesaj.Text = "Başlık 50 karakterden büyük olamaz";
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                }
            }
            else
            {
                lbl_mesaj.Text = "Başlık boş bırakılamaz";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
        }
    }
}