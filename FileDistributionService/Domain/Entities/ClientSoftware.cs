namespace Domain.Entities
{
    public class ClientSoftware
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int SoftwareId { get; set; }
        public Software Software { get; set; }
    }
}
