using OnlinePharmacy.XMLServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.XMLModels
{
    public class Currency
    {
        private static GitCoinService gitCoinService = new GitCoinService();

        public static double GitInDollar(double GitCoins)
        {
            return GitCoins * gitCoinService.getCurrentGitCoinValue();
        }

        public static double DollarInGit(double Dollars)
        {
            return Dollars * 1 / gitCoinService.getCurrentGitCoinValue();
        }
    }
}