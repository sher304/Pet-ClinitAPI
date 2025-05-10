using AnimalClinicAPI.Model;
using Microsoft.Data.SqlClient;

namespace AnimalClinicAPI.Service.Procedure_Animal;

public class DBProcedureAnimalService : DBProcedureAnimalInterface
{
    
    private readonly IConfiguration _configuration;

    public DBProcedureAnimalService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<ProcedureAnimal>> GetAllProcedureAnimals()
    {
        var procedureAnimals = new List<ProcedureAnimal>();
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand(@"select * from [Procedure_Animal]", connection);
        connection.Open();
        
        var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            procedureAnimals.Add(new ProcedureAnimal
            {
                Animal_Id = reader.GetInt32(0),
                Procedure_Id = reader.GetInt32(1),
                Date = reader.GetDateTime(2),
            });
        }

        return procedureAnimals;
    }

    public Task<ProcedureAnimal> GetProcedureAnimalById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddProcedureAnimal(ProcedureAnimal animal)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProcedureAnimal(ProcedureAnimal animal)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProcedureAnimal(ProcedureAnimal animal)
    {
        throw new NotImplementedException();
    }
}