using CMS.Domain.Repositories.Category;
using CMS.Domain.Repositories.Generic;
using CMS.Domain.UnitOfWork;

namespace CMS.Infrastructure.Repositories.Category;

public class CategoryRepository : ICategoryRepository
{
    private readonly IGenericRepository<Domain.Models.Category.Category> _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryRepository(IGenericRepository<Domain.Models.Category.Category> categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddCategoryAsync(Domain.Models.Category.Category category)
    {
        await _categoryRepository.AddAsync(category);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteCategoryAsync(int categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        _categoryRepository.Remove(category);
        _unitOfWork.Commit();
    }

    public async Task<IEnumerable<Domain.Models.Category.Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Domain.Models.Category.Category> GetCategoryByIdAsync(int categoryId)
    {
        return await _categoryRepository.GetByIdAsync(categoryId);
    }

    public async Task UpdateCategoryAsync(Domain.Models.Category.Category category)
    {
        _categoryRepository.Update(category);
        _unitOfWork.Commit();
    }
}
