using OnlinePharmacy.XMLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacy.Pages
{
    public partial class Transaction : System.Web.UI.Page
    {
        TransactionService transactionService = new TransactionService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "")
                Response.Redirect("ErrorPage.aspx");

            Table table = new Table();
            table.CssClass += "table table-striped border mt-3";
            createAndAddTableHeaders(table);

            List<OnlinePharmacy.Models.Transaction> myTransactions = transactionService.getTransactionsOfUserId(Guid.Parse(Session["user_id"].ToString()));

            myTransactions.ForEach(item =>
            {
                createAndAddTableRowOfOrder(item, table);
            });

            transactionsPanel.Controls.Add(table);
        }


        private void createAndAddTableHeaders(System.Web.UI.WebControls.Table table)
        {
            string[] names = { "Buyer ID", "Seller ID", "Date", "Coins number", "Coin price" };
            TableRow row = new TableRow();

            for (int i = 0; i < 5; i++)
            {
                TableCell cell = new TableCell();
                cell.Text = names[i];
                cell.CssClass = "font-weight-bold";
                row.Cells.Add(cell);
            }

            table.Rows.Add(row);
        }

        private void createAndAddTableRowOfOrder(OnlinePharmacy.Models.Transaction transaction, Table table)
        {
            TableRow row = new TableRow();

            TableCell buyer_id = new TableCell();
            TableCell seller_id = new TableCell();
            TableCell issue_date = new TableCell();
            TableCell coins = new TableCell();
            TableCell coin_price = new TableCell();

            buyer_id.Text = transaction.buyer_id.ToString();
            seller_id.Text = transaction.seller_id.ToString();
            issue_date.Text = transaction.issue_date.ToString();
            coins.Text = transaction.coins.ToString();
            coin_price.Text = transaction.coin_price.ToString();

            row.Cells.Add(buyer_id);
            row.Cells.Add(seller_id);
            row.Cells.Add(issue_date);
            row.Cells.Add(coins);
            row.Cells.Add(coin_price);


            table.Rows.Add(row);
        }
    }
}