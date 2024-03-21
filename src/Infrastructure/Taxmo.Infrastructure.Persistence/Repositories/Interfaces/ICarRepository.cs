using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface ICarRepository
{
    IAsyncEnumerable<CarModel> QueryAsync(CarQuery query);

    CarModel GetCarById(int id);

    void AddAsync(CarModel model);

    void UpdateAsync(CarModel model);

    void RemoveAsync(CarModel model);
}
