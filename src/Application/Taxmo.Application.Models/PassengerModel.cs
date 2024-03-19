namespace Taxmo.Application.Models;
public class PassengerModel
{
    public PassengerModel() { }

    public int PassengerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<OrderModel> Taxiorders { get; init; } = new List<OrderModel>();
}