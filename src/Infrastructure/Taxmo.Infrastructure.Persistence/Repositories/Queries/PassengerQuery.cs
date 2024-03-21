namespace Taxmo.Infrastructure.Persistence.Repositories.Queries;
public record PassengerQuery(
    int[] Ids,
    string[] FullNamePatterns,
    int? Cursor,
    int? Limit);
