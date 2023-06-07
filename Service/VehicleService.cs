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

        public Vehicle GetVehicleById(int id)
        {
            return _vehicleRepository.GetVehicleById(id);
        }

        public String UpdateVehicle(int id, Vehicle vehicle)
        {
            return _vehicleRepository.UpdateVehicle(id, vehicle);
        }
    }
}