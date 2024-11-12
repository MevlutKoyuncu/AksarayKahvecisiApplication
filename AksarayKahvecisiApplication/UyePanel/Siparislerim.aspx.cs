using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.UyePanel
{
    public partial class Siparislerim : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            Doldur();

        }

        protected void lv_siparisler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            Doldur();
        }
        void Doldur()
        {
            Alicilar al = (Alicilar)Session["GirisYapanUye"];
            int id = al.ID;
            lv_siparisler.DataSource = dm.SiparisleriGetir(id);
            lv_siparisler.DataBind();
        }
    }
}