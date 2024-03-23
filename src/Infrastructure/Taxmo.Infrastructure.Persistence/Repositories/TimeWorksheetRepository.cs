using Microsoft.EntityFrameworkCore;
using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Exceptions;
using Taxmo.Infrastructure.Persistence.Mappers;
using Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories;

public class TimeWorksheetRepository : RepositoryBase<Timeworksheet, TimeWorkSheetModel>, IWorksheetRepository
{
    private readonly TaxiDbContext _context;

    public TimeWorksheetRepository(TaxiDbContext context) : base(context)
    {
        _context = context;
    }

    public TimeWorkSheetModel GetTimeworksheetById(int id)
    {
        Timeworksheet? existing = DbSet.Local.FirstOrDefault(entity => entity.WorksheetId == id);
        return existing is not null
            ? TimeWorkSheetMapper.MapFrom(existing)
            : throw new NoSuchWorkSheetException("No worksheet with these id");
    }

    public async void AddAsync(TimeWorkSheetModel timeworksheet)
    {
        await Add(timeworksheet);
    }

    public async void UpdateAsync(TimeWorkSheetModel timeworksheet)
    {
        await Update(timeworksheet);
    }

    public async void DeleteAsync(TimeWorkSheetModel timeworksheet)
    {
        await Remove(timeworksheet);
    }

    public IAsyncEnumerable<TimeWorkSheetModel> QueryAsync(TimeWorksheetQuery query)
    {
        var queryable = BuildQuery(_context.Timeworksheets, query);
        return queryable.ToAsyncEnumerable().Select(entity => TimeWorkSheetMapper.MapFrom(entity));
    }

    public IQueryable<Timeworksheet> BuildQuery(IQueryable<Timeworksheet> workQueryable, TimeWorksheetQuery query)
    {
        if (query.Ids is not [])
        {
            workQueryable = workQueryable.Where(worksheet => query.Ids.Contains(worksheet.WorksheetId));
        }

        if (query.Dates is not [])
        {
            workQueryable = workQueryable.Where(worksheet => query.Dates.Contains(worksheet.Date));
        }

        if (query.HourCount is not null)
        {
            workQueryable = workQueryable.Where(worksheet => worksheet.HourCount == query.HourCount);
        }

        if (query.TaxiIes is not [])
        {
            workQueryable = workQueryable.Where(worksheet => query.TaxiIes.Contains(worksheet.TaxiIe));
        }

        if (query.Cursor is not null)
        {
            workQueryable = workQueryable.Where(worksheet => worksheet.WorksheetId > query.Cursor);
        }

        if (query.Limit is not null)
        {
            workQueryable = workQueryable.Take(query.Limit.Value);
        }

        return workQueryable;
    }

    protected override DbSet<Timeworksheet> DbSet => _context.Timeworksheets;

    protected override Timeworksheet MapTo(TimeWorkSheetModel model)
    {
        return TimeWorkSheetMapper.MapTo(model);
    }

    protected override bool Equal(Timeworksheet entity, TimeWorkSheetModel model)
    {
        return entity.WorksheetId.Equals(model.WorksheetId);
    }

    protected override void UpdateModel(Timeworksheet entity, TimeWorkSheetModel model)
    {
        model.Date = entity.Date;
        model.HourlySalary = entity.HourlySalary;
        model.HourCount = entity.HourCount;
        model.DriverId = entity.DriverId;
        model.TaxiIe = entity.TaxiIe;
    }
}