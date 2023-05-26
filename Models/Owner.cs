using System;

namespace ParkingSystemApi.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
