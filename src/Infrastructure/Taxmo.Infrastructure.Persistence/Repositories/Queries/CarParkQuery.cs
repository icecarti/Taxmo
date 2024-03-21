namespace Taxmo.Infrastructure.Persistence.Repositories.Queries;
public record CarParkQuery(
    int[] Ids,
    string[] AddressPatterns,
    string[] PostCodePatterns,
    string[] Ies,
    int? Cursor,
    int? Limit);
