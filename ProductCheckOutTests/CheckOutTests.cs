using System.Collections.Generic;
using System.Linq;
using Simple_Product_CheckOut;
using Simple_Product_CheckOut.Models;
using Simple_Product_CheckOut.Services;

namespace ProductCheckOutTests;

[TestFixture]
public class CheckOutServiceTests
{
    [Test]
    public void AddingProductsToCart_ShouldIncreaseQuantities()
    {
        // Arrange
        var products = GetTestProducts();
        var checkout = new CheckOutService(products);

        // Act
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['D']);

        // Assert
        Assert.That(checkout.Cart['A'], Is.EqualTo(3));
        Assert.That(checkout.Cart['D'], Is.EqualTo(1));
    }

    [Test]
    public void PrintingReceipt_ShouldCalculateSubTotalForSpecialPrices()
    {
        // Arrange
        var products = GetTestProducts();
        var checkout = new CheckOutService(products);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['D']);

        // Act
        var receipt = checkout.PrintReceipt();

        // Assert
        Assert.That(receipt.Items.Count, Is.EqualTo(2));
        Assert.That(receipt.Items.Sum(item => item.SubTotal), Is.EqualTo(145));
    }

    [Test]
    public void PrintingReceipt_ShouldCalculateSubTotalForProductA()
    {
        // Arrange
        var products = GetTestProducts();
        var checkout = new CheckOutService(products);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['D']);

        // Act
        var receipt = checkout.PrintReceipt();
        var subTotalA = receipt.Items.FirstOrDefault(item => item.ProductCode == 'A')?.SubTotal ?? 0;

        // Assert
        Assert.That(subTotalA, Is.EqualTo(130));
    }

    [Test]
    public void PrintingReceipt_ShouldCalculateSubTotalForProductD()
    {
        // Arrange
        var products = GetTestProducts();
        var checkout = new CheckOutService(products);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['A']);
        checkout.AddToCart(products['D']);

        // Act
        var receipt = checkout.PrintReceipt();
        var subTotalD = receipt.Items.FirstOrDefault(item => item.ProductCode == 'D')?.SubTotal ?? 0;

        // Assert
        Assert.That(subTotalD, Is.EqualTo(15));
    }

    private Dictionary<char, Product> GetTestProducts()
    {
        return new Dictionary<char, Product>
        {
            { 'A', new Product('A', 50, new PricingRule(3, 130)) },
            { 'B', new Product('B', 30, new PricingRule(2, 45)) },
            { 'C', new Product('C', 20) },
            { 'D', new Product('D', 15) }
        };
    }
}