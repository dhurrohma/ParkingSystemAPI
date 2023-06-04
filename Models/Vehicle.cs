namespace ParkingSystemApi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string PlatNumber { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }

        public Owner Owner {get; set; }
        public List<ParkingHistory> ParkingHistories { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }
    }
}