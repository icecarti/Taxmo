namespace Taxmo.Infrastructure.Persistence.Repositories.Queries;
public record DriverQuery(
    int[] Ids,
    string[] FullNamePatterns,
    string[] LicensePatterns,
    string[] PassportPatterns,
    int? Cursor,
    int? Limit);
