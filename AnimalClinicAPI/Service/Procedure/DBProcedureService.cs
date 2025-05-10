using AnimalClinicAPI.Model;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;

namespace AnimalClinicAPI.Service;

public class DBProcedureService : DBProcedureInterface
{
    
    private readonly IConfiguration _configuration;

    public DBProcedureService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<List<Procedure>> GetAllProcedures()
    {
        var procedures = new List<Procedure>();
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand($"select * from [Procedure]", connection);
        connection.Open();
        
        var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            procedures.Add(new Procedure
            {
                id = reader.GetInt32(0),
                name = reader.GetString(1),
                description = reader.GetString(2)
            });
        }
        return procedures;
    }

    public Task<Procedure> GetProcedureById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateProcedure(Procedure procedure)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProcedure(Procedure procedure)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProcedure(int id)
    {
        throw new NotImplementedException();
    }
}