using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface IOrderRepository
{
    IAsyncEnumerable<OrderModel> QueryAsync(OrderQuery query);

    IQueryable<Taxiorder> BuildQuery(IQueryable<Taxiorder> orderQueryable, OrderQuery query);

    OrderModel GetOrderById(int id);

    void AddAsync(OrderModel order);

    void UpdateAsync(OrderModel order);

    void RemoveAsync(OrderModel order);
}
