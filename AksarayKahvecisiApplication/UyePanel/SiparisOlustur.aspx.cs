using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.UyePanel
{
    public partial class SiparisOlustur : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_urunler.DataSource = dm.UrunleriGetir(true);
                ddl_urunler.DataBind();
                ddl_ureticiulke.DataSource = dm.UreticiUlkeleriGetir();
                ddl_ureticiulke.DataBind();
            }
        }

        protected void lbtn_siparisolustur_Click(object sender, EventArgs e)
        {
            Alicilar al = (Alicilar)Session["GirisYapanUye"];
            Siparisler u = new Siparisler();
            u.AliciID = al.ID;
            u.UrunID = Convert.ToInt32(ddl_urunler.SelectedItem.Value);
            u.TurID = Convert.ToInt32(ddl_ureticiulke.SelectedItem.Value);
            u.Tarih = DateTime.Now;
            u.Miktar = Convert.ToInt32(tb_miktar.Text);
            u.DurumID = 1;
            //if(!string.IsNullOrEmpty(tb_isim.Text))
            if (dm.SiparisOlustur(u))
            {
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
    }           
}