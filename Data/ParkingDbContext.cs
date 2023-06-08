using Microsoft.EntityFrameworkCore;
using ParkingSystemApi.Models;

namespace ParkingSystemApi.Data
{
    public class ParkingDbContext : DbContext
    {
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Owner> owners { get; set; }
        public DbSet<ParkingHistory> parking_histories { get; set; }
        public DbSet<VehicleType> vehicle_types { get; set; }

        public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Owner)
                .WithMany(o => o.Vehicles)
                .HasForeignKey(v => v.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleType)
                .WithMany()
                .HasForeignKey(v => v.VehicleTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ParkingHistory>()
                .HasOne(ph => ph.Vehicle)
                .WithMany(v => v.ParkingHistories)
                .HasForeignKey(ph => ph.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ParkingHistory>()
                .Property(ph => ph.CheckInTime)
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            modelBuilder.Entity<ParkingHistory>()
                .Property(ph => ph.CheckOutTime)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<VehicleType>()
                .HasMany(vt => vt.Vehicles)
                .WithOne(v => v.VehicleType)
                .HasForeignKey(v => v.VehicleTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=parking-system;Username=postgres;Password=28April1998");
        }
    }
}