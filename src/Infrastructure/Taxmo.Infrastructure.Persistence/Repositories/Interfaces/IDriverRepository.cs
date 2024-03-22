using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface IDriverRepository
{
    IAsyncEnumerable<DriverModel> QueryAsync(DriverQuery query);

    IQueryable<Driver> BuildQuery(IQueryable<Driver> driverQueryable, DriverQuery query);

    DriverModel GetDriverById(int id);

    void AddAsync(DriverModel driver);

    void UpdateAsync(DriverModel driver);
}
