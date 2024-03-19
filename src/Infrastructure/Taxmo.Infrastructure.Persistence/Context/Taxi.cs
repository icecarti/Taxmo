namespace Taxmo.Infrastructure.Persistence.Context;

public partial class Taxi
{
    public string Ie { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly? RegistrationDate { get; set; }

    public virtual ICollection<Carpark> Carparks { get; init; } = new List<Carpark>();

    public virtual ICollection<Timeworksheet> Timeworksheets { get; init; } = new List<Timeworksheet>();
}
