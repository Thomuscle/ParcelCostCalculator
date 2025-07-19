namespace ParcelCostCalculator.Interfaces;

public interface IParcel
{
    decimal Length { get; }
    decimal Width { get; }
    decimal Height { get; }
    decimal Weight { get; }
}
