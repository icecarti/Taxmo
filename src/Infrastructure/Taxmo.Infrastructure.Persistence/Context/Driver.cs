namespace Taxmo.Infrastructure.Persistence.Context;

public partial class Driver
{
    public int DriverId { get; set; }

    public string Name { get; set; } = null!;

    public string DriverLicense { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Carrent> Carrents { get; init; } = new List<Carrent>();

    public virtual ICollection<Taxiorder> Taxiorders { get; init; } = new List<Taxiorder>();

    public virtual ICollection<Timeworksheet> Timeworksheets { get; init; } = new List<Timeworksheet>();
}
