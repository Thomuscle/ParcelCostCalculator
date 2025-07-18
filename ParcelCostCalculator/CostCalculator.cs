using ParcelCostCalculator.Interfaces;
using ParcelCostCalculator.Models;
using ParcelCostCalculator.Utilities;

namespace ParcelCostCalculator;

public class CostCalculator
{
    /// <summary>
    /// Calculates the total cost and parcel types for a list of parcels, returning an order summary.
    /// Each parcel is evaluated for its type and cost based on its dimensions.
    /// Parcel dimensions should be specified in centimeters (cm).
    /// </summary>
    public static OrderSummary CalculateOrderCost(
        IEnumerable<IParcel> parcels,
        bool useSpeedyShipping = false
    )
    {
        var pricedParcelList = parcels
            .Select(parcel =>
            {
                var pricedParcel = CostCalculatorUtilities.GetDefaultPricedParcel((Parcel)parcel);
                return new PricedParcel
                {
                    ParcelDetails = (Parcel)parcel,
                    Type = pricedParcel.Type,
                    Cost = pricedParcel.Cost,
                };
            })
            .ToList();

        var totalCost = pricedParcelList.Sum(p => p.Cost);

        if (useSpeedyShipping)
        {
            totalCost = CostCalculatorUtilities.ApplySpeedyShipping(pricedParcelList, totalCost);
        }

        var orderSummary = new OrderSummary { Parcels = pricedParcelList, TotalCost = totalCost };

        return orderSummary;
    }
}
