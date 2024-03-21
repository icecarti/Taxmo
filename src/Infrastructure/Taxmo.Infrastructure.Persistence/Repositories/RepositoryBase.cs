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

    public void Add(TModel model)
    {
        TEntity entity = MapTo(model);
        DbSet.Add(entity);
    }

    public void Update(TModel model)
    {
        EntityEntry entry = GetEntry(model);
        UpdateModel((TEntity)entry.Entity, model);

        entry.State = EntityState.Modified;
    }

    public void Remove(TModel model)
    {
        EntityEntry entry = GetEntry(model);
        entry.State = entry.State is EntityState.Added ? EntityState.Detached : EntityState.Deleted;
    }

    protected abstract TEntity MapTo(TModel model);

    protected abstract bool Equal(TEntity entity, TModel model);

    protected abstract bool UpdateModel(TEntity entity, TModel model);

    protected abstract TModel GetById(int id);

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
