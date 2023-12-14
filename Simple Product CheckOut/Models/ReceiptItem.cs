namespace Simple_Product_CheckOut.Models;

//
public class ReceiptItem
{
    public char ProductCode { get; }
    public int Quantity { get; }
    public int SubTotal { get; }

    public ReceiptItem(char productCode, int quantity, int subTotal)
    {
        ProductCode = productCode;
        Quantity = quantity;
        SubTotal = subTotal;
    }
}