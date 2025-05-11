using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public Product(int _productId,string _productName,double _productPrice,int _productQuantity)
        {
            ProductId = _productId;
            ProductName = _productName;
            ProductPrice = _productPrice;
            ProductQuantity = _productQuantity;
        }
    }
}
