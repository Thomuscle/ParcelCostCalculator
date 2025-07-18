using ParcelCostCalculator.Enums;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator.Utilities;

public static class CostCalculatorUtilities
{
    private const int SmallParcelThreshold = 10;
    private const int MediumParcelThreshold = 50;
    private const int LargeParcelThreshold = 100;

    public static PricedParcel GetDefaultPricedParcel(Parcel parcel)
    {
        if (
            parcel.Length < SmallParcelThreshold
            && parcel.Width < SmallParcelThreshold
            && parcel.Height < SmallParcelThreshold
        )
        {
            return new PricedParcel
            {
                ParcelDetails = parcel,
                Type = ParcelType.Small,
                Cost = 3,
            };
        }
        if (
            parcel.Length < MediumParcelThreshold
            && parcel.Width < MediumParcelThreshold
            && parcel.Height < MediumParcelThreshold
        )
        {
            return new PricedParcel
            {
                ParcelDetails = parcel,
                Type = ParcelType.Medium,
                Cost = 8,
            };
        }
        if (
            parcel.Length < LargeParcelThreshold
            && parcel.Width < LargeParcelThreshold
            && parcel.Height < LargeParcelThreshold
        )
        {
            return new PricedParcel
            {
                ParcelDetails = parcel,
                Type = ParcelType.Large,
                Cost = 15,
            };
        }
        return new PricedParcel
        {
            ParcelDetails = parcel,
            Type = ParcelType.XL,
            Cost = 25,
        };
    }
}
