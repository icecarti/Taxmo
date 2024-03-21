using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface IPassengerRepository
{
    IAsyncEnumerable<PassengerModel> QueryAsync(PassengerQuery query);

    PassengerModel GetPassengerById(int id);

    void AddAsync(PassengerModel passenger);

    void UpdateAsync(PassengerModel passenger);
}
