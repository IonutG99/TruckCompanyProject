using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TruckCompany.DomainEntities
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
