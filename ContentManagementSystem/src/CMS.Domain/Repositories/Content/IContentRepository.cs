namespace CMS.Domain.Repositories.Content;

public interface IContentRepository
{
    Task<Models.Content.Content> GetContentByIdAsync(int contentId);
    Task<IEnumerable<Models.Content.Content>> GetAllContentsAsync();
    Task AddContentAsync(Models.Content.Content content);
    Task UpdateContentAsync(Models.Content.Content content);
    Task DeleteContentAsync(int contentId);

    Task<IEnumerable<Models.Content.ContentVariant>> GetContentVariantsAsync(int contentId);
    Task<IEnumerable<Models.Content.Content>> GetContentsByCategoryAsync(string categoryName);
    Task<Models.Content.Content> GetContentByTitleAsync(string title);
    Task<IEnumerable<Models.Content.Content>> GetContentsByLanguageAsync(string language);
}

