using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface ICarRepository
{
    IAsyncEnumerable<CarModel> QueryAsync(CarQuery query);

    IQueryable<Car> BuildQuery(IQueryable<Car> carQueryable, CarQuery query);

    CarModel GetCarById(int id);

    void AddAsync(CarModel car);

    void UpdateAsync(CarModel car);

    void RemoveAsync(CarModel car);
}
