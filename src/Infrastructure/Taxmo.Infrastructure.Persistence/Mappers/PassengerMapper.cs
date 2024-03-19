using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;

namespace Taxmo.Infrastructure.Persistence.Mappers;
public static class PassengerMapper
{
    public static Passenger MapTo(PassengerModel model)
    {
        var taxiorders = model.Taxiorders
            .Select(TaxiorderMapper.MapTo);
        return new Passenger { Name = model.Name, Email = model.Email, PassengerId = model.PassengerId, Phone = model.Phone, Taxiorders = (ICollection<Taxiorder>)taxiorders };
    }

    public static PassengerModel MapFrom(Passenger entity)
    {
        var taxiorders = entity.Taxiorders
            .Select(TaxiorderMapper.MapFrom);
        return new PassengerModel { Name = entity.Name, Email = entity.Email, PassengerId = entity.PassengerId, Phone = entity.Phone, Taxiorders = (ICollection<OrderModel>)taxiorders };
    }
}
