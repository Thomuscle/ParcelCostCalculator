using ParcelCostCalculator.Enums;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator.Utilities;

public static class CostCalculatorUtilities
{
    private const int SmallParcelDimensionThreshold = 10;
    private const int MediumParcelDimensionThreshold = 50;
    private const int LargeParcelDimensionThreshold = 100;

    private const int SmallParcelCost = 3;
    private const int MediumParcelCost = 8;
    private const int LargeParcelCost = 15;
    private const int XLParcelCost = 25;
    private const int HeavyParcelCost = 50;

    private const int SmallParcelWeightThreshold = 1;
    private const int MediumParcelWeightThreshold = 3;
    private const int LargeParcelWeightThreshold = 6;
    private const int XLParcelWeightThreshold = 10;
    private const int HeavyParcelWeightThreshold = 50;

    private const int PricePerKgOverweight = 2;
    private const int PricePerKgOverweightHeavyParcel = 1;

    public static PricedItem GetPricedParcel(Parcel parcel)
    {
        if (
            parcel.Length < SmallParcelDimensionThreshold
            && parcel.Width < SmallParcelDimensionThreshold
            && parcel.Height < SmallParcelDimensionThreshold
        )
        {
            return new PricedItem
            {
                ParcelDetails = parcel,
                Type = ItemType.SmallParcel,
                Cost = SmallParcelCost,
            };
        }
        if (
            parcel.Length < MediumParcelDimensionThreshold
            && parcel.Width < MediumParcelDimensionThreshold
            && parcel.Height < MediumParcelDimensionThreshold
        )
        {
            return new PricedItem
            {
                ParcelDetails = parcel,
                Type = ItemType.MediumParcel,
                Cost = MediumParcelCost,
            };
        }
        if (
            parcel.Length < LargeParcelDimensionThreshold
            && parcel.Width < LargeParcelDimensionThreshold
            && parcel.Height < LargeParcelDimensionThreshold
        )
        {
            return new PricedItem
            {
                ParcelDetails = parcel,
                Type = ItemType.LargeParcel,
                Cost = LargeParcelCost,
            };
        }
        return new PricedItem
        {
            ParcelDetails = parcel,
            Type = ItemType.XLParcel,
            Cost = XLParcelCost,
        };
    }

    public static void ApplyWeightCost(PricedItem pricedItem)
    {
        // Ensure the parcel details are not null before accessing properties
        if (pricedItem.ParcelDetails == null)
        {
            return;
        }

        // Weight should be rounded up to the nearest kilogram
        var weight = Math.Ceiling(pricedItem.ParcelDetails.Weight);
        var type = pricedItem.Type;

        if (type == ItemType.SmallParcel && weight > SmallParcelWeightThreshold)
        {
            pricedItem.Cost += (weight - SmallParcelWeightThreshold) * PricePerKgOverweight;
        }
        else if (type == ItemType.MediumParcel && weight > MediumParcelWeightThreshold)
        {
            pricedItem.Cost += (weight - MediumParcelWeightThreshold) * PricePerKgOverweight;
        }
        else if (type == ItemType.LargeParcel && weight > LargeParcelWeightThreshold)
        {
            pricedItem.Cost += (weight - LargeParcelWeightThreshold) * PricePerKgOverweight;
        }
        else if (type == ItemType.XLParcel && weight > XLParcelWeightThreshold)
        {
            pricedItem.Cost += (weight - XLParcelWeightThreshold) * PricePerKgOverweight;
        }

        // We can also consider a parcel as a HeavyParcel if this is cheaper
        var heavyParcelCost =
            weight <= HeavyParcelWeightThreshold
                ? HeavyParcelCost
                : HeavyParcelCost
                    + ((weight - HeavyParcelWeightThreshold) * PricePerKgOverweightHeavyParcel);

        if (pricedItem.Cost > heavyParcelCost)
        {
            pricedItem.Type = ItemType.HeavyParcel;
            pricedItem.Cost = heavyParcelCost;
        }
    }

    public static void ApplySpeedyShipping(OrderSummary orderSummary)
    {
        // Speedy shipping equals the total cost of all parcels
        var speedyShippingCost = orderSummary.TotalCost;

        orderSummary.Items.Add(
            new PricedItem
            {
                ParcelDetails = null,
                Type = ItemType.SpeedyShipping,
                Cost = speedyShippingCost,
            }
        );

        orderSummary.TotalCost += speedyShippingCost;
    }
}
