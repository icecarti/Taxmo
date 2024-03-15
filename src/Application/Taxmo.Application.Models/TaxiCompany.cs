namespace Taxmo.Application.Models;
public class TaxiCompany
{
    public TaxiCompany() { }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public string? Owner { get; set; }

    public DateOnly? RegistrationDate { get; set; }
}
