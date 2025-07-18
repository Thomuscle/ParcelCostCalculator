namespace ParcelCostCalculator.Tests;

public class ParcelCostCalculatorTests
{
    [Fact]
    public void Add_ReturnsCorrectSum()
    {
        var result = CostCalculator.Add(2, 3);
        Assert.Equal(5, result);
    }
}