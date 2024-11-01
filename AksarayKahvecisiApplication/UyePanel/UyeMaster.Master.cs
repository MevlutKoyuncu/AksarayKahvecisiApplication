using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.UyePanel
{
    public partial class UyeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanUye"] != null)
            {
                Alicilar u = (Alicilar)Session["GirisYapanUye"];
                lbl_kullanici.Text = u.Isim + "(" + u.UyelikTur + ")";
            }
            else
            {
                Response.Redirect("UyeGiris.aspx");
            }
        }

        protected void lbtn_uyecikis_Click(object sender, EventArgs e)
        {
            Session["GirisYapanUye"] = null;
            Response.Redirect("UyeGiris.aspx");
        }
    }
}