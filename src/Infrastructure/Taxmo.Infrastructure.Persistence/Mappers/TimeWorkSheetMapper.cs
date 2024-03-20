using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;

namespace Taxmo.Infrastructure.Persistence.Mappers;

public class TimeWorkSheetMapper
{
    public static Timeworksheet MapTo(TimeWorkSheetModel model)
    {
        return new Timeworksheet
        {
            WorksheetId = model.WorksheetId,
            Date = model.Date,
            HourlySalary = model.HourlySalary,
            HourCount = model.HourCount,
            TaxiIe = model.TaxiIe,
            DriverId = model.DriverId,
        };
    }

    public static TimeWorkSheetModel MapFrom(Timeworksheet entity)
    {
        return new TimeWorkSheetModel
        {
            WorksheetId = entity.WorksheetId,
            Date = entity.Date,
            HourlySalary = entity.HourlySalary,
            HourCount = entity.HourCount,
            TaxiIe = entity.TaxiIe,
            DriverId = entity.DriverId,
        };
    }
}