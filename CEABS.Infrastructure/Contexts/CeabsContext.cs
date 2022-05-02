using CEABS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CEABS.Infrastructure.Contexts
{
    public class CeabsContext : DbContext
    {

        public CeabsContext(DbContextOptions<CeabsContext> options) : base(options)
        {
            try
            {
                if(Database?.GetAppliedMigrations()?.ToList()?.Count == 0)
                    Database?.Migrate();    
            }
            catch (Exception)
            {
            }
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ModelCar> ModelCars { get; set; }

        public DbSet<Producer> Producers { get; set; }

    }
}
