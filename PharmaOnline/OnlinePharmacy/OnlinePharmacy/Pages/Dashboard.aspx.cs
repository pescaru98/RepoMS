using OnlinePharmacy.XMLModels;
using OnlinePharmacy.XMLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacy.Pages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        GitCoinService gitCoinService = new GitCoinService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "")
                Response.Redirect("ErrorPage.aspx");

            
        }

    }
}