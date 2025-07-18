using ParcelCostCalculator.Interfaces;
using ParcelCostCalculator.Models;
using ParcelCostCalculator.Utilities;

namespace ParcelCostCalculator;

public class CostCalculator
{
    public static OrderSummary CalculateOrderCost(IEnumerable<IParcel> parcels)
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

        return new OrderSummary
        {
            Parcels = pricedParcelList,
            TotalCost = pricedParcelList.Sum(p => p.Cost),
        };
    }
}
