namespace Taxmo.Application.Models;

public class Driver
{
    public string Name { get; set; }
    public string DriverLicense { get; set; } // Unique, Not null
    public string Passport { get; set; } // Not null, Unique
    public string Phone { get; set; } // Unique
    public string Email { get; set; } // Unique
}