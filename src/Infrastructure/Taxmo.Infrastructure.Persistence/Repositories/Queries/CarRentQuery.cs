namespace Taxmo.Infrastructure.Persistence.Repositories.Queries;
public record CarRentQuery(
    int[] Ids,
    int? MaxPrice,
    int? MinPrice,
    DateOnly[] StartDates,
    DateTime[] EndDates,
    int[] CarIds,
    int[] DriverIds,
    int? Cursor,
    int? Limit);
