using Simple_Product_CheckOut.Models;

namespace Simple_Product_CheckOut.Services;

public class CheckOutService
{
    public Dictionary<char, Product> Products;
    public Dictionary<char, int> Cart;
    public CheckOutService(Dictionary<char, Product> products)
    {
        this.Products = products;
        Cart = new Dictionary<char, int>();
    }

    public void AddToCart(Product product)
    {
        if (Products.ContainsValue(product))
        {
            if (!Cart.ContainsKey(product.Code))
                Cart[product.Code] = 1;
            else
                Cart[product.Code]++;
            
            PrintConfirmation(product.Code);

        }
        else
        {
            Console.WriteLine("Invalid product. Please try again.");
        }
    }

    public Receipt PrintReceipt()
    {
        var items = new List<ReceiptItem>();
        var totalCost = 0;

        foreach (var (productCode, quantity) in Cart)
        {
            var product = Products[productCode];

            var individualPrice = product.UnitPrice * quantity;
            var subTotal = 0;

            var specialPrice = CalculateSpecialPrice(product, quantity);
            if (product.Rule is null || quantity<product.Rule.SpecialQuantity)
            {
                subTotal = individualPrice;
            }else
            {
                subTotal = specialPrice;
            }

            totalCost += subTotal;
            items.Add(new ReceiptItem(productCode, quantity, subTotal));
            Console.WriteLine($"Product: {productCode}, Quantity: {quantity},SubTotal: ${subTotal}, Total: ${totalCost}");
        }

        Console.WriteLine($"Final Cost: ${totalCost}");
        
        return new Receipt(items, totalCost);
    }

    private int CalculateSpecialPrice(Product product, int quantity)
    {
        // if no rule or quantity is less than special quantity, return 0
        if (product.Rule is null || quantity<product.Rule.SpecialQuantity) return 0;
        var specialQuantity = product.Rule.SpecialQuantity;
        var specialPrice = product.Rule.SpecialPrice;

        //Calculate how many sets of the special quantity can be purchased and the remaining quantity
        var setsPurchased = quantity / specialQuantity;
        var remainder = quantity % specialQuantity;

        //Calculate the total price for the sets purchased at the special price and
        //the price for the remaining quantity at the regular unit price.
        var specialPriceTotal = setsPurchased * specialPrice;
        var remainderPrice = remainder * product.UnitPrice;

        //Return the sum of the total special price and the remainder price as
        //the final calculated special price for the given quantity.
        return specialPriceTotal + remainderPrice;

    }
    
    private void PrintConfirmation(char productCode)
    {
        Console.WriteLine($"Product {productCode} added to cart");
    }
}