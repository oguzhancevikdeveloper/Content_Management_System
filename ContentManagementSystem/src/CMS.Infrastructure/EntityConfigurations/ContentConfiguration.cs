using CMS.Domain.Models.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.EntityConfigurations;

public class ContentConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200); 

        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(1000); 

        builder.Property(c => c.Language)
            .IsRequired()
            .HasMaxLength(5); 

        builder.Property(c => c.ImageUrl)
            .IsRequired()
            .HasMaxLength(500); 

        builder.HasMany(c => c.Variants)
            .WithOne(cv => cv.Content)
            .HasForeignKey(cv => cv.ContentId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(c => c.Category)
            .WithMany(c => c.Contents)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
