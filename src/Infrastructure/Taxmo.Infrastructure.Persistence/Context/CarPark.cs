namespace Taxmo.Infrastructure.Persistence.Context;

public partial class Carpark
{
    public int CarparkId { get; set; }

    public string? Address { get; set; }

    public string Postcode { get; set; } = null!;

    public string CarCount { get; set; } = null!;

    public string? Ie { get; set; }

    public virtual ICollection<Car> Cars { get; } = new List<Car>();

    public virtual Taxi? Taxi { get; set; }
}
