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
        /*Current Amount and display Messages used for Validation in test Cases*/
        private double  CurrentAmount { get; set; }
        private List<Product> products { get; set; }
        private readonly IAcceptCoin acceptCoin;
        private readonly ISelectProduct selectProduct;
        private readonly IDisplayMessage displayMessage;
        public double GetCurrentAmount() => CurrentAmount;
        public VendingMachine()
        {
            
        }
        public VendingMachine(IAcceptCoin _acceptCoin,ISelectProduct  _selectProduct,IDisplayMessage _displayMessage)
        {
            acceptCoin = _acceptCoin;
            selectProduct = _selectProduct;
            displayMessage = _displayMessage;
            products = selectProduct.GetAllListOfProduct();
        }

        public void Reset()
        {
            CurrentAmount = 0.0;
            displayMessage.SetMessage(Messages.Inserted_coin);
        }

        public void AcceptCoins(Coin coin)
        {
            displayMessage.SetMessage(Messages.Inserted_coin);

            if (acceptCoin.ValidateCoin(coin))
            {
                CurrentAmount += coin.CoinValue;

            }else
            {
                ReturnCoin();
            }
        }

        public bool SelectProduct(Product product)
        {
            bool result = false;

            result = selectProduct.ValidatePrice(product, CurrentAmount);

            if(result)
            {
                /*Access Amount and equal to Price*/
                displayMessage.SetMessage(Messages.Thank_you);
                DispenseTheProduct(product);
                /*Setting Up the Current Amount*/
                CurrentAmount = CurrentAmount - product.ProductPrice;

            }else {
                /*LessAmount and try to select the Product*/

                displayMessage.SetMessage(string.Format(Messages.Display_price,product.ProductPrice));
            }

            return result;
        }

        private void ReturnCoin()
        {
           IReadOnlyList<Coin> listOfCoin = acceptCoin.GetAllReturnCoin();
            foreach (Coin coin in listOfCoin)
            {
                Console.WriteLine("Return Coin {0}: {1}", coin.CoinType, coin.CoinValue);
            }
        }

        private void DispenseTheProduct(Product product)
        {
            Console.WriteLine("Return coin : {0}",product.ProductName);
        }

        public string CheckDisplay()
        {
            string message = displayMessage.GetMessage();
            if (message == Messages.Thank_you || message.StartsWith("PRICE"))
            {
                displayMessage.ResetMessage();
            }
            return message;
        }
      }
}
