using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckCompany.DomainEntities
{
    public class AssignRoute
    {
        public AssignRoute()
        {
            Random random = new Random();
            int nr = random.Next();
            RouteNumber = nr;
        }
        [Key]
        public int RouteNumber { get; set; }
        [ForeignKey("Truckers")]
        public Guid TruckerId { get; set; }
        [ForeignKey("Locations")]
        public int LocationId { get; set; }
        [ForeignKey("Statuses")]
        public int StatusId { get; set; }
    }

   
}
