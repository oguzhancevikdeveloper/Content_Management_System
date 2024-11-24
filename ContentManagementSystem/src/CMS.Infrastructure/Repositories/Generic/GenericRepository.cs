using CMS.Domain.Repositories.Generic;
using CMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CMS.Infrastructure.Repositories.Generic;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbset;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbset = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbset.AddAsync(entity);

    }
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbset.ToListAsync();
    }
    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        var entity = await _dbset.FindAsync(id);
        if (entity != null) _context.Entry(entity).State = EntityState.Detached;
        return entity;
    }
    public void Remove(TEntity entity)
    {
        _dbset.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        if (entities == null || !entities.Any())
            throw new ArgumentNullException(nameof(entities), "Entities cannot be null or empty");

        _context.RemoveRange(entities);
    }

    public TEntity Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return entity;

    }
    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbset.AsNoTracking().Where(predicate);
    }
}
