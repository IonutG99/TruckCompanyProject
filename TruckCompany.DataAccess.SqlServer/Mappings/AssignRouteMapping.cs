using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckCompany.DomainEntities;

namespace TruckCompany.DataAccess.SqlServer.Mappings
{
    class AssignRouteMapping:IEntityTypeConfiguration<AssignRoute>
    {
        public void Configure(EntityTypeBuilder<AssignRoute> builder)
        {
            builder.ToTable("AssignedRoutes")
                 .HasKey(_=>_.RouteNumber);

            builder.Property(_ => _.RouteNumber).IsRequired();
        }
    }
}
