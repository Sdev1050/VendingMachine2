// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using VendingMachine.Application.Component;
using VendingMachine.Application.Servies;
using VendingMachine.Domain.Constants;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Enums;

Console.WriteLine("Hello, World!");

var acceptCoinService = new AcceptCoinService();
var SelectProductService = new SelectProductService();
var vendingMachine = new VVendingMachine(acceptCoinService, SelectProductService);

/*
 *  List<Product> products = new List<Product>();
            products.Add(new Product(101, ProductType.Cola.ToString(), ProductPrice.ProductList[ProductType.Cola.ToString()],100));
            products.Add(new Product(102, ProductType.Chips.ToString(), ProductPrice.ProductList[ProductType.Chips.ToString()],100));
            products.Add(new Product(103, ProductType.Candy.ToString(), ProductPrice.ProductList[ProductType.Candy.ToString()],100));
            return products;
 */

vendingMachine.SelectProduct(new Product(101, ProductType.Cola.ToString(), ProductPrice.ProductList[ProductType.Cola.ToString()], 2));