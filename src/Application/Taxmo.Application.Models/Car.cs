namespace Taxmo.Application.Models;

public class Car
{
    public Car() { }

    public string? CarNumber { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public DateTime? Year { get; set; }

    public CarPark? CarPark { get; set; }

    public Driver? Owner { get; set; }
}