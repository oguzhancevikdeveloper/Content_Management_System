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

        //// Foreign Key: User -> UserContent (Silme işlemini engelle)
        //builder.HasOne(uc => uc.User)
        //       .WithMany() // User'dan birden fazla UserContent olabilir
        //       .HasForeignKey(uc => uc.UserId)
        //       .OnDelete(DeleteBehavior.Restrict); // Kullanıcıyı silmeye izin verme


        builder.HasOne(uc => uc.Content)
               .WithMany() 
               .HasForeignKey(uc => uc.ContentId)
               .OnDelete(DeleteBehavior.Cascade);


    }
}
