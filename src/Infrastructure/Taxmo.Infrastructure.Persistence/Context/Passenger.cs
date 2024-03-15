using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxmo.Infrastructure.Persistence.Context;
[Table("passengers")]
public partial class Passenger
{
    [Key]
    public int PassengerId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; } // Unique, Not null

    public string? Email { get; set; } // Unique
}
