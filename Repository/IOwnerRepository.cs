using ParkingSystemApi.Models;

namespace ParkingSystemApi.Repository
{
    public interface IOwnerRepository
    {
        Owner GetOwnerById(int id);
        List<Owner> GetAllOwners();
        Owner AddOwner(Owner owner);
        String UpdateOwner(int id, Owner owner);
        Owner DeleteOwner(int id);
        List<Owner> GetOwnerByName(String name);
        List<Owner> GetOwnerByAddress(String address);
        
    }
}