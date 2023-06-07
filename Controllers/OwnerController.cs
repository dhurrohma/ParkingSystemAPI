using Microsoft.AspNetCore.Mvc;
using ParkingSystemApi.Models;
using ParkingSystemApi.Service;

namespace ParkingSystemApi.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public IActionResult GetOwners()
        {
            var owners = _ownerService.GetAllOwners();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public IActionResult GetOwnerById(int id)
        {
            var owner = _ownerService.GetOwnerById(id);
            if(owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        [HttpPost("add")]
        public IActionResult CreateOwner(Owner owner)
        {
            var createdOwner = _ownerService.CreateOwner(owner);
            return CreatedAtAction(nameof(GetOwnerById), new { id = createdOwner.Id }, createdOwner);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateOwner(int id, Owner owner)
        {
            var findOwner = GetOwnerById(id);
            if (findOwner == null)
            {
                return NotFound();
            }

            var updatedOwner = _ownerService.UpdateOwner(id, owner);

            return Ok(updatedOwner);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteOwner(int id)
        {
            var deletedOwner = _ownerService.DeleteOwner(id);
            if (deletedOwner == null)
            {
                return NotFound();
            }

            return Ok("Success delete owner "+id);
        }
    }
}