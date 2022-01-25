namespace Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<SoftwareCountry> SoftwareCountries { get; set; }
    }
}
