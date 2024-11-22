using CMS.Domain.DTOs.Content;
using CMS.Domain.Models.Content;
using CMS.Domain.Models.User;
using CMS.Domain.Repositories.Content;
using CMS.Domain.Repositories.User;
using CMS.Domain.Services.Content;
using CMS.Shared.DTOs;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace CMS.Application.Services.Content;

public class ContentService : IContentService
{
    private readonly IContentRepository _contentRepository;
    private readonly IUserContentRepository _userContentRepository;
    private readonly IUserRepository _userRepository;

    public ContentService(IContentRepository contentRepository, IUserContentRepository userContentRepository, IUserRepository userRepository)
    {
        _contentRepository = contentRepository;
        _userContentRepository = userContentRepository;
        _userRepository = userRepository;
    }

    public async Task<Response<NoDataDto>> AddContentAsync(int userId,ContentDto contentDto)
    {
        var content = contentDto.Adapt<Domain.Models.Content.Content>();
        var contentVariants = contentDto.contentVariantDtos.Adapt<List<ContentVariant>>();

        content.Variants = contentVariants;

        await _contentRepository.AddContentAsync(content);
        var user  = await _userRepository.GetUserByIdAsync(userId);

        var userContent = new UserContent
        {
            Content = content,
            User = user
        };
        await _userContentRepository.AddUserContentAsync(userContent);

        return Response<NoDataDto>.Success(StatusCodes.Status201Created);
    }

    public async Task<Response<NoDataDto>> DeleteContentAsync(int contentId)
    {
        var content = await _contentRepository.GetContentByIdAsync(contentId);
        if (content == null) return Response<NoDataDto>.Fail("Content not found", StatusCodes.Status404NotFound, true);
        await _contentRepository.DeleteContentAsync(contentId);

        return Response<NoDataDto>.Success(StatusCodes.Status200OK);
    }

    public async Task<Response<IEnumerable<ContentDto>>> GetAllContentsAsync()
    {
        var contents = await _contentRepository.GetAllContentsAsync();
        var contentDtos = contents.Adapt<IEnumerable<ContentDto>>();

        return Response<IEnumerable<ContentDto>>.Success(contentDtos, StatusCodes.Status200OK);

    }

    public async Task<Response<ContentDto>> GetContentByIdAsync(int contentId)
    {
        var content = await _contentRepository.GetContentByIdAsync(contentId);
        if (content == null) return Response<ContentDto>.Fail("Content not found", StatusCodes.Status404NotFound, true);
        var contentDto = content.Adapt<ContentDto>();

        return Response<ContentDto>.Success(contentDto, StatusCodes.Status200OK);

    }

    public async Task<Response<ContentDto>> GetContentByTitleAsync(string title)
    {
        var content = await _contentRepository.GetContentByTitleAsync(title);
        if (content == null) return Response<ContentDto>.Fail("Content not found", StatusCodes.Status404NotFound, true);
        var contentDto = content.Adapt<ContentDto>();

        return Response<ContentDto>.Success(contentDto, StatusCodes.Status200OK);

    }

    public async Task<Response<IEnumerable<ContentDto>>> GetContentsByCategoryAsync(int categoryId)
    {
        var contents = await _contentRepository.GetContentsByCategoryAsync(categoryId);
        if (!contents.Any()) return Response<IEnumerable<ContentDto>>.Fail("No contents found for the specified category", StatusCodes.Status404NotFound, true);
        var contentDtos = contents.Adapt<IEnumerable<ContentDto>>();

        return Response<IEnumerable<ContentDto>>.Success(contentDtos, StatusCodes.Status200OK);

    }

    public async Task<Response<IEnumerable<ContentDto>>> GetContentsByLanguageAsync(string language)
    {
        var contents = await _contentRepository.GetContentsByLanguageAsync(language);
        if (!contents.Any()) return Response<IEnumerable<ContentDto>>.Fail("No contents found for the specified language", StatusCodes.Status404NotFound,true);
        var contentDtos = contents.Adapt<IEnumerable<ContentDto>>();

        return Response<IEnumerable<ContentDto>>.Success(contentDtos, StatusCodes.Status200OK);

    }

    public async Task<Response<IEnumerable<ContentVariantDto>>> GetContentVariantsAsync(int contentId)
    {
        var content = await _contentRepository.GetContentVariantsAsync(contentId);
        if (!content.Any())return Response<IEnumerable<ContentVariantDto>>.Fail("Content variants not found", StatusCodes.Status404NotFound,true);
        var contentVariantDtos = content.Adapt<IEnumerable<ContentVariantDto>>();

        return Response<IEnumerable<ContentVariantDto>>.Success(contentVariantDtos, StatusCodes.Status200OK);
    }

    public async Task<Response<NoDataDto>> UpdateContentAsync(int contentId, ContentDto contentDto)
    {
        var existingContent = await _contentRepository.GetContentByIdAsync(contentId);
        if (existingContent == null)return Response<NoDataDto>.Fail("Content not found", StatusCodes.Status404NotFound, true);
        contentDto.Adapt(existingContent);
        await _contentRepository.UpdateContentAsync(existingContent);

        return Response<NoDataDto>.Success(StatusCodes.Status200OK);
    }
}
