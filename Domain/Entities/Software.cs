namespace Domain.Entities
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClientSoftwareVersion> ClientSoftwares { get; set; }
        public ICollection<SoftwareChannel> SoftwareChannels { get; set; }
        public ICollection<SoftwareVersion> SoftwareVersions { get; set; }
        public int SoftwareTypeId { get; set; }
        public SoftwareType SoftwareType { get; set; }
        public ICollection<SoftwareCountry> SoftwareCountries { get; set; }
        public Guid PackageVersion { get; set; }

    }
}
