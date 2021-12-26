namespace FileDistributionService.Entity
{
    public class SoftwareChannel
    {
        public int SoftwareId { get; set; }
        public Software Software { get; set; }

        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}
