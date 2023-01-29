namespace SharedTrip.Data
{
    using SharedTrip.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class SharedtripDbContext : DbContext
    {

        public DbSet<User> Users { get; init; }

        public DbSet<Trip> Trip { get; init; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SharedTrip;Integrated Security=true;");
            }
        }
    }
}
