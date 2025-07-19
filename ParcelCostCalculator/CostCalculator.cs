using ParcelCostCalculator.Interfaces;
using ParcelCostCalculator.Models;
using ParcelCostCalculator.Utilities;

namespace ParcelCostCalculator;

public class CostCalculator
{
    /// <summary>
    /// Calculates the total cost and items for a list of parcels, returning an order summary.
    /// Each parcel is evaluated for its type and cost based on its dimensions and weight.
    /// Parcel dimensions should be specified in centimeters (cm), and weight in kilograms (kg).
    /// If `useSpeedyShipping` is true, a speedy shipping item is added to the items in the order summary.
    /// Speedy shipping doubles the cost of the order.
    /// </summary>
    public static OrderSummary CalculateOrderCost(
        IEnumerable<IParcel> parcels,
        bool useSpeedyShipping = false
    )
    {
        var pricedParcelList = parcels
            .Select(parcel =>
            {
                var pricedParcel = CostCalculatorUtilities.GetPricedParcel((Parcel)parcel);

                CostCalculatorUtilities.ApplyWeightCost(pricedParcel);

                return new PricedItem
                {
                    ParcelDetails = (Parcel)parcel,
                    Type = pricedParcel.Type,
                    Cost = pricedParcel.Cost,
                };
            })
            .ToList();

        var totalCost = pricedParcelList.Sum(p => p.Cost);

        var orderSummary = new OrderSummary { Items = pricedParcelList, TotalCost = totalCost };

        if (useSpeedyShipping)
        {
            CostCalculatorUtilities.ApplySpeedyShipping(orderSummary);
        }

        return orderSummary;
    }
}
