using ParkingSystemApi.Models;

namespace ParkingSystemApi.Service
{
    public interface IVehicleTypeService
    {
        VehicleType GetVehicleTypeById(int id);
        List<VehicleType> GetAllVehicleTypes();
        VehicleType CreateVehicleType(VehicleType vehicleType);
        String UpdateVehicleType(int id, String name);
        VehicleType DeleteVehicleType(int id);
        List<VehicleType> GetVehicleTypeByName(String name);
    }
}