using ParcelCostCalculator.Enums;

namespace ParcelCostCalculator.Models;

public class PricedParcel
{
    public required Parcel ParcelDetails { get; set; }

    public ParcelType Type { get; set; }

    public decimal Cost { get; set; }
}
