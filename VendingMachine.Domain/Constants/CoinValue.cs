using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Enums;

namespace VendingMachine.Domain.Constants
{
    public class CoinValue
    {
        public static Dictionary<string, double> CoinList;
        static CoinValue()
        {
            CoinList = new Dictionary<string, double>();
            CoinList.Add(CoinType.Dimes.ToString(), 0.1);
            CoinList.Add(CoinType.Nickels.ToString(), 0.05);
            CoinList.Add(CoinType.Pennies.ToString(), 0.01);
            CoinList.Add(CoinType.Quarters.ToString(), 0.25);
        }
    }
}
