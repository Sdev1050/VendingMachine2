using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Domain.Enums;

namespace VM.Domain.Constants
{
    public class ProductPrice
    {
        public static Dictionary<string, double> ProductList;
        static ProductPrice()
        {
            ProductList = new Dictionary<string, double>();
            ProductList.Add(ProductType.Cola.ToString(), 1.00);
            ProductList.Add(ProductType.Chips.ToString(), 0.50);
            ProductList.Add(ProductType.Candy.ToString(), 0.65);
        }
    }
}

