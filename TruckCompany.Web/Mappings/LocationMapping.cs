using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TruckCompany.DomainEntities;

namespace TruckCompany.Web
{
    class LocationMapping: IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations")
                 .HasKey(r => r.Id);
        }
    }
}
