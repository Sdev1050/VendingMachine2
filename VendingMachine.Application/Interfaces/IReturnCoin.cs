using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Domain.Entities;

namespace VM.Application.Interfaces
{
    public interface IReturnCoin
    {
        IReadOnlyList<Coin> GetReturnedCoins();
        void AddReturnCoin(Coin coin);
        void ClearCoin();
    }
}
