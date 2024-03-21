using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface ICarRentRepository
{
    IAsyncEnumerable<CarRentModel> QueryAsync(CarRentQuery query);

    void AddAsync(CarRentModel model);

    void UpdateAsync(CarRentModel model);

    void CloseAsync(CarRentModel model);
}
