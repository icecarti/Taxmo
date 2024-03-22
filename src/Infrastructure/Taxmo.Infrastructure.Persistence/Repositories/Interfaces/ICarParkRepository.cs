using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface ICarParkRepository
{
    IAsyncEnumerable<CarParkModel> QueryAsync(CarParkQuery query);

    IQueryable<Carpark> BuildQuery(IQueryable<Carpark> parkQueryable, CarParkQuery query);
}
