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
    }
}