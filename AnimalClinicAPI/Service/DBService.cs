using AnimalClinicAPI.Model;
using Microsoft.Data.SqlClient;
    
namespace AnimalClinicAPI.Service;

public class DBService : DBInterface
{
    
    private readonly IConfiguration _configuration;

    public DBService(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
    
    public async Task<List<Animal>> getAnimals()
    {
        var animals = new List<Animal>();
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand("SELECT * FROM Animal", connection);
        await connection.OpenAsync();
        
        var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            animals.Add(new Animal
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Type = reader.GetString(2),
                AdmissionDate = reader.GetDateTime(3),
                ownerID = reader.GetInt32(4),
            });
        }

        return animals;
    }

    public Task<Animal> getAnimal(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> addAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public Task<bool> updateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public Task<bool> deleteAnimal(int id)
    {
        throw new NotImplementedException();
    }
}