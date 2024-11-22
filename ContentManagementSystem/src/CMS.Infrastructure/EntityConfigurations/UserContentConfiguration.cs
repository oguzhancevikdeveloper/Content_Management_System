using CMS.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.EntityConfigurations;

public class UserContentConfiguration : IEntityTypeConfiguration<UserContent>
{
    public void Configure(EntityTypeBuilder<UserContent> builder)
    {

        builder.ToTable("UserContents");

        builder.HasKey(uc => uc.Id);

        builder.HasOne(uc => uc.User)
            .WithMany(u => u.UserContents)
            .HasForeignKey(uc => uc.UserId);

        builder.HasOne(uc => uc.Content)
            .WithMany(c => c.UserContents)
            .HasForeignKey(uc => uc.ContentId);

    }
}
