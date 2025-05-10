using AnimalClinicAPI.Model;
using AnimalClinicAPI.Model.DTO;
using Microsoft.Data.SqlClient;
    
namespace AnimalClinicAPI.Service;

public class DbAnimalAnimalService : DBAnimalInterface
{
    
    private readonly IConfiguration _configuration;

    public DbAnimalAnimalService(IConfiguration configuration)
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

    public async Task<AnimalDTO> getAnimal(int id)
    {
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand("select an.id, an.Name, an.[Type], an.AdmissionDate, ow.ID, ow.FirstName, ow.LastName, pr.Name, pr.[Description], pa.[Date] from Animal as an\njoin [Owner] as ow on ow.ID = an.Owner_ID\njoin [Procedure_Animal] as pa on pa.Animal_ID = an.ID\njoin [Procedure] as pr on pr.ID = pa.Procedure_ID\nwhere an.id = @id;", connection);
        command.Parameters.AddWithValue("@id", id);
        connection.Open();

        AnimalDTO animalDto = null;
        var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            if (animalDto == null)
            {
                animalDto = new AnimalDTO
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    type = reader.GetString(2),
                    admissionDate = reader.GetDateTime(3),
                    owner = new Owner
                    {
                        id = reader.GetInt32(4),
                        firstName = reader.GetString(5),
                        lastName = reader.GetString(6),
                    },
                    procedures = new List<ProcedureDto>()
                    {
                        new ProcedureDto()
                        {
                            Name = reader.GetString(7),
                            description = reader.GetString(8),
                            date = reader.GetDateTime(9),
                        }
                    }
                };
            }
            else
            {
                animalDto.procedures.Add(new ProcedureDto
                {
                    Name = reader.GetString(7),
                    description = reader.GetString(8),
                    date = reader.GetDateTime(9)
                });
            }
        }

        if (animalDto == null) throw new Exception();
        return animalDto;
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