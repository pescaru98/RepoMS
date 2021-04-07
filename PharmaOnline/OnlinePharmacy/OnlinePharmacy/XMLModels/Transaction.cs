using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class Transaction
    {
        public Guid transaction_id { get; set; }
        public Guid buyer_id { get; set; }
        public Guid seller_id { get; set; }
        public DateTime issue_date { get; set; }
        public double coins{ get; set; }
        public double coin_price{ get; set; }

        public Transaction()
        {

        }

        public Transaction(Guid transaction_id, Guid buyer_id, Guid seller_id, DateTime issue_date, double coins, double coin_price)
        {
            this.transaction_id = transaction_id;
            this.buyer_id = buyer_id;
            this.seller_id = seller_id;
            this.issue_date = issue_date;
            this.coins = coins;
            this.coin_price = coin_price;
        }
    }
}