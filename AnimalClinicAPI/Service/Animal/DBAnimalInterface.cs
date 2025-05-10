using AnimalClinicAPI.Model;
using AnimalClinicAPI.Model.DTO;

namespace AnimalClinicAPI.Service;

public interface DBAnimalInterface
{
    Task<List<Animal>> getAnimals();
    Task<AnimalDTO> getAnimal(int id);
    Task<bool> addAnimal(Animal animal);
    Task<bool> updateAnimal(Animal animal);
    Task<bool> deleteAnimal(int id);
}