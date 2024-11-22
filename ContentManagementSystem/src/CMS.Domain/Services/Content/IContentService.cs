using CMS.Domain.DTOs.Content;
using CMS.Shared.DTOs;

namespace CMS.Domain.Services.Content;

public interface IContentService
{
    Task<Response<IEnumerable<ContentDto>>> GetAllContentsAsync(); 
    Task<Response<ContentDto>> GetContentByIdAsync(Guid contentId); 
    Task<Response<IEnumerable<ContentDto>>> GetContentsByCategoryAsync(Guid categoryId); 
    Task<Response<IEnumerable<ContentVariantDto>>> GetContentVariantsAsync(Guid contentId);
    Task<Response<IEnumerable<ContentDto>>> GetContentsByLanguageAsync(string language);
    Task<Response<ContentDto>> GetContentByTitleAsync(string title);
    Task<Response<NoDataDto>> AddContentAsync(Guid userId, ContentDto contentDto); 
    Task<Response<NoDataDto>> UpdateContentAsync(Guid contentId, ContentDto contentDto); 
    Task<Response<NoDataDto>> DeleteContentAsync(Guid contentId); 
}
