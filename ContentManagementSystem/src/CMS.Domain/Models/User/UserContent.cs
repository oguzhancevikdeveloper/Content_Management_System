using CMS.Domain.Models.Content;

namespace CMS.Domain.Models.User;

public class UserContent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ContentId { get; set; } 

    public Content.Content Content { get; set; }
    public User User { get; set; }

    public UserContent()
    {
        Id = Guid.NewGuid();
    }   
}
