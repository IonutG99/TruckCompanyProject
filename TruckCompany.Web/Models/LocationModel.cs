using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckCompany.Web.Models
{
    public class LocationModel
    {
        public LocationModel(DomainEntities.Location location)
        {
            Id = location.Id;
            Name = location.Name;
        }
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
