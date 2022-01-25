namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IClientRepository ClientRepository { get; }
        ISoftwareRepository SoftwareRepository { get; }
        IUpdateRepository UpdateRepository { get; } 
    }
}
