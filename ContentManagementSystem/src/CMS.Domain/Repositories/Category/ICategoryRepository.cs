namespace CMS.Domain.Repositories.Category;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Models.Category.Category category);
    Task<Models.Category.Category> GetCategoryByIdAsync(Guid categoryId);
    Task<IEnumerable<Models.Category.Category>> GetAllCategoriesAsync();
    Task UpdateCategoryAsync(Models.Category.Category category);
    Task DeleteCategoryAsync(Guid categoryId);
}
