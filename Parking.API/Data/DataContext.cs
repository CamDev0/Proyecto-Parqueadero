using Microsoft.EntityFrameworkCore;
using Parking.Shared.Entities;

namespace Parking.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {
            
        }
       
        public DbSet<User> Users { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Plate> Plates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Hace que cada columna sea únicos
            modelBuilder.Entity<User>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Plate>().HasIndex(c => c.Name).IsUnique();
        }



    }
}
