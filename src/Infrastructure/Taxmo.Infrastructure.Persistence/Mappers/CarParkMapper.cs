using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;

namespace Taxmo.Infrastructure.Persistence.Mappers;

public class CarParkMapper
{
    public static Carpark MapTo(CarParkModel model)
    {
        var cars = model
            .Cars
            .Select(CarMapper.MapTo);
        return new Carpark
        {
            CarparkId = model.CarparkId,
            Address = model.Address,
            Postcode = model.Postcode,
            CarCount = model.CarCount,
            Ie = model.Ie,
            Cars = (ICollection<Car>)cars,
        };
    }

    public static CarParkModel MapFrom(Carpark entity)
    {
        var cars = entity
            .Cars
            .Select(CarMapper.MapFrom);
        return new CarParkModel
        {
            CarparkId = entity.CarparkId,
            Address = entity.Address,
            Postcode = entity.Postcode,
            CarCount = entity.CarCount,
            Ie = entity.Ie,
            Cars = (ICollection<CarModel>)cars,
        };
    }
}