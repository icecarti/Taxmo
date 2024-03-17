namespace Taxmo.Infrastructure.Persistence.Context;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Taxiorder> Taxiorders { get; } = new List<Taxiorder>();
}
