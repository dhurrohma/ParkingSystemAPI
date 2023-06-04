using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingSystemApi.Data;
using ParkingSystemApi.Models;
using System.Linq;

namespace ParkingSystemApi.Controllers;

[ApiController]
[Route("api/vehicles")]
public class VehicleController : ControllerBase
{
    private readonly ParkingDbContext _dbContext;

    public VehicleController(ParkingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetVehicles()
    {
        var vehicles = _dbContext.Vehicles
            .Include(v => v.Owner)
            .Include(v => v.VehicleTypes)
            .Include(v => v.ParkingHistories)
            .ToList();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public IActionResult GetVehicleById(int id)
    {
        var vehicle = _dbContext.Vehicles
            .Include(v => v.Owner)
            .Include(v => v.VehicleTypes)
            .Include(v => v.ParkingHistories)
            .FirstOrDefault(v => v.Id == id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }

    [HttpPost]
    public IActionResult CreateVehicle(Vehicle vehicle)
    {
        _dbContext.Vehicles.Add(vehicle);
        _dbContext.SaveChanges();
        return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
    }

    [HttpGet("owners")]
    public IActionResult GetOwners()
    {
        var owners = _dbContext.Owners.ToList();
        return Ok(owners);
    }

    [HttpGet("vehicle-types")]
    public IActionResult GetVehicleTypes()
    {
        var vehicleTypes = _dbContext.VehicleTypes.ToList();
        return Ok(vehicleTypes);
    }

    [HttpGet("parking-histories")]
    public IActionResult GetParkingHistories()
    {
        var parkingHistories = _dbContext.ParkingHistories.ToList();
        return Ok(parkingHistories);
    }

    [HttpPut("parking-histories/{vehicleId}")]
    public IActionResult UpdateParkingHistory(int vehicleId, DateTime checkOutTime)
    {
        var vehicle = _dbContext.Vehicles
            .Include(v => v.ParkingHistories)
            .FirstOrDefault(v => v.Id == vehicleId);

        if (vehicle == null)
        {
            return NotFound();
        }

        var parkingHistory = vehicle.ParkingHistories.LastOrDefault();

        if (parkingHistory == null)
        {
            return NotFound();
        }

        parkingHistory.CheckOutTime = checkOutTime;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteVehicle(int id)
    {
        var vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle == null)
        {
            return NotFound();
        }
        _dbContext.Vehicles.Remove(vehicle);
        _dbContext.SaveChanges();
        return NoContent();
    }
}
