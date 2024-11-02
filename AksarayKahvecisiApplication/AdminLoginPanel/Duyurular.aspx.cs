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
            Doldur();
        }

        void Doldur()
        {
            lv_duyuru.DataSource = dm.DuyurulariGetir(true);
            lv_duyuru.DataBind();
        }

        protected void lv_duyuru_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.DuyuruSil(id);
            }
            Doldur();
        }
    }
}