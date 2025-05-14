using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Application.Interfaces;
using VM.Domain.Entities;

namespace VM.Application.Services
{
    public class ReturnCoinService :IReturnCoin
    {
        private List<Coin> returnedCoins = new List<Coin>();
        public IReadOnlyList<Coin> GetReturnedCoins() => returnedCoins.AsReadOnly();
        public void AddReturnCoin(Coin coin)
        {
            returnedCoins.Add(coin);
        }
        public void ClearCoin()
        {
            returnedCoins.Clear();
        }
    }
}
