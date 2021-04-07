using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class User
    {
        public Guid user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public double coins { get; set; }
        public double balance { get; set; }

        public User()
        {

        }

        public User(Guid user_id, string username, string password, string role, double coins, double balance)
        {
            this.user_id = user_id;
            this.username = username;
            this.password = password;
            this.role = role;
            this.coins = coins;
            this.balance = balance;
        }
    }
}