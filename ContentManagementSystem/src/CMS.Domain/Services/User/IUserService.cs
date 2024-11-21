using CMS.Domain.DTOs.Content;
using CMS.Domain.DTOs.User;
using CMS.Shared.DTOs;

namespace CMS.Domain.Services.User;

public interface IUserService
{
    Task<Response<UserDto>> GetUserByIdAsync(int userId);
    Task<Response<IEnumerable<UserDto>>> GetAllUsersAsync();
    Task<Response<UserDto>> GetUserByEmailAsync(string email);
    Task<Response<NoDataDto>> AddUserAsync(UserDto  userDto);
    Task<Response<NoDataDto>>  UpdateUserAsync(Models.User.User user);
    Task<Response<NoDataDto>>  DeleteUserAsync(int userId);
    Task<Response<IEnumerable<ContentDto>>> GetUserContentAsync(int userId);
}
