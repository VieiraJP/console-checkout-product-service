namespace Simple_Product_CheckOut.Models;

public class Receipt
{
    public List<ReceiptItem> Items { get; }
    public int TotalCost { get; }

    public Receipt(List<ReceiptItem> items, int totalCost)
    {
        Items = items ?? throw new ArgumentNullException(nameof(items));
        TotalCost = totalCost;
    }
}