using System;
using System.Collections.Generic;
using System.Text;

namespace TruckCompany.DomainEntities
{
    public class AssignRoute
    {   
        public int RouteNumber { get; set; }
        public  Guid TruckerId { get; set; }

        public int LocationId { get; set; }

        public int StatusId { get; set; }
    }

   
}
