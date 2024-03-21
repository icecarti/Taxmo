using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;

namespace Taxmo.Infrastructure.Persistence.Mappers;

public class CarRentMapper
{
    public static Carrent MapTo(CarRentModel model)
    {
        return new Carrent
        {
            RentId = model.RentId,
            DailyPrice = model.DailyPrice,
            CarId = model.CarId,
            DriverId = model.DriverId,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
        };
    }

    public static CarRentModel MapFrom(Carrent entity)
    {
        return new CarRentModel
        {
            RentId = entity.RentId,
            DailyPrice = entity.DailyPrice,
            CarId = entity.CarId,
            DriverId = entity.DriverId,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
        };
    }
}