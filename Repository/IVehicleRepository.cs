using ParkingSystemApi.Models;

namespace ParkingSystemApi.Repository
{
    public interface IVehicleRepository
    {
        Vehicle GetVehicleById(int id);
        List<Vehicle> GetAllVehicles();
        Vehicle AddVehicle(Vehicle vehicle);
        String UpdateVehicle(int id, Vehicle vehicle);
        Vehicle DeleteVehicle(int id);
        List<Vehicle> GetVehicleByPlatNumber(String platNumber);
        List<Vehicle> GetVehicleByType(String type);
        List<Vehicle> GetVehicleByColor(String color);
        List<Vehicle> GetVehicleByOwnerId(int ownerId);
        List<Vehicle> GetVehicleByVehicleTypeId(int vehicleTypeId);
    }
}