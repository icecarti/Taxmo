namespace Taxmo.Infrastructure.Persistence.Context;

public partial class Car
{
    public int CarId { get; set; }

    public string? CarNumber { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public DateOnly? Year { get; set; }

    public string? Color { get; set; }

    public int? CarparkId { get; set; }

    public virtual Carpark? Carpark { get; set; }

    public virtual ICollection<Carrent> Carrents { get; init; } = new List<Carrent>();
}
