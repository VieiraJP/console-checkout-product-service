namespace Simple_Product_CheckOut.Models;

//The use of the record keyword here is to make the PricingRule class immutable.
//There are a few other benefits of using records, namely that they are easier to compare and hash, conciseness of syntax and reduced boiler plate.
public record PricingRule(int SpecialQuantity, int SpecialPrice);
