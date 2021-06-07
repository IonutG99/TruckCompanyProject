using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TruckCompany.DomainEntities;

namespace TruckCompany.Web
{
    class StatusMapping:IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Statuses")
                .HasKey(r => r.Id);
        }
    }
}
