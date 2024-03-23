using Microsoft.EntityFrameworkCore;
using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Exceptions;
using Taxmo.Infrastructure.Persistence.Mappers;
using Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories;

public class CarRentRepository : RepositoryBase<Carrent, CarRentModel>, ICarRentRepository
{
    private readonly TaxiDbContext _context;

    public CarRentRepository(TaxiDbContext context) : base(context)
    {
        _context = context;
    }

    public CarRentModel GetRentById(int id)
    {
        Carrent? existing = DbSet.Local.FirstOrDefault(entity => entity.RentId == id);
        return existing is not null
            ? CarRentMapper.MapFrom(existing)
            : throw new NoSuchRentException("No rent with these id");
    }

    public async void AddAsync(CarRentModel carrent)
    {
        await Add(carrent);
    }

    public async void UpdateAsync(CarRentModel carrent)
    {
        await Update(carrent);
    }

    public async void CloseAsync(CarRentModel carrent)
    {
        await Remove(carrent);
    }

    public IAsyncEnumerable<CarRentModel> QueryAsync(CarRentQuery query)
    {
        var queryable = BuildQuery(_context.Carrents, query);
        return queryable.ToAsyncEnumerable().Select(entity => CarRentMapper.MapFrom(entity));
    }

    public IQueryable<Carrent> BuildQuery(IQueryable<Carrent> rentQueryable, CarRentQuery query)
    {
        if (query.Ids is not [])
        {
            rentQueryable = rentQueryable.Where(rent => query.Ids.Contains(rent.RentId));
        }

        if (query.MaxPrice is not null)
        {
            rentQueryable = rentQueryable.Where(rent => rent.DailyPrice <= query.MaxPrice);
        }

        if (query.MinPrice is not null)
        {
            rentQueryable = rentQueryable.Where(rent => rent.DailyPrice >= query.MinPrice);
        }

        if (query.StartDates is not [])
        {
            rentQueryable = rentQueryable.Where(rent => query.StartDates.Contains(rent.StartDate));
        }

        if (query.Cursor is not null)
        {
            rentQueryable = rentQueryable.Where(rent => rent.RentId > query.Cursor);
        }

        if (query.Limit is not null)
        {
            rentQueryable = rentQueryable.Take(query.Limit.Value);
        }

        return rentQueryable;
    }

    protected override DbSet<Carrent> DbSet => _context.Carrents;

    protected override Carrent MapTo(CarRentModel model)
    {
        return CarRentMapper.MapTo(model);
    }

    protected override bool Equal(Carrent entity, CarRentModel model)
    {
        return entity.RentId.Equals(model.RentId);
    }

    protected override void UpdateModel(Carrent entity, CarRentModel model)
    {
    }
}