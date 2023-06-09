using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystemApi.Models
{
    public class ParkingHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CheckInTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CheckOutTime { get; set; }

        
    }
}