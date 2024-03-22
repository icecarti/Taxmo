using Microsoft.EntityFrameworkCore;
using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Exceptions;
using Taxmo.Infrastructure.Persistence.Mappers;
using Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories;
public class PassengerRepository : RepositoryBase<Passenger, PassengerModel>, IPassengerRepository
{
    private readonly TaxiDbContext _context;

    public PassengerRepository(TaxiDbContext context) : base(context)
    {
        _context = context;
    }

    public PassengerModel GetPassengerById(int id)
    {
        Passenger? existing = DbSet.Local.FirstOrDefault(entity => entity.PassengerId == id);
        return existing is not null
            ? PassengerMapper.MapFrom(existing)
            : throw new NoSuchPassengerException("No passenger with these id");
    }

    public async void AddAsync(PassengerModel passenger)
    {
        await Add(passenger);
    }

    public async void UpdateAsync(PassengerModel passenger)
    {
        await Update(passenger);
    }

    public IAsyncEnumerable<PassengerModel> QueryAsync(PassengerQuery query)
    {
        var queryable = BuildQuery(_context.Passengers, query);
        return queryable.ToAsyncEnumerable().Select(entity => PassengerMapper.MapFrom(entity));
    }

    public IQueryable<Passenger> BuildQuery(IQueryable<Passenger> passQueryable, PassengerQuery query)
    {
        if (query.Ids is not [])
        {
            passQueryable = passQueryable.Where(passenger => query.Ids.Contains(passenger.PassengerId));
        }

        if (query.FullNamePatterns is not [])
        {
        }

        if (query.Limit is not null)
        {
            passQueryable = passQueryable.Take(query.Limit.Value);
        }

        return passQueryable;
    }

    protected override DbSet<Passenger> DbSet => _context.Passengers;

    protected override Passenger MapTo(PassengerModel model)
    {
        return PassengerMapper.MapTo(model);
    }

    protected override bool Equal(Passenger entity, PassengerModel model)
    {
        return entity.PassengerId.Equals(model.PassengerId);
    }

    protected override void UpdateModel(Passenger entity, PassengerModel model)
    {
        model.Name = entity.Name;
        model.Phone = entity.Phone;
        model.Email = entity.Email;
    }
}
