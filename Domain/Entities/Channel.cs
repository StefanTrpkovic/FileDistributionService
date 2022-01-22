namespace Domain.Entities
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<SoftwareChannel> SoftwareChannels { get; set; }

    }
}
