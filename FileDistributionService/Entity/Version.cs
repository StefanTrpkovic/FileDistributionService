namespace FileDistributionService.Entity
{
    public class Version
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public ICollection<SoftwareVersion> SoftwareVersions { get; set; }

    }
}
