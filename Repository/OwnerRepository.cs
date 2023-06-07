using System.Collections.Generic;
using System.Linq;
using ParkingSystemApi.Models;
using ParkingSystemApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ParkingSystemApi.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ParkingDbContext _dbContext;

        public OwnerRepository(ParkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Owner AddOwner(Owner owner)
        {
            _dbContext.owners.Add(owner);
            _dbContext.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var owner = _dbContext.owners.FirstOrDefault(o => o.Id == id);
            if (owner != null)
            {
                _dbContext.owners.Remove(owner);
                _dbContext.SaveChanges();
            }
            return owner;
        }

        public List<Owner> GetAllOwners()
        {
            return _dbContext.owners
                    .Include(o => o.Vehicles)
                    .ToList();
        }

        public Owner GetOwnerById(int id)
        {
            return _dbContext.owners
                    .Include(o => o.Vehicles)
                    .FirstOrDefault(o => o.Id == id);
        }

        public String UpdateOwner(int id, Owner owner)
        {
            var existingOwner = GetOwnerById(id);
            if (existingOwner == null)
            {
                return "Owner not found";
            }

           existingOwner.Name = owner.Name;
           existingOwner.Address = owner.Address;

            _dbContext.SaveChanges();
            return $"Owner updated successfully :\nId: {existingOwner.Id} \nName: {existingOwner.Name} \nAddress: {existingOwner.Address}";
        }
    }
}