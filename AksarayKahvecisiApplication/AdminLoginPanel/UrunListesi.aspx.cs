using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.AdminLoginPanel
{
    public partial class UrunListesi : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        protected void lv_urunler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "satistami")
            {
                dm.UrunDurumDegistir(id);
            }
            if (e.CommandName == "sil")
            {
                dm.UrunSil(id);
            }
            Doldur();
        }
        void Doldur()
        {
            lv_urunler.DataSource = dm.UrunleriGetir();
            lv_urunler.DataBind();
        }
        void Doldur2()
        {
            lv_urunler.DataSource = dm.AzalanUrunleriGetir();
            lv_urunler.DataBind();
        }

        protected void lbtn_azalanurunler_Click(object sender, EventArgs e)
        {
            Doldur2();
        }
    }
}