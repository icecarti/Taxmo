﻿namespace Taxmo.Infrastructure.Persistence.Context;

public partial class Timeworksheet
{
    public int WorksheetId { get; set; }

    public DateOnly Date { get; set; }

    public int? HourlySalary { get; set; }

    public int? HourCount { get; set; }

    public int? DriverId { get; set; }

    public string? TaxiIe { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Taxi? TaxiIeNavigation { get; set; }
}
