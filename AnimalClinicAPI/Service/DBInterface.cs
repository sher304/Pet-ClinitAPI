using AnimalClinicAPI.Model;

namespace AnimalClinicAPI.Service;

public interface DBInterface
{
    Task<List<Animal>> getAnimals();
    Task<Animal> getAnimal(int id);
    Task<bool> addAnimal(Animal animal);
    Task<bool> updateAnimal(Animal animal);
    Task<bool> deleteAnimal(int id);
}