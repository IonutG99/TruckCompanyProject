using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckCompany.Web.Models
{
    public class RouteView
    {
        public RouteView(int rn,string tn,string ln,string sn)
        {
            RouteNumber = rn;
            TruckerName = tn;
            LocationName = ln;
            StatusName = sn;
        }
        public int RouteNumber { get; set; }
        public string TruckerName { get; set; }
        public string LocationName { get; set; }

        public string StatusName { get; set; }
    }
}
