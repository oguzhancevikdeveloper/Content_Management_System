using CMS.Domain.DTOs.Content;
using CMS.Domain.Models.Content;
using Mapster;

namespace CMS.Application.Mapper;

public class MappingConfig
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<ContentDto, Content>.NewConfig()
            .Map(dest => dest.Variants, src => src.contentVariantDtos.Adapt<List<ContentVariant>>())
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Language, src => src.Language)
            .Map(dest => dest.ImageUrl, src => src.ImageUrl);

        TypeAdapterConfig<ContentVariantDto, ContentVariant>.NewConfig()
            .Map(dest => dest.Variant, src => src.Variant);

        TypeAdapterConfig<Content, ContentDto>
            .NewConfig()
            .Map(dest => dest.contentVariantDtos,
                src => src.Variants.Adapt<List<ContentVariantDto>>());

        TypeAdapterConfig<Content, ContentDto>
            .NewConfig()
            .Map(dest => dest.contentVariantDtos, src => src.Variants);
    }
}