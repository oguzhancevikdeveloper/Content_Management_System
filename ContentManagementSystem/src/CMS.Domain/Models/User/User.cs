namespace CMS.Domain.Models.User;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public ICollection<UserContent> UserContents { get; set; }
}
