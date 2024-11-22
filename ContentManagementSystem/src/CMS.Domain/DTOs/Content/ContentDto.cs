namespace CMS.Domain.DTOs.Content;

public class ContentDto
{
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
    public string ImageUrl { get; set; }
    public List<ContentVariantDto> contentVariantDtos { get; set; }
}
