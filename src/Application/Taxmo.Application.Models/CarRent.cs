namespace Taxmo.Application.Models;

public class CarRent
{
    public CarRent() { }

    public Car? Car { get; set; }

    public DateTime? StartDate { get; set; } // Not null

    public DateTime? EndDate { get; set; }

    public int? DailyPrice { get; set; } // Not null, Default = 0

    public Driver? Driver { get; set; }
}