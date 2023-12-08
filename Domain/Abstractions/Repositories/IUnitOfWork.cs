namespace SeventhServers.Domain.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
