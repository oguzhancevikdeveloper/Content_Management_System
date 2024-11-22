namespace CMS.Domain.Repositories.User;

public interface IUserContentRepository
{
    Task AddUserContentAsync(Models.User.UserContent  userContent);

}
