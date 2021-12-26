namespace FileDistributionService.Entity
{
    public class Version
    {
        public int Id { get; set; }
        public string VersionCode { get; set; }
        public ICollection<SoftwareVersion> SoftwareVersions { get; set; }

    }
}
