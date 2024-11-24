namespace CMS.Domain.Repositories.User;

public interface IUserContentRepository
{
    Task AddUserContentAsync(Models.User.UserContent  userContent);
    Task<Models.User.UserContent> GetUserContentByIdsAsync(Guid userId, Guid contentId);
    Task DeleteUserContentAsync(Guid userId, Guid contentId);

}
