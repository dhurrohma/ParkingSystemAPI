using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingSystemApi.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PlatNumber { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Color { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public Owner? Owner {get; set; }

        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        public virtual VehicleType? VehicleType { get; set; }

        public ICollection<ParkingHistory>? ParkingHistories { get; set; }
    }
}