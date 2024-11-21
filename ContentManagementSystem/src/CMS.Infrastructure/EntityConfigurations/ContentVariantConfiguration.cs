﻿using CMS.Domain.Models.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.EntityConfigurations;

internal class ContentVariantConfiguration : IEntityTypeConfiguration<ContentVariant>
{
    public void Configure(EntityTypeBuilder<ContentVariant> builder)
    {

        builder.HasOne(cv => cv.Content)
            .WithMany(c => c.Variants)
            .HasForeignKey(cv => cv.ContentId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasMany(cv => cv.UserContents)
            .WithOne(uc => uc.ContentVariant)
            .HasForeignKey(uc => uc.ContentVariantId)
            .OnDelete(DeleteBehavior.NoAction); 
    }
}