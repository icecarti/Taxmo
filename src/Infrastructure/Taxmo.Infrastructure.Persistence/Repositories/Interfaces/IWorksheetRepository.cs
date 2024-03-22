using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface IWorksheetRepository
{
    IAsyncEnumerable<TimeWorkSheetModel> QueryAsync(TimeWorksheetQuery query);

    IQueryable<Timeworksheet> BuildQuery(IQueryable<Timeworksheet> workQueryable, TimeWorksheetQuery query);

    void AddAsync(TimeWorkSheetModel timeworksheet);

    void UpdateAsync(TimeWorkSheetModel timeworksheet);

    void DeleteAsync(TimeWorkSheetModel timeworksheet);
}
