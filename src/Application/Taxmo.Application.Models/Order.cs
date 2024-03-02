namespace Taxmo.Application.Models;

public class Order
{
    public string OrderType { get; set; } // "taxi" or "personal driver service"
    public DateTime? BeginTime { get; set; }
    public TimeOnly? Waiting { get; set; }
    public DateTime? EndTime { get; set; }
    public Driver Driver { get; set; }
    public Passenger Passenger { get; set; }
    public int Price { get; set; } // Default = 0
    public int DriverRate { get; set; } // 1-5
    public int PassengerRate { get; set; } // 1-5
}