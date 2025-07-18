namespace ParcelCostCalculator.Models;

public class OrderSummary
{
    public required List<PricedParcel> Parcels { get; set; }

    public decimal TotalCost { get; set; }
}
