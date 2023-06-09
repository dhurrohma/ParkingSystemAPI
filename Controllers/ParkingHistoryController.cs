using Microsoft.AspNetCore.Mvc;
using ParkingSystemApi.Models;
using ParkingSystemApi.Service;

namespace ParkingSystemApi.Controllers
{
    [ApiController]
    [Route("api/parking-histories")]
    public class ParkingHistoryController : ControllerBase
    {
        private readonly IParkingHistoryService _parkingHistoryService;

        public ParkingHistoryController(IParkingHistoryService parkingHistoryService)
        {
            _parkingHistoryService = parkingHistoryService;
        }

        [HttpGet]
        public IActionResult GetParkingHistories()
        {
            var parkingHistories = _parkingHistoryService.GetAllParkingHistories();
            return Ok(parkingHistories);
        }

        [HttpGet("{id}")]
        public IActionResult GetParkingHistoryById(int id)
        {
            var parkingHistory = _parkingHistoryService.GetParkingHistoryById(id);
            if (parkingHistory == null)
            {
                return NotFound();
            }

            return Ok(parkingHistory);
        }

        [HttpGet("vehicle/{vehicleId}")]
        public IActionResult GetParkingHistoryByVehicle(int vehicleId)
        {
            var parkingHistories = _parkingHistoryService.GetParkingHistoryByVehicleId(vehicleId);
            if (parkingHistories == null)
            {
                return NotFound();
            }

            return Ok(parkingHistories);
        }        

        [HttpGet("checkInTime")]
        public IActionResult GetParkingHistoryByCheckInTime([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var parkingHistories = _parkingHistoryService.GetParkingHistoryByCheckInTime(start, end);
            if (parkingHistories == null)
            {
                return NotFound();
            }

            return Ok(parkingHistories);
        }

        [HttpGet("checkOutTime")]
        public IActionResult GetParkingHistoryByCheckOutTime([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var parkingHistories = _parkingHistoryService.GetParkingHistoryByCheckOutTime(start, end);
            if (parkingHistories == null)
            {
                return NotFound();
            }

            return Ok(parkingHistories);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteParkingHistory(int id)
        {
            var deletedParkingHistory = _parkingHistoryService.DeleteParkingHistory(id);
            if (deletedParkingHistory == null)
            {
                return NotFound();
            }

            return Ok($"Parking history {id} was successfully deleted");
        }
    }
}