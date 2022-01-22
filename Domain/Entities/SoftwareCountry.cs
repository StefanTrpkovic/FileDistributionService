namespace Domain.Entities
{
    public class SoftwareCountry
    {
        public int SoftwareId { get; set; }
        public Software Software { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
