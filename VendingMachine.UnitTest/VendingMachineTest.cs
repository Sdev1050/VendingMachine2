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
            var returnCoin = new ReturnCoinService();
            var acceptCoinService = new AcceptCoinService(returnCoin);
            var SelectProductService = new SelectProductService();
            var displayMessageService = new DisplayMessageService();
            vendingMachine = new VendingMachine(acceptCoinService, SelectProductService, displayMessageService);
        }
        private static IEnumerable<TestCaseData> ProductPurchaseData()
        {
            yield return new TestCaseData(
                new CoinType[] { CoinType.Quarters, CoinType.Quarters },
                new Product(101, "Chips", 0.50),
                true
            ).SetName("Buy_Chips_With_Enough_Money");

            yield return new TestCaseData(
                new CoinType[] { CoinType.Quarters },
                new Product(101, "Chips", 0.50),
                false
            ).SetName("Buy_Chips_Without_Enough_Money");

            yield return new TestCaseData(
                new CoinType[] { CoinType.Quarters ,CoinType.Quarters,CoinType.Quarters},
                new Product(101, "Chips", 0.50),
                true
            ).SetName("Buy_Chips_More_Money");

            yield return new TestCaseData(
                new CoinType[] { CoinType.Quarters, CoinType.Quarters, CoinType.Quarters },
                new Product(102, "Candy", 0.65),
                true
            ).SetName("Buy_Candy_With_Enough_Money");

            yield return new TestCaseData(
                new CoinType[] { CoinType.Dimes },
                new Product(103, "Cola", 1.00),
                false
            ).SetName("Buy_Cola_With_Insufficient_Funds");

            yield return new TestCaseData(
               new CoinType[] { CoinType.Quarters, CoinType.Quarters, CoinType.Quarters ,CoinType.Quarters},
               new Product(103, "Cola", 1.00),
               true
           ).SetName("Buy_Cola_With_With_Enough_Money");

            yield return new TestCaseData(
             new CoinType[] { CoinType.Quarters, CoinType.Quarters, CoinType.Quarters, CoinType.Quarters ,CoinType.Dimes,CoinType.Dimes},
             new Product(103, "Cola", 1.00),
             true
         ).SetName("Buy_Cola_With_With_More_Money");
        }

        private static IEnumerable<TestCaseData> GetSumofValidCoin()
        {
            yield return new TestCaseData(
                new CoinType[] { CoinType.Quarters, CoinType.Quarters },
                0.50
            ).SetName("Valid Sum of Two Quaters");

            yield return new TestCaseData(
                new CoinType[] { CoinType.Quarters },
                0.25
            ).SetName("Validate the Value of Quater");

            yield return new TestCaseData(
                new CoinType[] { CoinType.Quarters, CoinType.Quarters, CoinType.Pennies },
                0.50
            ).SetName("Validate the Sum of two Quater with one Pennies");

            yield return new TestCaseData(
                new CoinType[] { CoinType.Dimes, CoinType.Quarters },
                0.35
            ).SetName("Validatet the Sum of Dimes and Quarters");
        }
        private VendingMachine SetupMachineWithCoins(params CoinType[] coinTypes)
        {
            vendingMachine.Reset();
            foreach (var type in coinTypes)
            {
                vendingMachine.AcceptCoins(new Coin(type.ToString(), CoinValue.CoinList[type.ToString()]));
            }
            return vendingMachine;
        }

        [Test]
        [TestCase("Nickels",0.05)]
        [TestCase("Dimes", 0.1)]
        [TestCase("Quarters", 0.25)]
        public void Add_ValidCoin_Nickels(string coin,double expectedValue)
        {
            vendingMachine.AcceptCoins(new Coin(coin, expectedValue));
            Assert.AreEqual(vendingMachine.GetCurrentAmount(), expectedValue);
        }

       
        [Test,TestCaseSource(nameof(GetSumofValidCoin))]
        public void Validate_Sum_Of_ValidCoins(CoinType[] insertedCoins, double expectedSum)
        {
            var machine = SetupMachineWithCoins(insertedCoins);
            var currentAmount = machine.GetCurrentAmount();
            Assert.AreEqual(currentAmount, expectedSum);

        }

        [Test]
        [TestCase("ABC", 0.1)]
        [TestCase("pennies", 0.1)]
        public void Validate_InvalidPennies(string coin, double expectedValue)
        {
            vendingMachine.AcceptCoins(new Coin(coin, expectedValue));
            Assert.AreEqual(vendingMachine.GetCurrentAmount(), 0.0);
        }

        [Test,TestCaseSource(nameof(ProductPurchaseData))]
        public void Validate_Selected_Products(CoinType[] insertedCoins, Product product, bool shouldSucceed)
        {
            var machine = SetupMachineWithCoins(insertedCoins);
            machine.SelectProduct(product);

            if (shouldSucceed)
            {
                Assert.AreEqual(Messages.Thank_you, machine.CheckDisplay());
                Assert.AreEqual(Messages.Inserted_coin, machine.CheckDisplay());
            }
            else
            {
                Assert.AreEqual($"PRICE : {product.ProductPrice}", machine.CheckDisplay());
            }

        }
    }
}