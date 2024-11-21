using CMS.Domain.Models.Content;

namespace CMS.Domain.Models.User;

public class UserContent
{
    public int UserId { get; set; }
    public int ContentId { get; set; } 
    public int ContentVariantId { get; set; } 

    public ContentVariant ContentVariant { get; set; }
    public Content.Content Content { get; set; }
    public User User { get; set; }
}
