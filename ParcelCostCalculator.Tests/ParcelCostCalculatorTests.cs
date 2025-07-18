using ParcelCostCalculator.Enums;
using ParcelCostCalculator.Interfaces;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator.Tests;

public class ParcelCostCalculatorTests
{
    [Fact]
    public void CalculateOrderCost_ReturnsCorrectSummary()
    {
        var parcels = new List<IParcel>
        {
            new Parcel
            {
                Length = 5,
                Width = 5,
                Height = 5,
            },
            new Parcel
            {
                Length = 15,
                Width = 15,
                Height = 5,
            },
            new Parcel
            {
                Length = 75,
                Width = 30,
                Height = 60,
            },
            new Parcel
            {
                Length = 120,
                Width = 40,
                Height = 10,
            },
        };

        var result = CostCalculator.CalculateOrderCost(parcels);

        Assert.NotNull(result);
        Assert.Equal(4, result.Parcels.Count);
        Assert.Equal(51, result.TotalCost);
        Assert.Equal(1, result.Parcels.Count(p => p.Type == ParcelType.Small));
        Assert.Equal(1, result.Parcels.Count(p => p.Type == ParcelType.Medium));
        Assert.Equal(1, result.Parcels.Count(p => p.Type == ParcelType.Large));
        Assert.Equal(1, result.Parcels.Count(p => p.Type == ParcelType.XL));
    }

    [Fact]
    public void CalculateOrderCost_EmptyList_ReturnsEmptySummary()
    {
        var parcels = new List<IParcel>();

        var result = CostCalculator.CalculateOrderCost(parcels);

        Assert.NotNull(result);
        Assert.Empty(result.Parcels);
        Assert.Equal(0, result.TotalCost);
    }
}
