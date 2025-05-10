using AnimalClinicAPI.Model;

namespace AnimalClinicAPI.Service.Procedure_Animal;

public interface DBProcedureAnimalInterface
{
    Task<List<ProcedureAnimal>> GetAllProcedureAnimals();
    Task<ProcedureAnimal> GetProcedureAnimalById(int id);
    Task<bool> AddProcedureAnimal(ProcedureAnimal animal);
    Task<bool> UpdateProcedureAnimal(ProcedureAnimal animal);
    Task<bool> DeleteProcedureAnimal(ProcedureAnimal animal);
}