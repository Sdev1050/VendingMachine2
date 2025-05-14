// See https://aka.ms/new-console-template for more information
using VM.Application.Services;
using VM.Domain.Constants;
using VM.Domain.Entities;
using VM.Domain.Enums;
using VM.Application.Component;

Console.WriteLine("Hello, World!");

var acceptCoinService = new AcceptCoinService();
var SelectProductService = new SelectProductService();
var vendingMachine = new VendingMachine(acceptCoinService, SelectProductService);

/*
 *  List<Product> products = new List<Product>();
            products.Add(new Product(101, ProductType.Cola.ToString(), ProductPrice.ProductList[ProductType.Cola.ToString()],100));
            products.Add(new Product(102, ProductType.Chips.ToString(), ProductPrice.ProductList[ProductType.Chips.ToString()],100));
            products.Add(new Product(103, ProductType.Candy.ToString(), ProductPrice.ProductList[ProductType.Candy.ToString()],100));
            return products;
 */

vendingMachine.SelectProduct(new Product(101, ProductType.Cola.ToString(), ProductPrice.ProductList[ProductType.Cola.ToString()], 2));