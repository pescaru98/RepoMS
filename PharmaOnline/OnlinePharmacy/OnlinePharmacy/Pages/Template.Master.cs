using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacy.Pages
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine(Session["role"]);
            loggedUserLabel.Text = "Logged as, "+Session["username"].ToString();
            coins.Text = Session["coins"].ToString() + " ㈤";
            coins.CssClass = "badge badge-warning ml-4 mr-4";
            balance.Text = Session["balance"].ToString()+ " $";
            balance.CssClass = "badge badge-success ml-4";
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Session["user_id"] = null;
            Session["username"] = null;
            Session["role"] = null;
            Session["coins"] = null;
            Session["balance"] = null;
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}