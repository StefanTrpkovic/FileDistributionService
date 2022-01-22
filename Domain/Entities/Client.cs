namespace Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<ClientSoftware> ClientSoftwares { get; set; }
        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}