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
        var vehicles = _dbContext.Vehicles.Include(v => v.Owner).Include(v => v.VehicleTypes).ToList();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public IActionResult GetVehicleById(int id)
    {
        var vehicle = _dbContext.Vehicles.Include(v => v.Owner).Include(v => v.VehicleTypes).FirstOrDefault(v => v.Id == id);
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

    [HttpPut("{id}")]
    public IActionResult UpdateVehicle(int id, Vehicle updatedVehicle)
    {
        var vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle == null)
        {
            return NotFound();
        }
        vehicle.PlatNumber = updatedVehicle.PlatNumber;
        vehicle.Type = updatedVehicle.Type;
        vehicle.Color = updatedVehicle.Color;
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
