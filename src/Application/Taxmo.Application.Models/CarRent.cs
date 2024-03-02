namespace Taxmo.Application.Models;

public class CarRent
{
    private Driver Driver { get; set; }
    public Car Car { get; set; }
    public DateTime StartDate { get; set; } // Not null
    public DateTime? EndDate { get; set; }
    public int DailyPrice { get; set; } // Not null, Default = 0
}