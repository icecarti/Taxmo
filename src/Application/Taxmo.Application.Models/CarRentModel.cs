namespace Taxmo.Application.Models;

public class CarRentModel
{
    public CarRentModel() { }

    public int RentId { get; set; }

    public int? DailyPrice { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? CarId { get; set; }

    public int? DriverId { get; set; }

    public virtual CarModel? Car { get; set; }

    public virtual DriverModel? Driver { get; set; }
}