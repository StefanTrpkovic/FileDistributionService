﻿namespace FileDistributionService.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<ClientSoftware> ClientSoftwares { get; set; }
    }
}