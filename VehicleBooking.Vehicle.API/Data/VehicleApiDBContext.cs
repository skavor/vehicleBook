using Microsoft.EntityFrameworkCore;
using VehiculeAPI.Models;

namespace VehiculeAPI.Data
{
    public class VehicleApiDBContext: DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=VehiclesDB");
        }
    }
}
