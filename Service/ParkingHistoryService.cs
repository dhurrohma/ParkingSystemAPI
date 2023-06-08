using System.Collections.Generic;
using ParkingSystemApi.Models;
using ParkingSystemApi.Repository;

namespace ParkingSystemApi.Service
{
    public class ParkingHistoryService : IParkingHistoryService
    {
        private readonly IParkingHistoryRepository _parkingHistoryRepository;

        public ParkingHistoryService(IParkingHistoryRepository parkingHistoryRepository)
        {
            _parkingHistoryRepository = parkingHistoryRepository;
        }

        public ParkingHistory CreateParkingHistory(ParkingHistory parkingHistory)
        {
            return _parkingHistoryRepository.AddParkingHistory(parkingHistory);
        }

        public ParkingHistory DeleteParkingHistory(int id)
        {
            return _parkingHistoryRepository.DeleteParkingHistory(id);
        }

        public List<ParkingHistory> GetAllParkingHistories()
        {
            return _parkingHistoryRepository.GetAllParkingHistories();
        }

        public List<ParkingHistory> GetParkingHistoryByCheckInTime(DateTime start, DateTime end)
        {
            return _parkingHistoryRepository.GetParkingHistoryByCheckInTime(start, end);
        }

        public List<ParkingHistory> GetParkingHistoryByCheckOutTime(DateTime start, DateTime end)
        {
            return _parkingHistoryRepository.GetParkingHistoryByCheckOutTime(start, end);
        }

        public ParkingHistory GetParkingHistoryById(int id)
        {
            return _parkingHistoryRepository.GetParkingHistoryById(id);
        }

        public List<ParkingHistory> GetParkingHistoryByVehicleId(int vehicleId)
        {
            return _parkingHistoryRepository.GetParkingHistoryByVehicleId(vehicleId);
        }

        public ParkingHistory UpdateParkingHistory(ParkingHistory parkingHistory)
        {
            return _parkingHistoryRepository.UpdateParkingHistory(parkingHistory);
        }
    }
}