namespace Domain.Entities
{
    public class Software : BaseEntity
    {
        public string Name { get; set; }
        public Guid PackageVersion { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Version { get; set; }
        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
        public ICollection<ClientSoftware> ClientSoftwares { get; set; }
        public ICollection<SoftwareCountry> SoftwareCountries { get; set; }

    }
}
