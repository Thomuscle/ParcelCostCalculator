using ParcelCostCalculator.Enums;

namespace ParcelCostCalculator.Models;

public class PricedParcel
{
    public Parcel? ParcelDetails { get; set; }

    public ItemType Type { get; set; }

    public decimal Cost { get; set; }
}
