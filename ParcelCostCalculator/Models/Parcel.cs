using ParcelCostCalculator.Interfaces;

namespace ParcelCostCalculator.Models;

public class Parcel : IParcel
{
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
}
