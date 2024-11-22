using CMS.Domain.Models.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.EntityConfigurations;

public class ContentConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {

        // Tablo adı belirleniyor
        builder.ToTable("Contents");

        // ID'yi belirtmek (varsayılan olarak Id adında olduğu için EF bunu zaten alır, ama açıkça belirtilmesi tercih edilebilir)
        builder.HasKey(c => c.Id);

        // Kolonlar için özellikler
        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        builder.Property(c => c.Category)
            .HasMaxLength(100);

        builder.Property(c => c.Language)
            .HasMaxLength(10);

        builder.Property(c => c.ImageUrl)
            .HasMaxLength(500);

        // İçerik varyantları ilişkisi
        builder.HasMany(c => c.Variants)
            .WithOne()
            .HasForeignKey(v => v.ContentId);

        builder.HasMany(c => c.UserContents)
                  .WithOne(uc => uc.Content)
                  .HasForeignKey(uc => uc.ContentId);
    }
}
