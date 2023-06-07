using ParkingSystemApi.Models;

namespace ParkingSystemApi.Service
{
    public interface IOwnerService
    {
        Owner GetOwnerById(int id);
        List<Owner> GetAllOwners();
        Owner CreateOwner(Owner owner);
        String UpdateOwner(int id, Owner owner);
        Owner DeleteOwner(int id);
        List<Owner> GetOwnerByName(String name);
        List<Owner> GetOwnerByAddress(String address);
    }
}