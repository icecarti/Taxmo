namespace Taxmo.Application.Models;

public class Passenger
{
    public string Name { get; set; }
    public string Phone { get; set; } // Unique, Not null
    public string Email { get; set; } // Unique
}