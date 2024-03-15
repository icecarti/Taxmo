using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxmo.Infrastructure.Persistence.Context;

[Table("carparks")]
public partial class CarPark
{
    [Key]
    public int CarParkId { get; set; }

    public string? Address { get; set; } // Not null

    public string? Postcode { get; set; }

    public int? CarCount { get; set; } // Not null, Default = 0\

    [ForeignKey("taxies")]
    public int CompanyId { get; set; }
}
