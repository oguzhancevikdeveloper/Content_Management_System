using CMS.Domain.Models.Content;

namespace CMS.Domain.Repositories.User;

public interface IUserRepository
{
    Task<Models.User.User> GetUserByIdAsync(int userId);
    Task<IEnumerable<Models.User.User>> GetAllUsersAsync();
    Task<Models.User.User> GetUserByEmailAsync(string email);
    Task AddUserAsync(Models.User.User user);
    Task UpdateUserAsync(Models.User.User user);
    Task DeleteUserAsync(int userId);
    Task<IEnumerable<Models.Content.Content>> GetUserContentAsync(int userId);
}
