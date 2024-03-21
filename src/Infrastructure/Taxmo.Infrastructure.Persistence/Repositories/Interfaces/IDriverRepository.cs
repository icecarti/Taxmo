using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface IDriverRepository
{
    IAsyncEnumerable<DriverModel> QueryAsync(DriverQuery query);

    DriverModel GetDriverById(int id);

    void AddAsync(DriverModel model);

    void UpdateAsync(DriverModel model);
}
