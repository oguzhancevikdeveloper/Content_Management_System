using CMS.Domain.DTOs.Content;
using CMS.Shared.DTOs;

namespace CMS.Domain.Services.Content;

public interface IContentService
{
    Task<Response<IEnumerable<ContentDto>>> GetAllContentsAsync(); 
    Task<Response<ContentDto>> GetContentByIdAsync(int contentId); 
    Task<Response<IEnumerable<ContentDto>>> GetContentsByCategoryAsync(int categoryId); 
    Task<Response<IEnumerable<ContentVariantDto>>> GetContentVariantsAsync(int contentId);
    Task<Response<IEnumerable<ContentDto>>> GetContentsByLanguageAsync(string language);
    Task<Response<ContentDto>> GetContentByTitleAsync(string title);
    Task<Response<NoDataDto>> AddContentAsync(ContentDto contentDto); 
    Task<Response<NoDataDto>> UpdateContentAsync(int contentId, ContentDto contentDto); 
    Task<Response<NoDataDto>> DeleteContentAsync(int contentId); 
}
