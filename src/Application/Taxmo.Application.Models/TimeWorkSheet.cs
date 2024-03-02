namespace Taxmo.Application.Models;

public class TimeWorksheet
{
    public TaxiCompany Taxi { get; set; }
    public Driver Driver { get; set; }
    public DateTime Date { get; set; } // Not null
    public int HourlySalary { get; set; } // Default = 0
    public int Hours { get; set; } // Default = 0
}