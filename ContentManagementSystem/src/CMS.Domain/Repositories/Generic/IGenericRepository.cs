﻿using System.Linq.Expressions;

namespace CMS.Domain.Repositories.Generic;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    TEntity Update(TEntity entity);
    void Remove(TEntity entity);

    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
}