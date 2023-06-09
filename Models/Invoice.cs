using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystemApi.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ParkingHistoryId { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? PaidAt { get; set; }

        public virtual ParkingHistory? ParkingHistory { get; set; }
    }
}