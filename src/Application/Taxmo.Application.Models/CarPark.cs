namespace Taxmo.Application.Models;

public class CarPark
{
    public string Address { get; set; } // Not null
    public string Postcode { get; set; }
    public int CarCount { get; set; } // Not null, Default = 0\
    public TaxiCompany Company { get; set; }
}