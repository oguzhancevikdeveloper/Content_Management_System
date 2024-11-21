using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using CMS.Infrastructure.Context;

namespace CMS.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {

        DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}