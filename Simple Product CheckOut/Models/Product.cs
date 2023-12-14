namespace Simple_Product_CheckOut.Models;

public  class Product
    {
        public char Code { get; }
        public int UnitPrice { get; }
        public PricingRule Rule { get; }

        public Product(char code, int unitPrice, PricingRule rule = null)
        {
            Code = code;
            UnitPrice = unitPrice;
            Rule = rule;
        }
    }