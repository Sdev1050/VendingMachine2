using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Application.Interfaces;
using VM.Domain.Entities;
using VM.Domain.Enums;

namespace VM.Application.Services
{
    public class AcceptCoinService : IAcceptCoin
    {
        public double UpdateCurrentAmount(Coin coin)
        {
            if (ValidateCoin(coin))
                return coin.CoinValue;

            return 0.0;
        }
        public bool ValidateCoin(Coin coin)
        {
            bool result = false;
            var coinTypes = Enum.GetValues(typeof(CoinType));
            List<string> coinTypeStrings = coinTypes.Cast<CoinType>()
                                                  .Select(c => c.ToString())
                                                  .ToList();

            if (coin != null  && 
                string.Equals(coin.CoinType , CoinType.Pennies.ToString()) || 
                !coinTypeStrings.Contains(coin.CoinType)) {
                result = false;
            }else if(coin!= null)
            {
                result = true;
            }
            return result;
        }
    }
}
