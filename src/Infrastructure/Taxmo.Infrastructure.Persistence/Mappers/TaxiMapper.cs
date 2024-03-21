using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;

namespace Taxmo.Infrastructure.Persistence.Mappers;

public class TaxiMapper
{
    public static Taxi MapTo(TaxiCompanyModel model)
    {
        var carparks = model
            .Carparks
            .Select(CarParkMapper.MapTo);
        var timeworksheets = model
            .Timeworksheets
            .Select(TimeWorkSheetMapper.MapTo);
        return new Taxi
        {
            Name = model.Name,
            RegistrationDate = model.RegistrationDate,
            Phone = model.Phone,
            Ie = model.Ie,
            Timeworksheets = (ICollection<Timeworksheet>)timeworksheets,
            Carparks = (ICollection<Carpark>)carparks,
        };
    }

    public static TaxiCompanyModel MapFrom(Taxi entity)
    {
        var carparks = entity
            .Carparks
            .Select(CarParkMapper.MapFrom);
        var timeworksheets = entity
            .Timeworksheets
            .Select(TimeWorkSheetMapper.MapFrom);
        return new TaxiCompanyModel
        {
            Name = entity.Name,
            RegistrationDate = entity.RegistrationDate,
            Phone = entity.Phone,
            Ie = entity.Ie,
            Timeworksheets = (ICollection<TimeWorkSheetModel>)timeworksheets,
            Carparks = (ICollection<CarParkModel>)carparks,
        };
    }
}