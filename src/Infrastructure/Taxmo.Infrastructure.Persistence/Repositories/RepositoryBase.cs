using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Taxmo.Infrastructure.Persistence.Repositories;
public abstract class RepositoryBase<TEntity, TModel> where TEntity : class
{
    private readonly DbContext _context;

    protected RepositoryBase(DbContext context)
    {
        _context = context;
    }

    protected abstract DbSet<TEntity> DbSet { get; }

    public Task Add(TModel model)
    {
        TEntity entity = MapTo(model);
        DbSet.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(TModel model)
    {
        EntityEntry entry = GetEntry(model);
        UpdateModel((TEntity)entry.Entity, model);

        entry.State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public Task Remove(TModel model)
    {
        EntityEntry entry = GetEntry(model);
        entry.State = entry.State is EntityState.Added ? EntityState.Detached : EntityState.Deleted;
        return Task.CompletedTask;
    }

    protected abstract TEntity MapTo(TModel model);

    protected abstract bool Equal(TEntity entity, TModel model);

    protected abstract void UpdateModel(TEntity entity, TModel model);

    private EntityEntry GetEntry(TModel model)
    {
        TEntity? existing = DbSet.Local.FirstOrDefault(entity => Equal(entity, model));

        return existing is not null
            ? _context.Entry(existing)
            : DbSet.Attach(MapTo(model));
    }

    /*private int GetEntryById(int id)
    {
        TEntity? existing = DbSet.Local.FirstOrDefault(entity => entity.);
    }*/
}
