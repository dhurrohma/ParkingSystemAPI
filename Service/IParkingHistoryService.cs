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
    }
}