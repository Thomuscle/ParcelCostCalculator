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
                Type = ItemType.SmallParcel,
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
                Type = ItemType.MediumParcel,
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
                Type = ItemType.LargeParcel,
                Cost = 15,
            };
        }
        return new PricedParcel
        {
            ParcelDetails = parcel,
            Type = ItemType.XLParcel,
            Cost = 25,
        };
    }

    public static void ApplySpeedyShipping(OrderSummary orderSummary)
    {
        // Speedy shipping equals the total cost of all parcels
        var speedyShippingCost = orderSummary.TotalCost;

        orderSummary.Parcels.Add(
            new PricedParcel
            {
                ParcelDetails = null,
                Type = ItemType.SpeedyShipping,
                Cost = speedyShippingCost,
            }
        );

        orderSummary.TotalCost += speedyShippingCost;
    }
}
