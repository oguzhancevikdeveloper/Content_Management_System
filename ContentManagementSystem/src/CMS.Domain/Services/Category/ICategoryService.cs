using CMS.Domain.DTOs.Category;
using CMS.Shared.DTOs;

namespace CMS.Domain.Services.Category;

public interface ICategoryService
{
    Task<Response<CategoryDto>> GetCategoryByIdAsync(int categoryId);
    Task<Response<IEnumerable<CategoryDto>>> GetAllCategoriesAsync();
    Task<Response<NoDataDto>> AddCategoryAsync(CategoryDto categoryDto);
    Task<Response<NoDataDto>> UpdateCategoryAsync(int categoryId, CategoryDto categoryDto);
    Task<Response<NoDataDto>> DeleteCategoryAsync(int categoryId);
}
