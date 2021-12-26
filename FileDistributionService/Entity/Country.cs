﻿namespace FileDistributionService.Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
