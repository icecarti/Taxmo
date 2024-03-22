using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface ICarRentRepository
{
    IAsyncEnumerable<CarRentModel> QueryAsync(CarRentQuery query);

    IQueryable<Carrent> BuildQuery(IQueryable<Carrent> rentQueryable, CarRentQuery query);

    void AddAsync(CarRentModel carrent);

    void UpdateAsync(CarRentModel carrent);

    void CloseAsync(CarRentModel carrent);
}
