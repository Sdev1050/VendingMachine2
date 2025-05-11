using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Interfaces
{
    public interface IAcceptCoin
    {
        bool ValidateCoin(Coin coin);
        double UpdateCurrentAmount(Coin coin);

    }
}
