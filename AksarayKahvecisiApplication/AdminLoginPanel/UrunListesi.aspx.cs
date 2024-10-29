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
            if (!IsPostBack)
            {
                Doldur();
            }
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
        }
        void Doldur()
        {
            lv_urunler.DataSource = dm.UrunleriGetir();
            lv_urunler.DataBind();
        }
    }
}