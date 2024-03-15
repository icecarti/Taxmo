using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxmo.Infrastructure.Persistence.Context;

[Table("taxiorders")]
public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    public string? OrderType { get; set; } // "taxi" or "personal driver service"

    public DateTime? BeginTime { get; set; }

    public TimeOnly? Waiting { get; set; }

    public DateTime? EndTime { get; set; }

    [ForeignKey("drivers")]
    public int DriverId { get; set; }

    [ForeignKey("passengers")]
    public int PassengerId { get; set; }

    public int? Price { get; set; } // Default = 0

    public int? DriverRate { get; set; } // 1-5

    public int? PassengerRate { get; set; } // 1-5
}
