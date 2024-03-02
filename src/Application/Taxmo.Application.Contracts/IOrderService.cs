using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IOrderService
{
    Order CreateOrder(Passenger passenger, Driver driver, DateTime beginTime, DateTime endTime, TimeOnly waiting, int price, int driverRate, int passengerRate);

    void CancelOrder(Order order);

    void FinishOrder(Order order);

    void GetOrderInfo(Order order);
}
