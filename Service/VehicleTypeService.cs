using System.Collections.Generic;
using ParkingSystemApi.Models;
using ParkingSystemApi.Repository;

namespace ParkingSystemApi.Service
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public VehicleType CreateVehicleType(VehicleType vehicleType)
        {
            return _vehicleTypeRepository.AddVehicleType(vehicleType);
        }

        public VehicleType DeleteVehicleType(int id)
        {
            return _vehicleTypeRepository.DeleteVehicleType(id);
        }

        public List<VehicleType> GetAllVehicleTypes()
        {
            return _vehicleTypeRepository.GetAllVehicleTypes();
        }

        public VehicleType GetVehicleTypeById(int id)
        {
            return _vehicleTypeRepository.GetVehicleTypeById(id);
        }

        public String UpdateVehicleType(int id, String name)
        {
            return _vehicleTypeRepository.UpdateVehicleType(id, name);
        }
    }
}