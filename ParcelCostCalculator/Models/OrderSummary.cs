namespace ParcelCostCalculator.Models;

public class OrderSummary
{
    public required List<PricedItem> Items { get; set; }

    public decimal TotalCost { get; set; }
}
