using CMS.Domain.Models.Content;
using CMS.Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Content> Contents { get; set; }
    public DbSet<ContentVariant> ContentVariants { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserContent> UserContents { get; set; }
}
