using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckCompany.DomainEntities;

namespace TruckCompany.DataAccess.SqlServer.Mappings
{
    class TruckerMapping:IEntityTypeConfiguration<Trucker>
    {
        public void Configure(EntityTypeBuilder<Trucker> builder)
        {
            builder.ToTable("Truckers")
                .HasKey(r => r.Id);
        }
    }
}
