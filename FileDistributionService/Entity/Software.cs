namespace FileDistributionService.Entity
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClientSoftware> ClientSoftwares { get; set; }
        public ICollection<SoftwareChannel> SoftwareChannels { get; set; }
        public ICollection<SoftwareVersion> SoftwareVersions { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
