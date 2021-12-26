namespace FileDistributionService.Entity
{
    public class SoftVersion
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public ICollection<SoftwareVersion> SoftwareVersions { get; set; }

    }
}
