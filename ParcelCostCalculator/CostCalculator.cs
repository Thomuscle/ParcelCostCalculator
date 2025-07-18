using ParcelCostCalculator.Interfaces;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator;

public class CostCalculator
{
    public static OrderSummary CalculateOrderCost(IEnumerable<IParcel> parcels)
    {
        var pricedParcelList = parcels
            .Select(parcel => new PricedParcel
            {
                ParcelDetails = (Parcel)parcel,
                Type = Enums.ParcelType.Small, // Placeholder for actual type determination logic
                Cost = 10, // Placeholder for actual cost calculation logic
            })
            .ToList();

        return new OrderSummary
        {
            Parcels = pricedParcelList,
            TotalCost = pricedParcelList.Sum(p => p.Cost),
        };
    }
}
