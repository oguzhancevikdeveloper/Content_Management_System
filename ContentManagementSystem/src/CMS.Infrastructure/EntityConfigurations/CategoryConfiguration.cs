using CMS.Domain.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories"); 

        builder.HasKey(c => c.Id); 

        builder.Property(c => c.Name)
            .IsRequired() 
            .HasMaxLength(100); 

        builder.Property(c => c.Description)
            .HasMaxLength(500);  

        builder.HasMany(c => c.Contents) 
            .WithOne(content => content.Category)  
            .HasForeignKey(content => content.CategoryId)  
            .OnDelete(DeleteBehavior.Cascade);
    }
}
