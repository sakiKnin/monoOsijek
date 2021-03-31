using Microsoft.EntityFrameworkCore;
using Backend.Models;
namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }   
	protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<VehicleMake>()
            .HasIndex(a => a.Id)
            .IsUnique();

             // One-to-one: VehicleMake -> VehicleModel
             modelBuilder.Entity<VehicleModel>()
                 .HasKey(ca => new { ca.MakeId });
	}
        public DbSet<VehicleMake> VehicleMake { get; set; } 
    }
}
