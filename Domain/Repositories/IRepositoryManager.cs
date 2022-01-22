namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IChannelRepository ChannelRepository { get; }
        IClientRepository ClientRepository { get; }
        IUpdateRepository UpdateRepository { get; } 
        IVersionRepository VersionRepository { get; }
        ISoftwareRepository SoftwareRepository { get; }
    }
}
