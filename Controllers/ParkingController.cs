using Microsoft.AspNetCore.Mvc;
using ParkingSystemApi.Models;
using ParkingSystemApi.Service;

namespace ParkingSystemApi.Controllers
{
    [ApiController]
    [Route("api/parking")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingHistoryService _parkingHistoryService;
        private readonly IInvoiceService _invoiceService;
        
        public ParkingController(IParkingHistoryService parkingHistoryService, IInvoiceService invoiceService)
        {
            _parkingHistoryService = parkingHistoryService;
            _invoiceService = invoiceService;
        }

        private int slot = 10;

        [HttpPost("checkin/{vehicleId}")]
        public IActionResult CheckIn(int vehicleId)
        {
            var existingParkingHistory = _parkingHistoryService.GetParkingHistoryByVehicleId(vehicleId);
            var stillParking = existingParkingHistory.FirstOrDefault(ph => ph.CheckOutTime == null);
            if (stillParking != null)
            {
                return BadRequest("Failed to check in because the vehicle was parked");
            }
            
            var parkingHistories = _parkingHistoryService.GetAllParkingHistories();
            int countVehiclesParking = parkingHistories.Count(ph => ph.CheckOutTime == null);
            if (countVehiclesParking >= slot)
            {
                return BadRequest("The parking lot was full");
            }

            var checkIn = new ParkingHistory
            {
                VehicleId = vehicleId,
                CheckInTime = DateTime.UtcNow.AddHours(7)
            };
            var parking = _parkingHistoryService.CreateParkingHistory(checkIn);
            return Ok(parking);
        }

        [HttpPut("checkout/{id}")]
        public IActionResult UpdateParkingHistory(int id)
        {
            ParkingHistory parkingHistory = _parkingHistoryService.GetParkingHistoryById(id);
            if (parkingHistory == null)
            {
                return NotFound();
            }

            if (parkingHistory.CheckOutTime != null)
            {
                return BadRequest("The vehicle has already checked out");
            }

            parkingHistory.CheckOutTime = DateTime.UtcNow.AddHours(7);

            var updatedHistory = _parkingHistoryService.UpdateParkingHistory(parkingHistory);          

            if (updatedHistory == null)
            {
                return BadRequest("Failed to check out");
            }

            var totalHours = (int)Math.Ceiling((updatedHistory.CheckOutTime.Value - updatedHistory.CheckInTime.Value).TotalHours);
            var totalAmount = totalHours * 2000;

            var invoice = new Invoice
            {
                ParkingHistoryId = updatedHistory.Id,
                TotalAmount = totalAmount,
                CreatedAt = DateTime.UtcNow.AddHours(7),
                PaidAt = null,
                ParkingHistory = _parkingHistoryService.GetParkingHistoryById(updatedHistory.Id)
            };

            var createInvoice = _invoiceService.CreateInvoice(invoice);

            if (createInvoice == null)
            {
                return BadRequest("Failed to create invoice");
            }

            return Ok(createInvoice);
        }

        [HttpPut("payment")]
        public IActionResult Payment([FromQuery] int invoiceId, [FromQuery] decimal money)
        {
            var invoice = _invoiceService.GetInvoiceById(invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }

            if (invoice.PaidAt != null)
            {
                return BadRequest("Invoice has been paid");
            }

            var changeAmount = money - invoice.TotalAmount;
            if (changeAmount < 0)
            {
                return BadRequest("Your money is lacking. Your bill is "+invoice.TotalAmount);
            }

            invoice.PaidAt = DateTime.UtcNow.AddHours(7);
            var paymentInvoice = _invoiceService.Payment(invoice);
            
            var printInvoice = new
            {
                Invoice = paymentInvoice,
                YourMoney = money,
                TotalChange = changeAmount
            };

            return Ok(printInvoice);
        }
    }
}