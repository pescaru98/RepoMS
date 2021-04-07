using OnlinePharmacy.Models;
using OnlinePharmacy.XMLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacy.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        UserService userService = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null && Session["username"] != "")
                Response.Redirect("Dashboard.aspx");
        }

        public void reinit()
        {
            txtUser.Text = "";
            txtPass.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = new User(Guid.NewGuid(),txtUser.Text,txtPass.Text,"REGULAR",0,0.0);
            userService.create(user);
            reinit();
        }
    }
}