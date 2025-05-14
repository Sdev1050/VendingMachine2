using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Domain.Enums;

namespace VM.Domain.Entities
{
    public class Coin
    {

        public string CoinType { get; set; }

        public double CoinValue { get; set; }

        public Coin( string _coinType , double _coinValue)
        {
            CoinType = _coinType;
            CoinValue = _coinValue;
        }
    }
}
