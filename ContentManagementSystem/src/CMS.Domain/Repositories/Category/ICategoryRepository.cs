namespace CMS.Domain.Repositories.Category;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Models.Category.Category category);
    Task<Models.Category.Category> GetCategoryByIdAsync(int categoryId);
    Task<IEnumerable<Models.Category.Category>> GetAllCategoriesAsync();
    Task UpdateCategoryAsync(Models.Category.Category category);
    Task DeleteCategoryAsync(int categoryId);
}
