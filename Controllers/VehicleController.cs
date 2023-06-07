using Microsoft.AspNetCore.Mvc;
using ParkingSystemApi.Models;
using ParkingSystemApi.Service;

namespace ParkingSystemApi.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IOwnerService _ownerService;
        private readonly IVehicleTypeService _vehicleTypeSerive;

        public VehicleController(IVehicleService vehicleService, IOwnerService ownerService, IVehicleTypeService vehicleTypeService)
        {
            _vehicleService = vehicleService;
            _ownerService = ownerService;
            _vehicleTypeSerive = vehicleTypeService;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            var vehicles = _vehicleService.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost("add")]
        public IActionResult CreateVehicle(Vehicle vehicle)
        {
            var findOwner = _ownerService.GetOwnerById(vehicle.OwnerId);
            if (findOwner == null)
            {
                return BadRequest();
            }

            var findVehicleType = _vehicleTypeSerive.GetVehicleTypeById(vehicle.VehicleTypeId);
            if (findVehicleType == null)
            {
                return BadRequest();
            }

            vehicle.Owner = findOwner;
            vehicle.VehicleType = findVehicleType;
            var createdVehicle = _vehicleService.CreateVehicle(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = createdVehicle.Id }, createdVehicle);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateVehicle(int id, Vehicle vehicle)
        {
            var findVehicle = GetVehicleById(id);
            if (findVehicle == null)
            {
                return NotFound();
            }

            var findOwner = _ownerService.GetOwnerById(vehicle.OwnerId);
            if (findOwner == null)
            {
                return BadRequest();
            }

            var findVehicleType = _vehicleTypeSerive.GetVehicleTypeById(vehicle.VehicleTypeId);
            if (findVehicleType == null)
            {
                return BadRequest();
            }

            vehicle.Owner = findOwner;
            vehicle.VehicleType = findVehicleType;
            var updatedVehicle = _vehicleService.UpdateVehicle(id, vehicle);
        
            return Ok(updatedVehicle);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var deletedVehicle = _vehicleService.DeleteVehicle(id);
            if (deletedVehicle == null)
            {
                return NotFound();
            }
            return Ok("Success delete vehicle "+id);
        }
    }

}

