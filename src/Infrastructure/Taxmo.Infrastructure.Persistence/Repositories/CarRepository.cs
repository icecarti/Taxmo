using Microsoft.EntityFrameworkCore;
using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Exceptions;
using Taxmo.Infrastructure.Persistence.Mappers;
using Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories;

public class CarRepository : RepositoryBase<Car, CarModel>, ICarRepository
{
    private readonly TaxiDbContext _context;

    public CarRepository(TaxiDbContext context) : base(context)
    {
        _context = context;
    }

    public CarModel GetCarById(int id)
    {
        Car? existing = DbSet.Local.FirstOrDefault(entity => entity.CarId == id);
        return existing is not null
            ? CarMapper.MapFrom(existing)
            : throw new NoSuchCarException("No car with these id");
    }

    public async void AddAsync(CarModel car)
    {
        await Add(car);
    }

    public async void UpdateAsync(CarModel car)
    {
        await Update(car);
    }

    public async void RemoveAsync(CarModel car)
    {
        await Remove(car);
    }

    public IAsyncEnumerable<CarModel> QueryAsync(CarQuery query)
    {
        var queryable = BuildQuery(_context.Cars, query);
        return queryable.ToAsyncEnumerable().Select(entity => CarMapper.MapFrom(entity));
    }

    public IQueryable<Car> BuildQuery(IQueryable<Car> carQueryable, CarQuery query)
    {
        if (query.Ids is not [])
        {
            carQueryable = carQueryable.Where(car => query.Ids.Contains(car.CarId));
        }

        if (query.Colors is not [])
        {
            carQueryable = carQueryable.Where(car => query.Colors.Contains(car.Color));
        }

        if (query.Cursor is not null)
        {
            carQueryable = carQueryable.Where(car => car.CarId > query.Cursor);
        }

        if (query.Limit is not null)
        {
            carQueryable = carQueryable.Take(query.Limit.Value);
        }

        return carQueryable;
    }

    protected override DbSet<Car> DbSet => _context.Cars;

    protected override Car MapTo(CarModel model)
    {
        return CarMapper.MapTo(model);
    }

    protected override bool Equal(Car entity, CarModel model)
    {
        return entity.CarId.Equals(model.CarId);
    }

    protected override void UpdateModel(Car entity, CarModel model)
    {
        model.CarNumber = entity.CarNumber;
    }
}