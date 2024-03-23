using Microsoft.EntityFrameworkCore;
using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Exceptions;
using Taxmo.Infrastructure.Persistence.Mappers;
using Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories;

public class TaxiRepository : RepositoryBase<Taxi, TaxiCompanyModel>, ITaxiRepository
{
    private readonly TaxiDbContext _context;

    public TaxiRepository(TaxiDbContext context) : base(context)
    {
        _context = context;
    }

    public TaxiCompanyModel GetTaxiById(string ie)
    {
        Taxi? existing = DbSet.Local.FirstOrDefault(entity => entity.Ie == ie);
        return existing is not null
            ? TaxiMapper.MapFrom(existing)
            : throw new NoSuchTaxiException("No Taxi company with these id");
    }

    public async void AddAsync(TaxiCompanyModel taxi)
    {
        await Add(taxi);
    }

    public async void UpdateAsync(TaxiCompanyModel taxi)
    {
        await Update(taxi);
    }

    public IAsyncEnumerable<TaxiCompanyModel> QueryAsync(TaxiQuery query)
    {
        var queryable = BuildQuery(_context.Taxies, query);
        return queryable.ToAsyncEnumerable().Select(entity => TaxiMapper.MapFrom(entity));
    }

    public IQueryable<Taxi> BuildQuery(IQueryable<Taxi> taxiQueryable, TaxiQuery query)
    {
        if (query.Ies is not [])
        {
            taxiQueryable = taxiQueryable.Where(taxi => query.Ies.Contains(taxi.Ie));
        }

        if (query.RegDates is not [])
        {
            taxiQueryable = taxiQueryable.Where(taxi => query.RegDates.Any(regDate => taxi.RegistrationDate == regDate));
        }

        if (query.Cursor is not null)
        {
            string? cursorString = query.Cursor.ToString();
            taxiQueryable = taxiQueryable.Where(taxi => string.Compare(taxi.Ie, cursorString) > 0);
        }

        if (query.Limit is not null)
        {
            taxiQueryable = taxiQueryable.Take(query.Limit.Value);
        }

        return taxiQueryable;
    }

    protected override DbSet<Taxi> DbSet => _context.Taxies;

    protected override Taxi MapTo(TaxiCompanyModel model)
    {
        return TaxiMapper.MapTo(model);
    }

    protected override bool Equal(Taxi entity, TaxiCompanyModel model)
    {
        return entity.Ie.Equals(model.Ie, StringComparison.Ordinal);
    }

    protected override void UpdateModel(Taxi entity, TaxiCompanyModel model)
    {
        model.Name = entity.Name;
        model.Phone = entity.Phone;
    }
}