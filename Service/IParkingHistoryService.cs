using ParkingSystemApi.Models;

namespace ParkingSystemApi.Service
{
    public interface IParkingHistoryService
    {
        ParkingHistory GetParkingHistoryById(int id);
        List<ParkingHistory> GetAllParkingHistories();
        ParkingHistory CreateParkingHistory(ParkingHistory parkingHistory);
        ParkingHistory UpdateParkingHistory(ParkingHistory parkingHistory);
        ParkingHistory DeleteParkingHistory(int id);
        List<ParkingHistory> GetParkingHistoryByVehicleId(int vehicleId);
        List<ParkingHistory> GetParkingHistoryByCheckInTime(DateTime start, DateTime end);
        List<ParkingHistory> GetParkingHistoryByCheckOutTime(DateTime start, DateTime end);
    }
}