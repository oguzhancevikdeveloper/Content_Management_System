using CMS.Domain.DTOs.Category;
using CMS.Domain.Repositories.Category;
using CMS.Domain.Services.Category;
using CMS.Shared.DTOs;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace CMS.Application.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Response<NoDataDto>> AddCategoryAsync(CategoryDto categoryDto)
    {
        var category = categoryDto.Adapt<Domain.Models.Category.Category>();
        await _categoryRepository.AddCategoryAsync(category); 

        return Response<NoDataDto>.Success(StatusCodes.Status201Created);
    }

    public async Task<Response<NoDataDto>> DeleteCategoryAsync(Guid categoryId)
    {
        var existingCategory = await _categoryRepository.GetCategoryByIdAsync(categoryId);  
        if (existingCategory == null) return Response<NoDataDto>.Fail("Category not found", StatusCodes.Status404NotFound,true);       
        await _categoryRepository.DeleteCategoryAsync(categoryId); 

        return Response<NoDataDto>.Success(StatusCodes.Status200OK);
    }

    public async Task<Response<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        if (categories == null || !categories.Any()) return Response<IEnumerable<CategoryDto>>.Fail("No categories found",StatusCodes.Status404NotFound,true);        
        var categoryDtos = categories.Adapt<IEnumerable<CategoryDto>>();  

        return Response<IEnumerable<CategoryDto>>.Success(categoryDtos, StatusCodes.Status200OK); 
    }

    public async Task<Response<CategoryDto>> GetCategoryByIdAsync(Guid categoryId)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(categoryId); 
        if (category == null) return Response<CategoryDto>.Fail("Category not found", StatusCodes.Status404NotFound,true);        
        var categoryDto = category.Adapt<CategoryDto>();  

        return Response<CategoryDto>.Success(categoryDto, StatusCodes.Status200OK);
    }

    public async Task<Response<NoDataDto>> UpdateCategoryAsync(Guid categoryId, CategoryDto categoryDto)
    {
        var existingCategory = await _categoryRepository.GetCategoryByIdAsync(categoryId);  
        if (existingCategory == null) return Response<NoDataDto>.Fail("Category not found", StatusCodes.Status404NotFound,true);      
        existingCategory = categoryDto.Adapt(existingCategory);  
        await _categoryRepository.UpdateCategoryAsync(existingCategory);  

        return Response<NoDataDto>.Success(StatusCodes.Status200OK);
    }
}
