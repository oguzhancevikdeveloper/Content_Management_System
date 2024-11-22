using CMS.Domain.Models.User;

namespace CMS.Domain.Models.Content;

public class ContentVariant
{
    public Guid Id { get; set; } 
    public string Variant { get; set; } 
    public Guid ContentId { get; set; } 
    public Content Content { get; set; }


    public ContentVariant()
    {
        Id = Guid.NewGuid();
    }
}
