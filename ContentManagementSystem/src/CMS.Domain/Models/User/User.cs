namespace CMS.Domain.Models.User;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public ICollection<UserContent> UserContents { get; set; }
    public User()
    {
        Id = Guid.NewGuid();
    }
}
