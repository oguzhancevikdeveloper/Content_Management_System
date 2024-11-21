using CMS.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _dbContext;

    public UnitOfWork(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
