using Microsoft.EntityFrameworkCore;
using Taxmo.Application.Models;
using Taxmo.Infrastructure.Persistence.Context;
using Taxmo.Infrastructure.Persistence.Exceptions;
using Taxmo.Infrastructure.Persistence.Mappers;
using Taxmo.Infrastructure.Persistence.Repositories.Interfaces;
using Taxmo.Infrastructure.Persistence.Repositories.Queries;

namespace Taxmo.Infrastructure.Persistence.Repositories;
public class OrderRepository : RepositoryBase<Taxiorder, OrderModel>, IOrderRepository
{
    private readonly TaxiDbContext _context;

    public OrderRepository(TaxiDbContext context) : base(context)
    {
        _context = context;
    }

    public OrderModel GetOrderById(int id)
    {
        Taxiorder? existing = DbSet.Local.FirstOrDefault(entity => entity.OrderId == id);
        return existing is not null
            ? TaxiorderMapper.MapFrom(existing)
            : throw new NoSuchOrderException("No order with these id");
    }

    public async void AddAsync(OrderModel order)
    {
        await Add(order);
    }

    public async void UpdateAsync(OrderModel order)
    {
        await Update(order);
    }

    public async void RemoveAsync(OrderModel order)
    {
        await Remove(order);
    }

    public IAsyncEnumerable<OrderModel> QueryAsync(OrderQuery query)
    {
        var queryable = BuildQuery(_context.Taxiorders, query);
        return queryable.ToAsyncEnumerable().Select(entity => TaxiorderMapper.MapFrom(entity));
    }

    public IQueryable<Taxiorder> BuildQuery(IQueryable<Taxiorder> orderQueryable, OrderQuery query)
    {
        if (query.Ids is not [])
        {
            orderQueryable = orderQueryable.Where(order => query.Ids.Contains(order.OrderId));
        }

        if (query.MaxPassengerRate is not null)
        {
            var minRate = query.MinPassengerRate is null ? 1 : query.MinPassengerRate;
        }

        if (query.TypePatterns is not [])
        {
        }

        if (query.MaxPrice is not null)
        {
            var minPrice = query.MinPrice is null ? 0 : query.MinPrice;
        }

        if (query.Limit is not null)
        {
            orderQueryable = orderQueryable.Take(query.Limit.Value);
        }

        return orderQueryable;
    }

    protected override DbSet<Taxiorder> DbSet => _context.Taxiorders;

    protected override Taxiorder MapTo(OrderModel model)
    {
        return TaxiorderMapper.MapTo(model);
    }

    protected override bool Equal(Taxiorder entity, OrderModel model)
    {
        return entity.OrderId.Equals(model.OrderId);
    }

    protected override void UpdateModel(Taxiorder entity, OrderModel model)
    {
    }
}
