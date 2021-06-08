using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TruckCompany.DomainEntities
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
