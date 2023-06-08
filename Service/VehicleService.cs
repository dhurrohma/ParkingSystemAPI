using System.Collections.Generic;
using ParkingSystemApi.Models;
using ParkingSystemApi.Repository;

namespace ParkingSystemApi.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            return _vehicleRepository.AddVehicle(vehicle);
        }

        public Vehicle DeleteVehicle(int id)
        {
            return _vehicleRepository.DeleteVehicle(id);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAllVehicles();
        }

        public List<Vehicle> GetVehicleByColor(string color)
        {
            return _vehicleRepository.GetVehicleByColor(color);
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicleRepository.GetVehicleById(id);
        }

        public List<Vehicle> GetVehicleByOwnerId(int ownerId)
        {
            return _vehicleRepository.GetVehicleByOwnerId(ownerId);
        }

        public List<Vehicle> GetVehicleByPlatNumber(string platNumber)
        {
            return _vehicleRepository.GetVehicleByPlatNumber(platNumber);
        }

        public List<Vehicle> GetVehicleByType(string type)
        {
            return _vehicleRepository.GetVehicleByType(type);
        }

        public List<Vehicle> GetVehicleByVehicleTypeId(int vehicleTypeId)
        {
            return _vehicleRepository.GetVehicleByVehicleTypeId(vehicleTypeId);
        }

        public String UpdateVehicle(int id, Vehicle vehicle)
        {
            return _vehicleRepository.UpdateVehicle(id, vehicle);
        }
    }
}