namespace Domain.Entities
{
    public class Channel : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Software> Softwares { get; set; }

    }
}
