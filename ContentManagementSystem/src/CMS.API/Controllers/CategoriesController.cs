using CMS.Domain.DTOs.Category;
using CMS.Domain.Services.Category;
using CMS.Shared.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : CustomBaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid categoryId)
    {
        return ActionResultInstance(await _categoryService.GetCategoryByIdAsync(categoryId));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        return ActionResultInstance(await _categoryService.GetAllCategoriesAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddCategoryAsync(CategoryDto categoryDto)
    {
        return ActionResultInstance(await _categoryService.AddCategoryAsync(categoryDto));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategoryAsync(Guid categoryId, CategoryDto categoryDto)
    {
        return ActionResultInstance(await _categoryService.UpdateCategoryAsync(categoryId,categoryDto));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategoryAsync(Guid categoryId)
    {
        return ActionResultInstance(await _categoryService.DeleteCategoryAsync(categoryId));
    }
}
