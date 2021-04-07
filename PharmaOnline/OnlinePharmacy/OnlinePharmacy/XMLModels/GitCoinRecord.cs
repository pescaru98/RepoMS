using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.XMLModels
{
    public class GitCoinRecord
    {
        public Guid record_id { get; set; }
        public double price { get; set; }
        public DateTime record_date{ get; set; }

        public GitCoinRecord()
        {

        }

        public GitCoinRecord(Guid record_id, double price, DateTime record_date)
        {
            this.record_id = record_id;
            this.price = price;
            this.record_date = record_date;
        }
    }
}