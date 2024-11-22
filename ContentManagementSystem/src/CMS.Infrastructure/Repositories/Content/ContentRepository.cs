using CMS.Domain.Models.Content;
using CMS.Domain.Repositories.Content;
using CMS.Domain.Repositories.Generic;
using CMS.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Repositories.Content;

public class ContentRepository : IContentRepository
{
    private readonly IGenericRepository<Domain.Models.Content.Content> _genericRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ContentRepository(IGenericRepository<Domain.Models.Content.Content> genericRepository, IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddContentAsync(Domain.Models.Content.Content content)
    {
        await _genericRepository.AddAsync(content);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteContentAsync(Guid contentId)
    {
        var content = await _genericRepository.GetByIdAsync(contentId);
        _genericRepository.Remove(content);
        _unitOfWork.Commit();
    }

    public async Task<IEnumerable<Domain.Models.Content.Content>> GetAllContentsAsync()
    {
        return await _genericRepository.Where(x => true).Include(c => c.Variants).ToListAsync();
    }

    public async Task<Domain.Models.Content.Content> GetContentByIdAsync(Guid contentId)
    {
        var content = await _genericRepository.Where(x => x.Id == contentId).Include(v => v.Variants).FirstOrDefaultAsync();
        return content;
    }

    public async Task<Domain.Models.Content.Content> GetContentByTitleAsync(string title)
    {
        var content = await _genericRepository.Where(x => x.Title == title).Include(v => v.Variants).FirstOrDefaultAsync();
        return content;
    }

    public async Task<IEnumerable<Domain.Models.Content.Content>> GetContentsByCategoryAsync(Guid categoryId)
    {
        var contentList = await _genericRepository.Where(x => x.CategoryId == categoryId).Include(v => v.Variants).ToListAsync();
        return contentList;
    }

    public async Task<IEnumerable<Domain.Models.Content.Content>> GetContentsByLanguageAsync(string language)
    {
        var contentList = await _genericRepository.Where(x => x.Language == language).Include(v => v.Variants).ToListAsync();
        return contentList;
    }

    public async Task<IEnumerable<ContentVariant>> GetContentVariantsAsync(Guid contentId)
    {
        var content = await _genericRepository.Where(x => x.Id == contentId)
            .Include(c => c.Variants).FirstOrDefaultAsync();
        if (content == null || content.Variants == null || !content.Variants.Any()) return Enumerable.Empty<ContentVariant>();
        return content.Variants;
    }

    public async Task UpdateContentAsync(Domain.Models.Content.Content content)
    {
        _genericRepository.Update(content);
        await _unitOfWork.CommitAsync();
    }
}
