using CMS.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.EntityConfigurations;

public class UserContentConfiguration : IEntityTypeConfiguration<UserContent>
{
    public void Configure(EntityTypeBuilder<UserContent> builder)
    {

        builder.HasOne(uc => uc.Content)
            .WithMany(c => c.UserContents)
            .HasForeignKey(uc => uc.ContentId)
            .OnDelete(DeleteBehavior.NoAction); 


        builder.HasOne(uc => uc.ContentVariant)
            .WithMany(cv => cv.UserContents)
            .HasForeignKey(uc => uc.ContentVariantId)
            .OnDelete(DeleteBehavior.NoAction); 

        builder.HasOne(uc => uc.User)
            .WithMany(u => u.UserContents)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
