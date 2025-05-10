using AnimalClinicAPI.Model;

namespace AnimalClinicAPI.Service;

public interface DBProcedureInterface
{
    
    Task<List<Procedure>> GetAllProcedures();
    Task<Procedure> GetProcedureById(int id);
    Task<bool> CreateProcedure(Procedure procedure);
    Task<bool> UpdateProcedure(Procedure procedure);
    Task<bool> DeleteProcedure(int id);
}