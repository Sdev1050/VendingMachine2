using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Domain.Entities;

namespace VM.Application.Interfaces
{
    public interface IAcceptCoin
    {
        bool ValidateCoin(Coin coin);
        double UpdateCurrentAmount(Coin coin);

        IReadOnlyList<Coin> GetAllReturnCoin();

        void ClearReturnCoin();

    }
}
