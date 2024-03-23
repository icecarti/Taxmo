using Microsoft.EntityFrameworkCore;
using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Exceptions;
using Taxmo.Infrastructure.Persistence.Mappers;
using Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories;

public class CarParkRepository : RepositoryBase<Carpark, CarParkModel>, ICarParkRepository
{
    private readonly TaxiDbContext _context;

    public CarParkRepository(TaxiDbContext context) : base(context)
    {
        _context = context;
    }

    public CarParkModel GetParkById(int id)
    {
        Carpark? existing = DbSet.Local.FirstOrDefault(entity => entity.CarparkId == id);
        return existing is not null
            ? CarParkMapper.MapFrom(existing)
            : throw new NoSuchParkException("No park with these id");
    }

    public async void AddAsync(CarParkModel park)
    {
        await Add(park);
    }

    public async void UpdateAsync(CarParkModel park)
    {
        await Update(park);
    }

    public IAsyncEnumerable<CarParkModel> QueryAsync(CarParkQuery query)
    {
        var queryable = BuildQuery(_context.Carparks, query);
        return queryable.ToAsyncEnumerable().Select(entity => CarParkMapper.MapFrom(entity));
    }

    public IQueryable<Carpark> BuildQuery(IQueryable<Carpark> parkQueryable, CarParkQuery query)
    {
        if (query.Ids is not [])
        {
            parkQueryable = parkQueryable.Where(park => query.Ids.Contains(park.CarparkId));
        }

        if (query.Cursor is not null)
        {
            parkQueryable = parkQueryable.Where(park => park.CarparkId > query.Cursor);
        }

        if (query.Limit is not null)
        {
            parkQueryable = parkQueryable.Take(query.Limit.Value);
        }

        return parkQueryable;
    }

    protected override DbSet<Carpark> DbSet => _context.Carparks;

    protected override Carpark MapTo(CarParkModel model)
    {
        return CarParkMapper.MapTo(model);
    }

    protected override bool Equal(Carpark entity, CarParkModel model)
    {
        return entity.CarparkId.Equals(model.CarparkId);
    }

    protected override void UpdateModel(Carpark entity, CarParkModel model)
    {
        model.Address = entity.Address;
        model.Postcode = entity.Postcode;
        model.CarCount = entity.CarCount;
    }
}