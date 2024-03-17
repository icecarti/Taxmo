namespace Taxmo.Application.Models;

public class OrderModel
{
    public OrderModel() { }

    public string? OrderType { get; set; } // "taxi" or "personal driver service"

    public DateTime? BeginTime { get; set; }

    public TimeOnly? Waiting { get; set; }

    public DateTime? EndTime { get; set; }

    public DriverModel? Driver { get; set; }

    public PassengerModel? Passenger { get; set; }

    public int? Price { get; set; } // Default = 0

    public int? DriverRate { get; set; } // 1-5

    public int? PassengerRate { get; set; } // 1-5
}