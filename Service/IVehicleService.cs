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
    }
}