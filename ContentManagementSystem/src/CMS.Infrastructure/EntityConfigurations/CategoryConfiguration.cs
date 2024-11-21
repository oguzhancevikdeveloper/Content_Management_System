using CMS.Domain.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasMany(c => c.Contents)
           .WithOne(con => con.Category)
           .HasForeignKey(con => con.CategoryId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
