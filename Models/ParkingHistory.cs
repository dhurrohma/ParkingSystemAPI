namespace ParkingSystemApi.Models
{
    public class ParkingHistory
    {
        public int Id { get; set; }
        public DateTimeOffset CheckInTime { get; set; }
        public DateTimeOffset? CheckOutTime { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}