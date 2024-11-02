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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_siparisolustur_Click(object sender, EventArgs e)
        {
            Alicilar al = (Alicilar)Session["GirisYapanUye"];
            Siparisler u = new Siparisler();
            u.ID = Convert.ToInt32(ddl_urunler.SelectedItem.Value);
            
        }
    }
}