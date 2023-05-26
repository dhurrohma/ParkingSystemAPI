using Microsoft.EntityFrameworkCore;
using ParkingSystemApi.Models;

namespace ParkingSystemApi.Data
{
    public class ParkingDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<ParkingHistory> ParkingHistories { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Owner)
                .WithOne(o => o.Vehicle)
                .HasForeignKey<Owner>(o => o.VehicleId);

            modelBuilder.Entity<ParkingHistory>()
                .HasOne(ph => ph.Vehicle)
                .WithMany(v => v.ParkingHistories)
                .HasForeignKey(ph => ph.VehicleId);

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.VehicleTypes)
                .WithMany(vt => vt.Vehicles)
                .UsingEntity<Dictionary<string, object>>(
                    "VehicleVehicleType",
                    j => j
                        .HasOne<VehicleType>()
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .HasConstraintName("FK_VehicaleVehicaleType_VehicleTypes_VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Vehicle>()
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .HasConstraintName("FK_VehicleVehicleType_Vehicles_VehicleId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("VehicleId", "VehicleTypeId");
                        j.HasIndex("VehicleTypeId").IsUnique(false);
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=parking_system;Username=postgres;Password=28April1998");
        }
    }
}