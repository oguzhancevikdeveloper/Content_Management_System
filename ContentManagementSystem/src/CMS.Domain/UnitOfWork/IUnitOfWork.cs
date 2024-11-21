namespace CMS.Domain.UnitOfWork;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Commit();
}
