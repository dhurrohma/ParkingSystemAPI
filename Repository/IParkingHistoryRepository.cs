using ParkingSystemApi.Models;

namespace ParkingSystemApi.Repository
{
    public interface IParkingHistoryRepository
    {
        ParkingHistory GetParkingHistoryById(int id);
        List<ParkingHistory> GetAllParkingHistories();
        ParkingHistory AddParkingHistory(ParkingHistory parkingHistory);
        ParkingHistory UpdateParkingHistory(ParkingHistory parkingHistory);
        ParkingHistory DeleteParkingHistory(int id);
    }   
}