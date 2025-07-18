using ParcelCostCalculator.Enums;

namespace ParcelCostCalculator.Models;

public class PricedItem
{
    public Parcel? ParcelDetails { get; set; }

    public ItemType Type { get; set; }

    public decimal Cost { get; set; }
}
