using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxmo.Infrastructure.Persistence.Context;

[Table("drivers")]
public partial class Driver
{
    [Key]
    public int DriverId { get; set; }

    public string? Name { get; set; }

    public string? DriverLicense { get; set; } // Unique, Not null

    public string? Passport { get; set; } // Not null, Unique

    public string? Phone { get; set; } // Unique
}
