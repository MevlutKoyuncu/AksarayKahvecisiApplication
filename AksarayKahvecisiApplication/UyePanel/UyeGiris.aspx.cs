using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.UyePanel
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_uyegiris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_uyekadi.Text))
            {
                if (!string.IsNullOrEmpty(tb_uyesifre.Text))
                {
                    Alicilar u = dm.UyeGiris(tb_uyekadi.Text, tb_uyesifre.Text);
                    if (u != null)
                    {
                        Session["GirisYapanUye"] = u;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        pnl_hata.Visible = true;
                        lbl_hatametin.Text = "Kullanıcı Bulunamadı";
                    }
                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_hatametin.Text = "Şifre boş bırakılamaz";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_hatametin.Text = "Mail adresi boş bırakılamaz";
            }
        }
    }
}