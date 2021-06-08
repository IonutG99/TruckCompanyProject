using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckCompany.Web.Models
{
    public class CreateModel
    {
        public RouteModel Route { get; set; }

        public IEnumerable<DomainEntities.Trucker> Truckers { get; set; }
        public IEnumerable<DomainEntities.Status> Statuses { get; set; }
        public IEnumerable<DomainEntities.Location> Locations {get;set;} 
    }
}
