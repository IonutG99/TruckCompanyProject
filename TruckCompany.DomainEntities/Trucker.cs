using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TruckCompany.DomainEntities
{
    public class Trucker
    {
        public Trucker()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
