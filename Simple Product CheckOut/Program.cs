using Simple_Product_CheckOut.Models;
using Simple_Product_CheckOut.Services;


namespace Simple_Product_CheckOut;

class Program
{
    static void Main()
    {
        // Initialize products
        var products = new Dictionary<char, Product>
        {
            { 'A', new Product('A', 50, new PricingRule(3, 130)) },
            { 'B', new Product('B', 30, new PricingRule(2, 45)) },
            { 'C', new Product('C', 20) },
            { 'D', new Product('D', 15) }
        };
        // Initialize checkout system
        var checkout = new CheckOutService(products);
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add product 'A' to cart");
            Console.WriteLine("2. Add product 'B' to cart");
            Console.WriteLine("3. Add product 'C' to cart");
            Console.WriteLine("4. Add product 'D' to cart");
            Console.WriteLine("5. Checkout & print receipt");
            Console.WriteLine("6. Quit");

            var option = Console.ReadKey().KeyChar;
            Console.WriteLine(); 

            switch (option)
            {
                case '1':
                    checkout.AddToCart(products['A']);
                    break;
                case '2':
                    checkout.AddToCart(products['B']);
                    break;
                case '3':
                    checkout.AddToCart(products['C']);
                    break;
                case '4':
                    checkout.AddToCart(products['D']);
                    break;
                case '5':
                    checkout.PrintReceipt();
                    return;
                case '6':
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            
        }
    }
}
