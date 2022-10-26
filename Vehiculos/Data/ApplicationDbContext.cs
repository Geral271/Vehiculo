
using Microsoft.EntityFrameworkCore;
using Vehiculos.Entidades;

namespace Vehiculos.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Document_Type> Document_Types { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Vehicle_Photo> Vehicle_Photos { get; set; }
        public DbSet<Vehicle_Type> Vehicle_Types { get; set; }

    }
}
