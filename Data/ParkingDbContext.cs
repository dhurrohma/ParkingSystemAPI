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
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Owner)
                .WithOne(o => o.Vehicle)
                .HasForeignKey<Owner>(o => o.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Owner>()
            //     .HasOne(o => o.Vehicle)
            //     .WithOne(v => v.Owner)
            //     .HasForeignKey<Vehicle>(v => v.OwnerId)
            //     .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ParkingHistory>()
                .HasOne(ph => ph.Vehicle)
                .WithMany(v => v.ParkingHistories)
                .HasForeignKey(ph => ph.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

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
            
            modelBuilder.Entity<ParkingHistory>()
                .Property(ph => ph.CheckInTime)
                .HasColumnType("timestamptz")
                .IsRequired()
                .HasConversion(
                    v => v.UtcDateTime,
                    v => new DateTimeOffset(v, TimeSpan.Zero));

            modelBuilder.Entity<ParkingHistory>()
                .Property(ph => ph.CheckOutTime)
                .HasColumnType("timestamptz")
                .HasConversion(
                    v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null,
                    v => v.HasValue ? new DateTimeOffset(v.Value, TimeSpan.Zero) : (DateTimeOffset?)null);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=parking_system;Username=postgres;Password=28April1998");
        }
    }
}