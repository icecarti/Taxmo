using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxmo.Infrastructure.Persistence.Context;

[Table("cars")]
public partial class Car
{
    [Key]
    public int CarId { get; set; }

    public string? CarNumber { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public DateTime? Year { get; set; }

    [ForeignKey("carparks")]
    public int CarParkId { get; set; }

    public Driver? Owner { get; set; }
}
