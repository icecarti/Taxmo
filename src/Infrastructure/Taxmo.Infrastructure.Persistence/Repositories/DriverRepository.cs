using Microsoft.EntityFrameworkCore;
using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Exceptions;
using Taxmo.Infrastructure.Persistence.Mappers;
using Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories;
public class DriverRepository : RepositoryBase<Driver, DriverModel>, IDriverRepository
{
    private readonly TaxiDbContext _context;

    public DriverRepository(TaxiDbContext context) : base(context)
    {
        _context = context;
    }

    public DriverModel GetDriverById(int id)
    {
        Driver? existing = DbSet.Local.FirstOrDefault(entity => entity.DriverId == id);
        return existing is not null
            ? DriverMapper.MapFrom(existing)
            : throw new NoSuchDriverException("No driver with these id");
    }

    public async void AddAsync(DriverModel driver)
    {
        await Add(driver);
    }

    public async void UpdateAsync(DriverModel driver)
    {
        await Update(driver);
    }

    public IAsyncEnumerable<DriverModel> QueryAsync(DriverQuery query)
    {
        var queryable = BuildQuery(_context.Drivers, query);
        return queryable.ToAsyncEnumerable().Select(entity => DriverMapper.MapFrom(entity));
    }

    public IQueryable<Driver> BuildQuery(IQueryable<Driver> driverQueryable, DriverQuery query)
    {
        if (query.Ids is not [])
        {
            driverQueryable = driverQueryable.Where(driver => query.Ids.Contains(driver.DriverId));
        }

        if (query.FullNamePatterns is not [])
        {
        }

        if (query.LicensePatterns is not [])
        {
        }

        if (query.PassportPatterns is not [])
        {
        }

        if (query.Limit is not null)
        {
            driverQueryable = driverQueryable.Take(query.Limit.Value);
        }

        return driverQueryable;
    }

    protected override DbSet<Driver> DbSet => _context.Drivers;

    protected override Driver MapTo(DriverModel model)
    {
        return DriverMapper.MapTo(model);
    }

    protected override bool Equal(Driver entity, DriverModel model)
    {
        return entity.DriverId.Equals(model.DriverId);
    }

    protected override void UpdateModel(Driver entity, DriverModel model)
    {
        model.Name = entity.Name;
        model.DriverLicense = entity.DriverLicense;
        model.Email = entity.Email;
        model.Phone = entity.Phone;
        model.Passport = entity.Passport;
    }
}
