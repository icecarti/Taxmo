using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;

namespace Taxmo.Infrastructure.Persistence.Mappers;
public static class TaxiorderMapper
{
    public static Taxiorder MapTo(OrderModel model)
    {
        return new Taxiorder
        {
            OrderId = model.OrderId,
            OrderType = model.OrderType,
            Price = model.Price,
            DriverRate = model.DriverRate,
            PassengerRate = model.PassengerRate,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            PassengerId = model.PassengerId,
            DriverId = model.DriverId,
        };
    }

    public static OrderModel MapFrom(Taxiorder entity)
    {
        return new OrderModel
        {
            OrderId = entity.OrderId,
            OrderType = entity.OrderType,
            Price = entity.Price,
            DriverRate = entity.DriverRate,
            PassengerRate = entity.PassengerRate,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            PassengerId = entity.PassengerId,
            DriverId = entity.DriverId,
        };
    }
}
