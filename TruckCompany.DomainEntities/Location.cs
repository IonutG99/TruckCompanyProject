using System;

namespace TruckCompany.DomainEntities
{
    public class Location
    {
        public Location()
        {
            Random random = new Random();
            int nr = random.Next();
            Id = nr;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
