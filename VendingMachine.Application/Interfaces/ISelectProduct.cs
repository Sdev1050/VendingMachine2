using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Interfaces
{
    public interface ISelectProduct
    {
        bool CheckValidProduct(Product product);

        bool ValidatePrice(Product product, double currentAmount);

        List<Product> GetAllListOfProduct();
        
    }
}
