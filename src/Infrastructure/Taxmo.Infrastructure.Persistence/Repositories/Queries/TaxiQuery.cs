namespace Taxmo.Infrastructure.Persistence.Repositories.Queries;
public record TaxiQuery(
    string[] Ies,
    string[] NamePatterns,
    string[] PhonePatterns,
    DateOnly[] RegDates,
    int? Cursor,
    int? Limit);
