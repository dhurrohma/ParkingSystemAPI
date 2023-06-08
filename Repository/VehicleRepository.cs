using System.Collections.Generic;
using System.Linq;
using ParkingSystemApi.Models;
using ParkingSystemApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ParkingSystemApi.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ParkingDbContext _dbContext;

        public VehicleRepository(ParkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Vehicle AddVehicle(Vehicle vehicle)
        {
            _dbContext.vehicles.Add(vehicle);
            _dbContext.SaveChanges();
            return vehicle;
        }

        public Vehicle DeleteVehicle(int id)
        {
            var vehicle = _dbContext.vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle != null)
            {
                _dbContext.vehicles.Remove(vehicle);
                _dbContext.SaveChanges();
            }
            return vehicle;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _dbContext.vehicles
                    .Include(v => v.Owner)
                    .Include(v => v.VehicleType)
                    .Include(v => v.ParkingHistories)
                    .ToList();
        }

        public List<Vehicle> GetVehicleByColor(string color)
        {
            return _dbContext.vehicles
                    .Include(v => v.Owner)
                    .Include(v => v.VehicleType)
                    .Include(v => v.ParkingHistories)
                    .Where(v => v.Color.Contains(color))
                    .ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _dbContext.vehicles
                    .Include(v => v.Owner)
                    .Include(v => v.VehicleType)
                    .Include(v => v.ParkingHistories)
                    .FirstOrDefault(v => v.Id == id);
        }

        public List<Vehicle> GetVehicleByOwnerId(int ownerId)
        {
            return _dbContext.vehicles
                    .Include(v => v.Owner)
                    .Include(v => v.VehicleType)
                    .Include(v => v.ParkingHistories)
                    .Where(v => v.OwnerId == ownerId)
                    .ToList();
        }

        public List<Vehicle> GetVehicleByPlatNumber(string platNumber)
        {
            return _dbContext.vehicles
                    .Include(v => v.Owner)
                    .Include(v => v.VehicleType)
                    .Include(v => v.ParkingHistories)
                    .Where(v => v.PlatNumber.Contains(platNumber))
                    .ToList();
        }

        public List<Vehicle> GetVehicleByType(string type)
        {
            return _dbContext.vehicles
                    .Include(v => v.Owner)
                    .Include(v => v.VehicleType)
                    .Include(v => v.ParkingHistories)
                    .Where(v => v.Type.Contains(type))
                    .ToList();
        }

        public List<Vehicle> GetVehicleByVehicleTypeId(int vehicleTypeId)
        {
            return _dbContext.vehicles
                    .Include(v => v.Owner)
                    .Include(v => v.VehicleType)
                    .Include(v => v.ParkingHistories)
                    .Where(v => v.VehicleTypeId == vehicleTypeId)
                    .ToList();
        }

        public String UpdateVehicle(int id, Vehicle vehicle)
        {
            var existingVehicle = GetVehicleById(id);
            if (existingVehicle == null)
            {
                return "Vehicle not found";
            }

            existingVehicle.PlatNumber = vehicle.PlatNumber;
            existingVehicle.Type = vehicle.Type;
            existingVehicle.Color = vehicle.Color;
            existingVehicle.OwnerId = vehicle.OwnerId;
            existingVehicle.Owner = vehicle.Owner;
            existingVehicle.VehicleTypeId = vehicle.VehicleTypeId;
            existingVehicle.VehicleType = vehicle.VehicleType;

            _dbContext.SaveChanges();
            return $"Vehicle with id {id} updated successfully";
        }
    }
}