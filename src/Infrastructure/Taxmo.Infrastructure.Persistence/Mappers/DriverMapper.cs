using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;

namespace Taxmo.Infrastructure.Persistence.Mappers;

public class DriverMapper
{
    public static Driver MapTo(DriverModel model)
    {
        var taxiorders = model
            .Taxiorders
            .Select(TaxiorderMapper.MapTo);
        var carrents = model
            .Carrents
            .Select(CarRentMapper.MapTo);
        var timeworksheets = model
            .Timeworksheets
            .Select(TimeWorkSheetMapper.MapTo);
        return new Driver
        {
            Name = model.Name,
            Email = model.Email,
            DriverId = model.DriverId,
            DriverLicense = model.DriverLicense,
            Passport = model.Passport,
            Phone = model.Phone,
            Carrents = (ICollection<Carrent>)carrents,
            Timeworksheets = (ICollection<Timeworksheet>)timeworksheets,
            Taxiorders = (ICollection<Taxiorder>)taxiorders,
        };
    }

    public static DriverModel MapFrom(Driver entity)
    {
        var taxiorders = entity
            .Taxiorders
            .Select(TaxiorderMapper.MapFrom);
        var carrents = entity
            .Carrents
            .Select(CarRentMapper.MapFrom);
        var timeworksheets = entity
            .Timeworksheets
            .Select(TimeWorkSheetMapper.MapFrom);
        return new DriverModel
        {
            Name = entity.Name,
            Email = entity.Email,
            DriverId = entity.DriverId,
            DriverLicense = entity.DriverLicense,
            Passport = entity.Passport,
            Phone = entity.Phone,
            Carrents = (ICollection<CarRentModel>)carrents,
            Timeworksheets = (ICollection<TimeWorkSheetModel>)timeworksheets,
            Taxiorders = (ICollection<OrderModel>)taxiorders,
        };
    }
}