using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IOrderService
{
    OrderModel CreateOrder(PassengerModel passenger, DriverModel driver, DateTime beginTime, DateTime endTime, TimeOnly waiting, int price, int driverRate, int passengerRate);

    void CancelOrder(OrderModel order);

    void FinishOrder(OrderModel order);

    void GetOrderInfo(OrderModel order);
}
