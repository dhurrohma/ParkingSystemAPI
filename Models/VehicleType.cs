using System.ComponentModel.DataAnnotations;

namespace ParkingSystemApi.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}