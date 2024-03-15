using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxmo.Infrastructure.Persistence.Context;

[Table("taxies")]
public partial class TaxiCompany
{
    [Key]
    public int TaxiCompanyId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public string? Owner { get; set; }

    public DateOnly? RegistrationDate { get; set; }
}
