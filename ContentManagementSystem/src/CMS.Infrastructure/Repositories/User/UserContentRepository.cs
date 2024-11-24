using CMS.Domain.Models.Content;
using CMS.Domain.Models.User;
using CMS.Domain.Repositories.Generic;
using CMS.Domain.Repositories.User;
using CMS.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Repositories.User;

public class UserContentRepository : IUserContentRepository
{
    private readonly IGenericRepository<UserContent> _genericRepository;
    private readonly IGenericRepository<ContentVariant> _genericContentVariantRepository;
    private readonly IGenericRepository<Domain.Models.Content.Content> _genericContentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserContentRepository(IGenericRepository<UserContent> genericRepository, IUnitOfWork unitOfWork, IGenericRepository<ContentVariant> genericContentVariantRepository, IGenericRepository<Domain.Models.Content.Content> genericContentRepository)
    {
        _genericRepository = genericRepository;
        _unitOfWork = unitOfWork;
        _genericContentVariantRepository = genericContentVariantRepository;
        _genericContentRepository = genericContentRepository;
    }
    public async Task AddUserContentAsync(UserContent userContent)
    {
        await _genericRepository.AddAsync(userContent);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteUserContentAsync(Guid userId, Guid contentId)
    {
        var userContent = await _genericRepository.Where(x => x.UserId == userId && x.ContentId == contentId).Include(t => t.Content).ThenInclude(v => v.Variants).FirstOrDefaultAsync();

        if (userContent != null)
        {
            if (userContent.Content?.Variants != null)
            {
                foreach (var variant in userContent.Content.Variants)
                {
                    _genericContentVariantRepository.Remove(variant);
                }
            }

            if (userContent.Content != null)
            {
                _genericContentRepository.Remove(userContent.Content);
            }
            _genericRepository.Remove(userContent);

            await _unitOfWork.CommitAsync();

        }
    }

    public async Task<UserContent> GetUserContentByIdsAsync(Guid userId, Guid contentId)
    {
        return await _genericRepository.Where(x => x.UserId == userId && x.ContentId == contentId).Include(x => x.Content).ThenInclude(v => v.Variants).FirstAsync();
    }
}
