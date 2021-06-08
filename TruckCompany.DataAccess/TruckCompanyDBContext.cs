using Microsoft.EntityFrameworkCore;


namespace TruckCompany.DataAccess
{
    public class TruckCompanyDBContext:DbContext
    {
        private string connectionString;

        public TruckCompanyDBContext()
        {

        }

        public TruckCompanyDBContext(string connString)
        {
            this.connectionString = connString;
        }

        public DbSet<DomainEntities.Trucker> Truckers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            var connectionString = "Data Source=desktop-2bdjm30;Initial Catalog=TruckCompany;Integrated Security=True;";
            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
