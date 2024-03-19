namespace Taxmo.Infrastructure.Persistence.Context;

public partial class Taxiorder
{
    public int? OrderId { get; set; }

    public string? OrderType { get; set; } = null!;

    public int? Price { get; set; }

    public int? DriverRate { get; set; }

    public int? PassengerRate { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? PassengerId { get; set; }

    public int? DriverId { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Passenger? Passenger { get; set; }
}
