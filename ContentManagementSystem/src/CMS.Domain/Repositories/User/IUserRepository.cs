namespace CMS.Domain.Repositories.User;

public interface IUserRepository
{
    Task<Models.User.User> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<Models.User.User>> GetAllUsersAsync();
    Task<Models.User.User> GetUserByEmailAsync(string email);
    Task AddUserAsync(Models.User.User user);
    Task UpdateUserAsync(Models.User.User user);
    Task DeleteUserAsync(Guid userId);
    Task<IEnumerable<Models.Content.Content>> GetUserContentAsync(Guid userId);
}
