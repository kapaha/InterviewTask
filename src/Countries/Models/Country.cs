namespace Countries.Models;

public class Country
{
    public required string Name { get; set; }
    public int Population { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public required string Continent { get; set; }
    public required string Capital { get; set; }
    public int Area { get; set; }
    public required string Currency { get; set; }
    public required string Description { get; set; }
}