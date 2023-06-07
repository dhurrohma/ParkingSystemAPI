using ParkingSystemApi.Models;

namespace ParkingSystemApi.Repository
{
    public interface IVehicleTypeRepository
    {
        VehicleType GetVehicleTypeById(int id);
        List<VehicleType> GetAllVehicleTypes();
        VehicleType AddVehicleType(VehicleType vehicleType);
        String UpdateVehicleType(int id, String name);
        VehicleType DeleteVehicleType(int id);
    }
}