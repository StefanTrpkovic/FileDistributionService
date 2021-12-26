namespace FileDistributionService.Entity
{
    public class SoftwareType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Software> Softwares { get; set; }
    }
}
