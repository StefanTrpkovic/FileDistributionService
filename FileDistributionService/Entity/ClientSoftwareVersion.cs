namespace FileDistributionService.Entity
{
    public class ClientSoftwareVersion
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int SoftwareId { get; set; }
        public Software Software { get; set; }

        public int VersionId { get; set; }
        public Version Version { get; set; }
    }
}
