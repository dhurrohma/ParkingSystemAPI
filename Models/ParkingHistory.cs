namespace ParkingSystemApi.Models
{
    public class ParkingHistory
    {
        public int Id { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}