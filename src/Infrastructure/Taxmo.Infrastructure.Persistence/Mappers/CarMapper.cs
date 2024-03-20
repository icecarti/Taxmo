using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;

namespace Taxmo.Infrastructure.Persistence.Mappers;

public class CarMapper
{
    public static Car MapTo(CarModel model)
    {
        var carrents = model
            .Carrents
            .Select(CarRentMapper.MapTo);
        return new Car
        {
            CarId = model.CarId,
            CarNumber = model.CarNumber,
            Brand = model.Brand,
            Model = model.Model,
            Year = model.Year,
            Color = model.Color,
            CarparkId = model.CarparkId,
            Carrents = (ICollection<Carrent>)carrents,
        };
    }

    public static CarModel MapFrom(Car entity)
    {
        var carrents = entity
            .Carrents
            .Select(CarRentMapper.MapFrom);
        return new CarModel
        {
            CarId = entity.CarId,
            CarNumber = entity.CarNumber,
            Brand = entity.Brand,
            Model = entity.Model,
            Year = entity.Year,
            Color = entity.Color,
            CarparkId = entity.CarparkId,
            Carrents = (ICollection<CarRentModel>)carrents,
        };
    }
}