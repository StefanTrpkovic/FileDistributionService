namespace Domain.Entities
{
    public class Version
    {
        public int Id { get; set; }
        public int VersionCode { get; set; }
        public ICollection<SoftwareVersion> SoftwareVersions { get; set; }
        public ICollection<ClientSoftwareVersion> ClientSoftwares { get; set; }

    }
}
