using AnimalClinicAPI.Model;

namespace AnimalClinicAPI.Service;

public interface DBOwnerInterface
{
    Task<List<Owner>> getOwners();
    Task<Owner> getOwner(int id);
    Task<bool> addOwner(Owner owner);
    Task<bool> updateOwner(Owner owner);
    Task<bool> deleteOwner(int id);
}