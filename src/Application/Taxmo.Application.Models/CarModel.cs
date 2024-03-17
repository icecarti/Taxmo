namespace Taxmo.Application.Models;
public class CarModel
{
    public CarModel() { }

    public int CarId { get; set; }

    public string? CarNumber { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public DateOnly? Year { get; set; }

    public string? Color { get; set; }

    public int? CarparkId { get; set; }

    public virtual CarParkModel? CarPark { get; set; }

    public virtual ICollection<CarRentModel> Carrents { get; } = new List<CarRentModel>();
}