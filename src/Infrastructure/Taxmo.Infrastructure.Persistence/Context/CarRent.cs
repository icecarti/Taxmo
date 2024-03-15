using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxmo.Infrastructure.Persistence.Context;

[Table("carrents")]
public partial class CarRent
{
    [Key]
    public int CarRentId { get; set; }

    [ForeignKey("cars")]
    public int CarId { get; set; }

    public DateTime? StartDate { get; set; } // Not null

    public DateTime? EndDate { get; set; }

    public int? DailyPrice { get; set; } // Not null, Default = 0

    [ForeignKey("drivers")]
    public int DriverId { get; set; }
}
