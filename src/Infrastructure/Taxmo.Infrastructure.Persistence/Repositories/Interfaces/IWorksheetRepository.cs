using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface IWorksheetRepository
{
    IAsyncEnumerable<TimeWorkSheetModel> QueryAsync(TimeWorksheetQuery query);

    void AddAsync(TimeWorkSheetModel model);

    void UpdateAsync(TimeWorkSheetModel model);

    void DeleteAsync(TimeWorkSheetModel model);
}
