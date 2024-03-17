namespace Taxmo.Application.Models;

public class DriverModel
{
    public DriverModel() { }

    public int DriverId { get; set; }

    public string Name { get; set; } = null!;

    public string DriverLicense { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<CarRentModel> Carrents { get; } = new List<CarRentModel>();

    public virtual ICollection<OrderModel> Taxiorders { get; } = new List<OrderModel>();

    public virtual ICollection<TimeWorkSheetModel> Timeworksheets { get; } = new List<TimeWorkSheetModel>();
}