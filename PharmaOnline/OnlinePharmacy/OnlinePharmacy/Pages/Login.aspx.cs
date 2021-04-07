
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

    public partial class Login : System.Web.UI.Page
    {
        private UserService userService = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null && Session["username"] != "" )
                Response.Redirect("Dashboard.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = userService.getByUsernameAndPassword(txtUser.Text, txtPass.Text);
            if (user != null) {
                Session["user_id"] = user.user_id;
                Session["username"] = user.username;
                Session["role"] = user.role;
                Session["coins"] = user.coins;
                Session["balance"] = user.balance;
                Session.Timeout = 60;
                Response.Redirect("Dashboard.aspx");
            }
        }
    }
}