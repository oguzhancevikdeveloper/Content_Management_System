using CMS.Domain.DTOs.Content;
using CMS.Domain.DTOs.User;
using CMS.Domain.Repositories.User;
using CMS.Domain.Services.User;
using CMS.Shared.DTOs;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace CMS.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Response<NoDataDto>> AddUserAsync(UserDto userDto)
    {
        var userEntity = userDto.Adapt<Domain.Models.User.User>();
        await _userRepository.AddUserAsync(userEntity);
        return Response<NoDataDto>.Success(StatusCodes.Status200OK);
    }

    public async Task<Response<NoDataDto>> DeleteUserAsync(int userId)
    {
        await _userRepository.DeleteUserAsync(userId);
        return Response<NoDataDto>.Success(StatusCodes.Status200OK);
    }

    public async Task<Response<IEnumerable<UserDto>>> GetAllUsersAsync()
    {
        var userList = await _userRepository.GetAllUsersAsync();
        var userDtoList = userList.Adapt<IEnumerable<UserDto>>();
        return Response<IEnumerable<UserDto>>.Success(userDtoList, StatusCodes.Status200OK);

    }

    public async Task<Response<UserDto>> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null) return Response<UserDto>.Fail("User not a found", StatusCodes.Status404NotFound, true);
        var userDto = user.Adapt<UserDto>();
        return Response<UserDto>.Success(userDto, StatusCodes.Status200OK);
    }

    public async Task<Response<UserDto>> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null) return Response<UserDto>.Fail("User not a found", StatusCodes.Status404NotFound, true); ;
        var userDto = user.Adapt<UserDto>();
        return Response<UserDto>.Success(userDto, StatusCodes.Status200OK); ;
    }

    public async Task<Response<IEnumerable<ContentDto>>> GetUserContentAsync(int userId)
    {
        var contentList = await _userRepository.GetUserContentAsync(userId);

        if (contentList == null || !contentList.Any()) return Response<IEnumerable<ContentDto>>.Fail("No content found for the user.", StatusCodes.Status404NotFound,true);

        var contentDtoList = contentList.Adapt<IEnumerable<ContentDto>>();
        return Response<IEnumerable<ContentDto>>.Success(contentDtoList, StatusCodes.Status200OK);
    }

    public async Task<Response<NoDataDto>> UpdateUserAsync(Domain.Models.User.User user)
    {
        await _userRepository.UpdateUserAsync(user);
        return Response<NoDataDto>.Success(StatusCodes.Status200OK);
    }
}
