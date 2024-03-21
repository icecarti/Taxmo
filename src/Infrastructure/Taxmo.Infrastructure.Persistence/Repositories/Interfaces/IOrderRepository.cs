using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
public interface IOrderRepository
{
    IAsyncEnumerable<OrderModel> QueryAsync(OrderQuery query);

    OrderModel GetOrderById(int id);

    void AddAsync(OrderModel model);

    void UpdateAsync(OrderModel model);

    void RemoveAsync(OrderModel model);
}
