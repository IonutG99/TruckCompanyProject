using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace TruckCompany.DomainEntities
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
