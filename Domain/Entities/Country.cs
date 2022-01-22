namespace Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<SoftwareCountry> SoftwareCountries { get; set; }
    }
}
