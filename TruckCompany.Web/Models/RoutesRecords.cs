using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckCompany.Web.Models
{
    public class RoutesRecords
    {
        public List<int> RouteNumbers { get; set; }

        public List<string> TruckerFirstName { get; set; }

        public List<string> LocationName { get; set; }

        public List<string> StatusName { get; set; }
    }
}
