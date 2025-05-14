using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Application.Interfaces;
using VM.Application.Services;
using VM.Domain.Constants;
using VM.Domain.Entities;

namespace VM.Application.Component
{
    public class VendingMachine
    {
        public  double  CurrentAmount { get; set; }
        public string DisplayMessages { get; set; }
        public List<Product> products { get; set; }

        public IAcceptCoin acceptCoin;
        public ISelectProduct selectProduct;

        public VendingMachine()
        {
            
        }
        public VendingMachine(IAcceptCoin _acceptCoin,ISelectProduct  _selectProduct)
        {
            acceptCoin = _acceptCoin;
            selectProduct = _selectProduct;
            products = selectProduct.GetAllListOfProduct();
        }

        public void ResetAmount ()
        {
            CurrentAmount = 0.0;
            DisplayMessages = Messages.Inserted_coin;
        }

        public void AcceptCoins(Coin coin)
        {
            if(acceptCoin.ValidateCoin(coin))
            {
                CurrentAmount += coin.CoinValue;

            }else
            {
                ReturnCoin();
            }
        }

        public void SelectProduct(Product product)
        {
            bool result = false;

            result = selectProduct.ValidatePrice(product, CurrentAmount);

            if(result)
            {
                /*Access Amount and equal to Price*/
                DisplayMessages = Messages.Thank_you;
                DispenseTheProduct(product);
                /*show the excess Amount*/
                if (CurrentAmount > product.ProductPrice)
                    CurrentAmount = CurrentAmount - product.ProductPrice;

            }else {
                /*LessAmount and try to select the Product*/
                DisplayMessages = string.Format(Messages.Display_price,product.ProductPrice);
            }
        }

        private void ReturnCoin()
        {
            Console.WriteLine("Return coin");
        }

        private void DispenseTheProduct(Product product)
        {
            Console.WriteLine("Return coin : {0}",product.ProductName);
        }


      }
}
