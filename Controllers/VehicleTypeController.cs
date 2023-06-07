using Microsoft.AspNetCore.Mvc;
using ParkingSystemApi.Models;
using ParkingSystemApi.Service;

namespace ParkingSystemApi.Controllers
{
    [ApiController]
    [Route("api/vehicletypes")]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        public IActionResult GetVehicleTypes()
        {
            var vehicleType = _vehicleTypeService.GetAllVehicleTypes();
            return Ok(vehicleType);
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleTypeById(int id)
        {
            var vehicleType = _vehicleTypeService.GetVehicleTypeById(id);
            if(vehicleType == null)
            {
                return NotFound();
            }
            return Ok(vehicleType);
        }

        [HttpGet("name")]
        public IActionResult GetVehicleTypeByName([FromQuery] String name)
        {
            var vehicleType = _vehicleTypeService.GetVehicleTypeByName(name);
            if(vehicleType == null)
            {
                return NotFound();
            }
            return Ok(vehicleType);
        }        

        [HttpPost("add")]
        public IActionResult CreateVehicleType(VehicleType vehicleType)
        {
            var createdVehicleType = _vehicleTypeService.CreateVehicleType(vehicleType);
            return CreatedAtAction(nameof(GetVehicleTypeById), new { id = createdVehicleType.Id }, createdVehicleType);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateVehicleType(int id, [FromQuery] String name)
        {
            var findVehicleType = GetVehicleTypeById(id);
            if (findVehicleType == null)
            {
                return NotFound();
            }

            var updatedVehicleType = _vehicleTypeService.UpdateVehicleType(id, name);

            return Ok(updatedVehicleType);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteVehicleType(int id)
        {
            var deletedVehicleType = _vehicleTypeService.DeleteVehicleType(id);
            if (deletedVehicleType == null)
            {
                return NotFound();
            }

            return Ok("Success delete vehicle type "+id);
        }
    }
}