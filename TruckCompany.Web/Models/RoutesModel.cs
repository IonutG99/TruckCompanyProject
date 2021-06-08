using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TruckCompany.Web.Models
{
    public class RoutesModel
    {
        public RoutesModel()
        {

        }
        public RoutesModel(DomainEntities.AssignRoute route)
        {
            RouteNumber = route.RouteNumber;
            TruckerId = route.TruckerId;
            LocationId = route.LocationId;
            StatusId = route.StatusId;
        }
        public int RouteNumber { get; set; }
        [ForeignKey("Truckers")]
        public Guid TruckerId { get; set; }
        [ForeignKey("Locations")]
        public int LocationId { get; set; }
        [ForeignKey("Statuses")]
        public int StatusId { get; set; }
    }
}
