namespace Taxmo.Infrastructure.Persistence.Repositories.Queries;
public record CarQuery(
    int[] Ids,
    string[] CarNumPatterns,
    string[] BrandPatterns,
    string[] ModelPatterns,
    string[] Colors,
    DateOnly[] Years,
    int[] CarParkIds,
    int? Cursor,
    int? Limit);
