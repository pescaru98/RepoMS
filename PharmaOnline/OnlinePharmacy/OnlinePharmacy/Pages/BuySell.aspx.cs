using OnlinePharmacy.Models;
using OnlinePharmacy.XMLModels;
using OnlinePharmacy.XMLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacy.Pages
{
    public partial class BuySell : System.Web.UI.Page
    {
        GitCoinService gitCoinService = new GitCoinService();
        TransactionService transactionService = new TransactionService();
        UserService userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "")
                Response.Redirect("ErrorPage.aspx");

            //gitCoinService.create(new XMLModels.GitCoinRecord(Guid.NewGuid(), 15.5, DateTime.Now));
        }

        public void reinitSell()
        {
            sellDollar.Text = "";
            sellGit.Text = "";
        }

        public void reinitBuy()
        {
            buyDollar.Text = "";
            buyGit.Text = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //sell
            double coin_value = gitCoinService.getCurrentGitCoinValue();
            DateTime now = DateTime.Now;
            if (Convert.ToDouble(sellGit.Text) <= Convert.ToDouble(Session["coins"]))
            {
                OnlinePharmacy.Models.Transaction transaction = new OnlinePharmacy.Models.Transaction(Guid.NewGuid(), Guid.Parse("eb3a6eb7-c95b-4b9f-9737-f75c3366577b"), Guid.Parse(Session["user_id"].ToString()), now, Convert.ToDouble(sellGit.Text) , coin_value);
                transactionService.create(transaction);
                double next_coin_value = gitCoinService.calculateNextCoinValue(Convert.ToDouble(sellGit.Text), coin_value, 1);
                gitCoinService.create(new GitCoinRecord(Guid.NewGuid(), next_coin_value, now));

                double new_coins = Convert.ToDouble(Session["coins"]) - Convert.ToDouble(sellGit.Text);
                double new_balance = Convert.ToDouble(Session["balance"]) + Currency.GitInDollar(Convert.ToDouble(sellGit.Text));

                Session["coins"] = new_coins;
                Session["balance"] = new_balance;

                userService.updateCoinsAndBalanceOfUserId(Guid.Parse(Session["user_id"].ToString()), new_coins, new_balance);


                reinitSell();

            }

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //buy
            double coin_value = gitCoinService.getCurrentGitCoinValue();
            double coins_in_dollars = Currency.GitInDollar(Convert.ToDouble(buyGit.Text));
            DateTime now = DateTime.Now;

            if (coins_in_dollars <= Convert.ToDouble(Session["balance"]))
            {
                OnlinePharmacy.Models.Transaction transaction = new OnlinePharmacy.Models.Transaction(Guid.NewGuid(),  Guid.Parse(Session["user_id"].ToString()), Guid.Parse("eb3a6eb7-c95b-4b9f-9737-f75c3366577b"), now, Convert.ToDouble(buyGit.Text), coin_value);
                transactionService.create(transaction);

                double next_coin_value = gitCoinService.calculateNextCoinValue(Convert.ToDouble(buyGit.Text), coin_value, 2);
                gitCoinService.create(new GitCoinRecord(Guid.NewGuid(), next_coin_value, now));

                double new_coins = Convert.ToDouble(Session["coins"]) + Convert.ToDouble(buyGit.Text); 
                double new_balance = Convert.ToDouble(Session["balance"]) - Currency.GitInDollar(Convert.ToDouble(buyGit.Text));

                Session["coins"] = new_coins;
                Session["balance"] = new_balance;

                userService.updateCoinsAndBalanceOfUserId(Guid.Parse(Session["user_id"].ToString()), new_coins, new_balance);

                reinitBuy();
            }

                
        }

        protected void sellDollar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void sellGit_TextChanged(object sender, EventArgs e)
        {
            if (sellGit.Text != null && sellGit.Text != "")
                sellDollar.Text = Convert.ToString(Currency.GitInDollar(Convert.ToDouble(sellGit.Text)));
            else
                sellDollar.Text = "";
        }

        protected void buyGit_TextChanged(object sender, EventArgs e)
        {
            if (buyGit.Text != null && buyGit.Text != "")
                buyDollar.Text = Convert.ToString(Currency.GitInDollar(Convert.ToDouble(buyGit.Text)));
            else
                buyDollar.Text = "";
        }
    }
}