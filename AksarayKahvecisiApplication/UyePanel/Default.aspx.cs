using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AksarayKahvecisiApplication.UyePanel
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        protected void lv_duyuru1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
           
        }
        void Doldur()
        {
            lv_duyuru1.DataSource = dm.DuyurulariGetir(true);
            lv_duyuru1.DataBind();
        }
    }
}