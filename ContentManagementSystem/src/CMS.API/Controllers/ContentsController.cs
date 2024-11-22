using CMS.Domain.DTOs.Content;
using CMS.Domain.Services.Content;
using CMS.Shared.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContentsController : CustomBaseController
{
    private readonly IContentService _contentService;

    public ContentsController(IContentService contentService)
    {
        _contentService = contentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetContentById(Guid contentId)
    {
        return ActionResultInstance(await _contentService.GetContentByIdAsync(contentId));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContentsAsync()
    {
        return ActionResultInstance(await _contentService.GetAllContentsAsync());
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> AddContent(Guid userId, [FromBody]ContentDto contentDto)
    {
        return ActionResultInstance(await _contentService.AddContentAsync(userId, contentDto));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContent(Guid contentId,ContentDto contentDto)
    {
        return ActionResultInstance(await _contentService.UpdateContentAsync(contentId, contentDto));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContentAsync(Guid contentId)
    {
        return ActionResultInstance(await _contentService.DeleteContentAsync(contentId));
    }

    [HttpGet]
    public async Task<IActionResult> GetContentVariants(Guid contentId)
    {
        return ActionResultInstance(await _contentService.GetContentVariantsAsync(contentId));
    }

    [HttpGet]
    public async Task<IActionResult> GetContentsByCategoryAsync(Guid categoryId)
    {
        return ActionResultInstance(await _contentService.GetContentsByCategoryAsync(categoryId));
    }

    [HttpGet]
    public async Task<IActionResult> GetContentByTitleAsync(string title)
    {
        return ActionResultInstance(await _contentService.GetContentByTitleAsync(title));
    }

    [HttpGet]
    public async Task<IActionResult> GetContentsByLanguageAsync(string language)
    {
        return ActionResultInstance(await _contentService.GetContentsByLanguageAsync(language));
    }

}
