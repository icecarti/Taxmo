using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxmo.Infrastructure.Persistence.Context;

[Table("timeworksheets")]
public partial class TimeWorkSheet
{
    [Key]
    public int TimeWorksheetId { get; set; }

    [ForeignKey("taxies")]
    public int TaxiCompanyId { get; set; }

    [ForeignKey("drivers")]
    public int DriverId { get; set; }

    public DateTime? Date { get; set; } // Not null

    public int? HourlySalary { get; set; } // Default = 0

    public int? Hours { get; set; } // Default = 0
}
