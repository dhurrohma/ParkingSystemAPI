using System.Collections.Generic;
using System.Linq;
using ParkingSystemApi.Models;
using ParkingSystemApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ParkingSystemApi.Repository
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly ParkingDbContext _dbContext;

        public VehicleTypeRepository(ParkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public VehicleType AddVehicleType(VehicleType vehicleType)
        {
            _dbContext.vehicle_types.Add(vehicleType);
            _dbContext.SaveChanges();
            return vehicleType;
        }

        public VehicleType DeleteVehicleType(int id)
        {
            var vehicleType = _dbContext.vehicle_types.FirstOrDefault(vt => vt.Id == id);
            if (vehicleType != null)
            {
                _dbContext.vehicle_types.Remove(vehicleType);
                _dbContext.SaveChanges();
            }
            return vehicleType;
        }

        public List<VehicleType> GetAllVehicleTypes()
        {
            return _dbContext.vehicle_types
                    .Include(v => v.Vehicles)
                    .ToList();
        }

        public VehicleType GetVehicleTypeById(int id)
        {
            return _dbContext.vehicle_types
                    .Include(v => v.Vehicles)
                    .FirstOrDefault(vt => vt.Id == id);
        }

        public String UpdateVehicleType(int id, String name)
        {
            var existingVehicleType = GetVehicleTypeById(id);
            if (existingVehicleType == null)
            {
                return "Vehicle type not found";
            }
            
            existingVehicleType.Name = name;
            _dbContext.SaveChanges();
            return $"Vehicle type update successfully :\nId: {existingVehicleType.Id} \nName: {existingVehicleType.Name}";
        }
    }
}