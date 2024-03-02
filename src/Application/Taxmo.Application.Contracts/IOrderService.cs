using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IOrderService
{
    void CreateOrder(Order newOrder);

    void CancelOrder(Order order);

    void FinishOrder(Order order);

    void GetOrderInfo(Order order);
}
