namespace Taxmo.Infrastructure.Persistence.Repositories.Queries;
public record OrderQuery(
    int[] Ids,
    int? MaxPrice,
    int? MinPrice,
    string[] TypePatterns,
    int? MaxDriverRate,
    int? MinDriverRate,
    int? MaxPassengerRate,
    int? MinPassengerRate,
    DateOnly[] Dates,
    int[] PassengerIds,
    int[] DriverIds,
    int? Cursor,
    int? Limit);