namespace Taxmo.Application.Models;
public class TaxiCompanyModel
{
    public TaxiCompanyModel() { }

    public string Ie { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly? RegistrationDate { get; set; }

    public virtual ICollection<CarParkModel> Carparks { get; init; } = new List<CarParkModel>();

    public virtual ICollection<TimeWorkSheetModel> Timeworksheets { get; init; } = new List<TimeWorkSheetModel>();
}
