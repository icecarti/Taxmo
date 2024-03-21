using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface ICarParkRepository
{
    IAsyncEnumerable<CarParkModel> QueryAsync(CarParkQuery query);
}
