namespace FileDistributionService.Entity
{
    public class SoftwareVersion
    {
        public int SoftwareId { get; set; }
        public Software Software { get; set; }

        public int VersionId { get; set; }
        public SoftVersion SoftVersion { get; set; }
    }
}
