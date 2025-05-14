using VM.Application.Component;
using VM.Application.Services;
using VM.Domain.Constants;
using VM.Domain.Entities;
using VM.Domain.Enums;

namespace VM.UnitTest
{
    public class VendingMachineTest
    {
        VendingMachine vendingMachine;     
        [SetUp]
        public void Setup()
        {
            var acceptCoinService = new AcceptCoinService();
            var SelectProductService = new SelectProductService();
            vendingMachine = new VendingMachine(acceptCoinService, SelectProductService);
        }

        [Test]
        public void Add_ValidCoin_Nickels()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin(CoinType.Nickels.ToString(), CoinValue.CoinList[CoinType.Nickels.ToString()]));
            Assert.AreEqual(vendingMachine.CurrentAmount,CoinValue.CoinList[CoinType.Nickels.ToString()]);
        }

        [Test]
        public void Validate_sum_ValidCoins()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin(CoinType.Nickels.ToString(), CoinValue.CoinList[CoinType.Nickels.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Dimes.ToString(), CoinValue.CoinList[CoinType.Dimes.ToString()]));
            var sum = CoinValue.CoinList[CoinType.Nickels.ToString()] + CoinValue.CoinList[CoinType.Dimes.ToString()];
            Assert.AreEqual(vendingMachine.CurrentAmount, sum);
        }
        [Test]
        public void Validate_InvalidPennies()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin(CoinType.Pennies.ToString(), CoinValue.CoinList[CoinType.Pennies.ToString()]));
            Assert.AreEqual(vendingMachine.CurrentAmount, 0.0);
        }

        [Test]
        public void Validate_Invalid_Ohter_Coins()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin("DummyCoin", CoinValue.CoinList[CoinType.Pennies.ToString()]));
            Assert.AreEqual(vendingMachine.CurrentAmount, 0.0);
        }

        [Test]
        public void Validate_Select_Chips()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            var selectProduct = vendingMachine.products.Find(it => it.ProductName == ProductType.Chips.ToString());
            vendingMachine.SelectProduct(selectProduct);
            Assert.AreEqual(vendingMachine.DisplayMessages, Messages.Thank_you);
        }



        [Test]
        public void Validate_Select_Product_with_lessAmount()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin(CoinType.Dimes.ToString(), CoinValue.CoinList[CoinType.Dimes.ToString()]));
            var selectProduct = vendingMachine.products.Find(it => it.ProductName == ProductType.Chips.ToString());
            vendingMachine.SelectProduct(selectProduct);
            Assert.AreEqual(vendingMachine.DisplayMessages, string.Format(Messages.Display_price,selectProduct.ProductPrice));
        }

        [Test]
        public void Validate_Select_Candy_with_Inserted_Coin_Message()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Nickels.ToString(), CoinValue.CoinList[CoinType.Nickels.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Nickels.ToString(), CoinValue.CoinList[CoinType.Nickels.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Nickels.ToString(), CoinValue.CoinList[CoinType.Nickels.ToString()]));
            var selectProduct = vendingMachine.products.Find(it => it.ProductName == ProductType.Candy.ToString());
            vendingMachine.SelectProduct(selectProduct);
            Assert.AreEqual(vendingMachine.DisplayMessages, Messages.Thank_you);
            
            vendingMachine.ResetAmount();
            Assert.AreEqual(vendingMachine.DisplayMessages, Messages.Inserted_coin);
            Assert.AreEqual(vendingMachine.CurrentAmount, 0.0);

        }

        [Test]
        public void Validate_excess_amount()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            var selectProduct = vendingMachine.products.Find(it => it.ProductName == ProductType.Chips.ToString());
            vendingMachine.SelectProduct(selectProduct);
            Assert.AreEqual(vendingMachine.DisplayMessages, Messages.Thank_you);
            Assert.AreEqual(vendingMachine.CurrentAmount, CoinValue.CoinList[CoinType.Quarters.ToString()]);
        }

        [Test]
        public void Validate_Select_Cola()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));

            var selectProduct = vendingMachine.products.Find(it => it.ProductName == ProductType.Cola.ToString());
            vendingMachine.SelectProduct(selectProduct);
            Assert.AreEqual(vendingMachine.DisplayMessages, Messages.Thank_you);
        }

        [Test]
        public void Validate_Select_Cola_with_less_Amount()
        {
            vendingMachine.ResetAmount();
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));
            vendingMachine.AcceptCoins(new Coin(CoinType.Quarters.ToString(), CoinValue.CoinList[CoinType.Quarters.ToString()]));

            var selectProduct = vendingMachine.products.Find(it => it.ProductName == ProductType.Cola.ToString());
            vendingMachine.SelectProduct(selectProduct);
            Assert.AreEqual(vendingMachine.DisplayMessages, string.Format(Messages.Display_price, selectProduct.ProductPrice));

        }


    }
}