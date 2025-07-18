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
        Assert.Equal(4, result.Items.Count);
        Assert.Equal(51, result.TotalCost);
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.SmallParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.MediumParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.LargeParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.XLParcel));
    }

    [Fact]
    public void CalculateOrderCost_EmptyList_ReturnsEmptySummary()
    {
        var parcels = new List<IParcel>();

        var result = CostCalculator.CalculateOrderCost(parcels);

        Assert.NotNull(result);
        Assert.Empty(result.Items);
        Assert.Equal(0, result.TotalCost);
    }

    [Fact]
    public void CalculateOrderCost_WithSpeedyShipping_ReturnsCorrectSummary()
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

        var result = CostCalculator.CalculateOrderCost(parcels, true);

        Assert.NotNull(result);
        Assert.Equal(5, result.Items.Count);
        Assert.Equal(102, result.TotalCost);
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.SmallParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.MediumParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.LargeParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.XLParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.SpeedyShipping));
    }
}
