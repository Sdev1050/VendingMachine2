// See https://aka.ms/new-console-template for more information
using VM.Application.Services;
using VM.Domain.Constants;
using VM.Domain.Entities;
using VM.Domain.Enums;
using VM.Application.Component;

var returnCoinService = new ReturnCoinService();
var acceptCoinService = new AcceptCoinService(returnCoinService);
var SelectProductService = new SelectProductService();
var displayMessageService = new DisplayMessageService();
var vendingMachine = new VendingMachine(acceptCoinService, SelectProductService, displayMessageService);

Console.WriteLine("First Transation Start here");

vendingMachine = SetupMachineWithCoins(CoinType.Quarters, CoinType.Quarters);
var CurrentAmout= vendingMachine.GetCurrentAmount();
vendingMachine.SelectProduct(new Product(101, "Chips", 0.021));
var message = vendingMachine.CheckDisplay();
Console.WriteLine("Display Message State : {0}", message);
Console.WriteLine("Display Current Amount : {0}", CurrentAmout);

Console.WriteLine("First Transation End here");

vendingMachine.Reset();

Console.WriteLine("Second Transation Start here");
vendingMachine = SetupMachineWithCoins(CoinType.Quarters, CoinType.Quarters);
CurrentAmout = vendingMachine.GetCurrentAmount();
vendingMachine.SelectProduct(new Product(101, "Cola", 0.021));
message = vendingMachine.CheckDisplay();
Console.WriteLine("Display Message State : {0}", message);
Console.WriteLine("Display Current Amount : {0}", CurrentAmout);

Console.WriteLine("Second Transation Start here");

VendingMachine SetupMachineWithCoins(params CoinType[] coinTypes)
{
    vendingMachine.Reset();
    foreach (var type in coinTypes)
    {
        vendingMachine.AcceptCoins(new Coin(type.ToString(), CoinValue.CoinList[type.ToString()]));
    }
    return vendingMachine;
}

