using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Application.Interfaces;
using VM.Domain.Constants;
using VM.Domain.Entities;
using VM.Domain.Enums;

namespace VM.Application.Services
{
    public class SelectProductService : ISelectProduct
    {
        public bool CheckValidProduct(Product product)
        {
            bool result = false;

            if (Enum.GetNames(typeof(ProductType)).ToList().Find(it=> it.Equals(product.ProductName)) != null)
                result = true;

            return result;
        }

        public List<Product> GetAllListOfProduct()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(101, ProductType.Cola.ToString(), ProductPrice.ProductList[ProductType.Cola.ToString()],100));
            products.Add(new Product(102, ProductType.Chips.ToString(), ProductPrice.ProductList[ProductType.Chips.ToString()],100));
            products.Add(new Product(103, ProductType.Candy.ToString(), ProductPrice.ProductList[ProductType.Candy.ToString()],100));
            return products;

        }

        public bool ValidatePrice(Product product, double currentAmount)
        {
            bool result = false;

            if(CheckValidProduct(product))
            {
                if(currentAmount >= product.ProductPrice)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }else
            {
                result = false;
            }
            return result;
        }
    }
}
