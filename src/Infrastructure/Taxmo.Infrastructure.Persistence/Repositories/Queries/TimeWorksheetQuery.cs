namespace Taxmo.Infrastructure.Persistence.Repositories.Queries;
public record TimeWorksheetQuery(
    int[] Ids,
    DateOnly[] Dates,
    int[] DriverIds,
    int? HourCount,
    string[] TaxiIes,
    int? Cursor,
    int? Limit);
