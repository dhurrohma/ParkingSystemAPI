using System.Collections.Generic;
using ParkingSystemApi.Models;
using ParkingSystemApi.Repository;

namespace ParkingSystemApi.Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.AddOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.GetAllOwners();
        }

        public List<Owner> GetOwnerByAddress(string address)
        {
            return _ownerRepository.GetOwnerByAddress(address);
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        public List<Owner> GetOwnerByName(string name)
        {
            return _ownerRepository.GetOwnerByName(name);
        }

        public String UpdateOwner(int id, Owner owner)
        {
            return _ownerRepository.UpdateOwner(id, owner);
        }
    }
}