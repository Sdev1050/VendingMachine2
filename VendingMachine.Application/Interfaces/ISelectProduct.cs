using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Domain.Entities;

namespace VM.Application.Interfaces
{
    public interface ISelectProduct
    {
        bool CheckValidProduct(Product product);

        bool ValidatePrice(Product product, double currentAmount);

        List<Product> GetAllListOfProduct();
        
    }
}
