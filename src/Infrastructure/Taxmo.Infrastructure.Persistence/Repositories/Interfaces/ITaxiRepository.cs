using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface ITaxiRepository
{
    IAsyncEnumerable<TaxiCompanyModel> QueryAsync(TaxiQuery query);

    IQueryable<Taxi> BuildQuery(IQueryable<Taxi> taxiQueryable, TaxiQuery query);
}
