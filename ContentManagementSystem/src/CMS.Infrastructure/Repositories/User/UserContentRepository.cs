using CMS.Domain.Models.User;
using CMS.Domain.Repositories.Generic;
using CMS.Domain.Repositories.User;
using CMS.Domain.UnitOfWork;

namespace CMS.Infrastructure.Repositories.User;

public class UserContentRepository : IUserContentRepository
{
    private readonly IGenericRepository<UserContent> _genericRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserContentRepository(IGenericRepository<UserContent> genericRepository, IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task AddUserContentAsync(UserContent userContent)
    {
        await _genericRepository.AddAsync(userContent);
        await _unitOfWork.CommitAsync();
    }
}
