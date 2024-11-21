using CMS.Domain.Repositories.Generic;
using CMS.Domain.Repositories.User;
using CMS.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<Domain.Models.User.User> _genericRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserRepository(IGenericRepository<Domain.Models.User.User> genericRepository, IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddUserAsync(Domain.Models.User.User user)
    {
        await _genericRepository.AddAsync(user);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _genericRepository.GetByIdAsync(userId);
        _genericRepository.Remove(user);
        _unitOfWork.Commit();

    }

    public async Task<IEnumerable<Domain.Models.User.User>> GetAllUsersAsync()
    {
        var userList = await _genericRepository.GetAllAsync();
        return userList;
    }

    public async Task<Domain.Models.User.User> GetUserByEmailAsync(string email)
    {
        var user = await _genericRepository.Where(x => x.Email == email).FirstOrDefaultAsync();
        return user;
    }

    public async Task<Domain.Models.User.User> GetUserByIdAsync(int userId)
    {
        var user = await _genericRepository.GetByIdAsync(userId);
        return user;
    }

    public async Task<IEnumerable<Domain.Models.Content.Content>> GetUserContentAsync(int userId)
    {
        var user = await _genericRepository.Where(x => x.Id == userId)
            .Include(u => u.UserContents)
            .ThenInclude(uc => uc.Content)
            .FirstOrDefaultAsync();

        if(user == null || user.UserContents == null || !user.UserContents.Any()) return Enumerable.Empty<Domain.Models.Content.Content>();

        return user.UserContents.Select(uc => uc.Content).ToList();
    }

    public async Task UpdateUserAsync(Domain.Models.User.User user)
    {
        _genericRepository.Update(user);
        await _unitOfWork.CommitAsync();
    }
}
