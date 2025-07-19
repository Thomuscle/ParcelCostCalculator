using ParcelCostCalculator.Enums;
using ParcelCostCalculator.Interfaces;
using ParcelCostCalculator.Models;

namespace ParcelCostCalculator.Tests;

public class ParcelCostCalculatorTests
{
    [Fact]
    public void CalculateOrderCost_NoOverweightParcels_ReturnsCorrectSummary()
    {
        var parcels = new List<IParcel>
        {
            new Parcel
            {
                Length = 5,
                Width = 5,
                Height = 5,
                Weight = 0.5m,
            },
            new Parcel
            {
                Length = 15,
                Width = 15,
                Height = 5,
                Weight = 2,
            },
            new Parcel
            {
                Length = 75,
                Width = 30,
                Height = 60,
                Weight = 4.5m,
            },
            new Parcel
            {
                Length = 120,
                Width = 40,
                Height = 10,
                Weight = 10,
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
        Assert.Equal(0, result.Items.Count(p => p.Type == ItemType.SpeedyShipping));
    }

    [Fact]
    public void CalculateOrderCost_OverweightParcels_ReturnsCorrectSummary()
    {
        var parcels = new List<IParcel>
        {
            new Parcel
            {
                Length = 5,
                Width = 5,
                Height = 5,
                Weight = 3.5m, // Total cost for this parcel will be 3 + 6 = 9
            },
            new Parcel
            {
                Length = 15,
                Width = 15,
                Height = 5,
                Weight = 6, // Total cost for this parcel will be 8 + 6 = 14
            },
            new Parcel
            {
                Length = 75,
                Width = 30,
                Height = 60,
                Weight = 6.01m, // Total cost for this parcel will be 15 + 2 = 17
            },
            new Parcel
            {
                Length = 120,
                Width = 40,
                Height = 10,
                Weight = 15.99m, // Total cost for this parcel will be 25 + 12 = 37
            },
        };

        var result = CostCalculator.CalculateOrderCost(parcels);

        Assert.NotNull(result);
        Assert.Equal(4, result.Items.Count);
        Assert.Equal(77, result.TotalCost); // Total cost is 9 + 14 + 17 + 37 = 77
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.SmallParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.MediumParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.LargeParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.XLParcel));
        Assert.Equal(0, result.Items.Count(p => p.Type == ItemType.SpeedyShipping));
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
    public void CalculateOrderCost_WithSpeedyShipping_NoOverweightParcels_ReturnsCorrectSummary()
    {
        var parcels = new List<IParcel>
        {
            new Parcel
            {
                Length = 5,
                Width = 5,
                Height = 5,
                Weight = 0.5m,
            },
            new Parcel
            {
                Length = 15,
                Width = 15,
                Height = 5,
                Weight = 2,
            },
            new Parcel
            {
                Length = 75,
                Width = 30,
                Height = 60,
                Weight = 4.5m,
            },
            new Parcel
            {
                Length = 120,
                Width = 40,
                Height = 10,
                Weight = 10,
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

        [Fact]
    public void CalculateOrderCost_WithSpeedyShipping_OverweightParcels_ReturnsCorrectSummary()
    {
        var parcels = new List<IParcel>
        {
            new Parcel
            {
                Length = 5,
                Width = 5,
                Height = 5,
                Weight = 3.5m, // Total cost for this parcel will be 3 + 6 = 9
            },
            new Parcel
            {
                Length = 15,
                Width = 15,
                Height = 5,
                Weight = 6, // Total cost for this parcel will be 8 + 6 = 14
            },
            new Parcel
            {
                Length = 75,
                Width = 30,
                Height = 60,
                Weight = 6.01m, // Total cost for this parcel will be 15 + 2 = 17
            },
            new Parcel
            {
                Length = 120,
                Width = 40,
                Height = 10,
                Weight = 15.99m, // Total cost for this parcel will be 25 + 12 = 37
            },
        };

        var result = CostCalculator.CalculateOrderCost(parcels, true);

        Assert.NotNull(result);
        Assert.Equal(5, result.Items.Count);
        Assert.Equal(154, result.TotalCost); // Total cost is (9 + 14 + 17 + 37) * 2 = 77 * 2 = 154
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.SmallParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.MediumParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.LargeParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.XLParcel));
        Assert.Equal(1, result.Items.Count(p => p.Type == ItemType.SpeedyShipping));
    }
}
