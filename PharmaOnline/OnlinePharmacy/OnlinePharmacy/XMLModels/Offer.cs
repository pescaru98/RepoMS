using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class Offer
    {
        public Guid offer_id { get; set; }
        public Guid user_id { get; set; }
        /*1. Buy 2. Sell*/
        public int offer_type { get; set; }
        /*1. Pending 2. Finished 3. Cancelled*/
        public int offer_status { get; set; }
        public DateTime issue_date { get; set; }
        public double coins { get; set; }
       
    }
}