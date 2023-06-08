using ParkingSystemApi.Models;

namespace ParkingSystemApi.Service
{
    public interface IVehicleService
    {
        Vehicle GetVehicleById(int id);
        List<Vehicle> GetAllVehicles();
        Vehicle CreateVehicle(Vehicle vehicle);
        String UpdateVehicle(int id, Vehicle vehicle);
        Vehicle DeleteVehicle(int id);
        List<Vehicle> GetVehicleByPlatNumber(String platNumber);
        List<Vehicle> GetVehicleByType(String type);
        List<Vehicle> GetVehicleByColor(String color);
        List<Vehicle> GetVehicleByOwnerId(int ownerId);
        List<Vehicle> GetVehicleByVehicleTypeId(int vehicleTypeId);
    }
}