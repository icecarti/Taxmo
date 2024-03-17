namespace Taxmo.Application.Models;

public class TimeWorkSheetModel
{
    public TimeWorkSheetModel() { }

    public int WorksheetId { get; set; }

    public DateOnly Date { get; set; }

    public int? HourlySalary { get; set; }

    public int? HourCount { get; set; }

    public int? DriverId { get; set; }

    public string? TaxiIe { get; set; }

    public virtual DriverModel? Driver { get; set; }

    public virtual TaxiCompanyModel? TaxiCompany { get; set; }
}