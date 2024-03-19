namespace Taxmo.Application.Models;

public class CarParkModel
{
    public CarParkModel() { }

    public int CarparkId { get; set; }

    public string? Address { get; set; }

    public string Postcode { get; set; } = null!;

    public string CarCount { get; set; } = null!;

    public string? Ie { get; set; }

    public virtual ICollection<CarModel> Cars { get; init; } = new List<CarModel>();

    public virtual TaxiCompanyModel? TaxiCompany { get; set; }
}