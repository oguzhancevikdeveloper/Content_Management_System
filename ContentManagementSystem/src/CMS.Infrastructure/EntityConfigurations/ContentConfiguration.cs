using CMS.Domain.Models.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.EntityConfigurations;

public class ContentConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {

        builder.HasOne(c => c.Category)
            .WithMany(cat => cat.Contents)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); 


        builder.HasMany(c => c.Variants)
            .WithOne(cv => cv.Content)
            .HasForeignKey(cv => cv.ContentId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasMany(c => c.UserContents)
            .WithOne(uc => uc.Content)
            .HasForeignKey(uc => uc.ContentId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
