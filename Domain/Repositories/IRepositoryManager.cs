namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IChannelRepository ChannelRepository { get; }
        IClientRepository ClientRepository { get; }
        IUpdateRepository UpdateRepository { get; } 
        ISoftwareRepository SoftwareRepository { get; }
    }
}
