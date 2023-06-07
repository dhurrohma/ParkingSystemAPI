using System.Collections.Generic;
using System.Linq;
using ParkingSystemApi.Models;
using ParkingSystemApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ParkingSystemApi.Repository
{
    public class ParkingHistoryRepository : IParkingHistoryRepository
    {
        private readonly ParkingDbContext _dbContext;

        public ParkingHistoryRepository(ParkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ParkingHistory AddParkingHistory(ParkingHistory parkingHistory)
        {
            _dbContext.parking_histories.Add(parkingHistory);
            _dbContext.SaveChanges();
            return parkingHistory;
        }

        public ParkingHistory DeleteParkingHistory(int id)
        {
            var parkingHistory = _dbContext.parking_histories.FirstOrDefault(ph => ph.Id == id);
            if (parkingHistory != null)
            {
                _dbContext.parking_histories.Remove(parkingHistory);
                _dbContext.SaveChanges();
            }
            return parkingHistory;
        }

        public List<ParkingHistory> GetAllParkingHistories()
        {
            return _dbContext.parking_histories
                        .Include(p => p.Vehicle)
                        .ToList();
        }

        public ParkingHistory GetParkingHistoryById(int id)
        {
            return _dbContext.parking_histories.FirstOrDefault(ph => ph.Id == id);
        }

        public ParkingHistory UpdateParkingHistory(ParkingHistory parkingHistory)
        {
            _dbContext.parking_histories.Update(parkingHistory);
            _dbContext.SaveChanges();
            return parkingHistory;
        }
    }
}