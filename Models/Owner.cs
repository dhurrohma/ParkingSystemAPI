using System.ComponentModel.DataAnnotations;

namespace ParkingSystemApi.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
