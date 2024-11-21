using CMS.Domain.Models.User;

namespace CMS.Domain.Models.Content;

public class ContentVariant
{
    public int Id { get; set; } 
    public string Variant { get; set; } 
    public int ContentId { get; set; } 
    public Content Content { get; set; }
    public ICollection<UserContent> UserContents { get; set; }
}
