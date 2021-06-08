using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckCompany.Web.Models
{
    public class TruckerModel
    {
        public TruckerModel(DomainEntities.Trucker trucker)
        {
            Id = trucker.Id;
            FirstName = trucker.FirstName;
            LastName = trucker.LastName;
            PhoneNumber = trucker.PhoneNumber;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
