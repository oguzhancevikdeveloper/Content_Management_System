namespace CMS.Domain.Repositories.Content;

public interface IContentRepository
{
    Task<Models.Content.Content> GetContentByIdAsync(Guid contentId);
    Task<IEnumerable<Models.Content.Content>> GetAllContentsAsync();
    Task AddContentAsync(Models.Content.Content content);
    Task UpdateContentAsync(Models.Content.Content content);
    Task DeleteContentAsync(Guid contentId);


    Task<IEnumerable<Models.Content.ContentVariant>> GetContentVariantsAsync(Guid contentId);
    Task<IEnumerable<Models.Content.Content>> GetContentsByCategoryAsync(Guid categoryId);
    Task<Models.Content.Content> GetContentByTitleAsync(string title);
    Task<IEnumerable<Models.Content.Content>> GetContentsByLanguageAsync(string language);
}

