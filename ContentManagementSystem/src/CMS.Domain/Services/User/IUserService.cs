using CMS.Domain.DTOs.Content;
using CMS.Domain.DTOs.User;
using CMS.Shared.DTOs;

namespace CMS.Domain.Services.User;

public interface IUserService
{
    Task<Response<UserDto>> GetUserByIdAsync(Guid userId);
    Task<Response<IEnumerable<UserDto>>> GetAllUsersAsync();
    Task<Response<UserDto>> GetUserByEmailAsync(string email);
    Task<Response<NoDataDto>> AddUserAsync(UserDto  userDto);
    Task<Response<NoDataDto>>  UpdateUserAsync(Guid userId,UserDto  userDto);
    Task<Response<NoDataDto>>  DeleteUserAsync(Guid userId);
    Task<Response<IEnumerable<ContentDto>>> GetUserContentAsync(Guid userId);
}
