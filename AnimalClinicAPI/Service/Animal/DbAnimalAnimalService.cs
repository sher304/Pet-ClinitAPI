using System.Data.Common;
using AnimalClinicAPI.Model;
using AnimalClinicAPI.Model.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

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
                OwnerId = reader.GetInt32(4),
            });
        }

        return animals;
    }

    public async Task<bool> animalExists(int id)
    {
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand("SELECT count(*) FROM Animal WHERE Id = @id", connection);
        command.Connection = connection;
        connection.Open();
        command.Parameters.AddWithValue("@id", id);

        var res = await command.ExecuteScalarAsync();
        if (res.Equals(0)) return false;
        else return true;
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

        if (animalDto is null) throw new Exception();
        return animalDto;
    }

    public async Task<bool> addAnimal(Animal animal)
    {
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand("INSERT INTO Animal (Name, Type, AdmissionDate, Owner_ID) VALUES (@Name, @Type, @AdmissionDate, @Owner_ID);", connection);
        command.Connection = connection;
        await connection.OpenAsync();

        DbTransaction transaction = connection.BeginTransaction();
        command.Transaction = transaction as SqlTransaction;

        try
        {
            command.Parameters.AddWithValue("@Name", animal.Name);
            command.Parameters.AddWithValue("@Type", animal.Type);
            command.Parameters.AddWithValue("@AdmissionDate", animal.AdmissionDate);
            command.Parameters.AddWithValue("@Owner_ID", animal.OwnerId);

            int result = await command.ExecuteNonQueryAsync();
            await transaction.CommitAsync();
            return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            transaction.Rollback();
            throw e;
        }
    }

    public Task<bool> updateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> deleteAnimal(int id)
    {
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand("delete from animal where id = @id", connection);
        connection.Open();
        
        DbTransaction transaction = connection.BeginTransaction();
        command.Transaction = transaction as SqlTransaction;

        try
        {
            command.Parameters.AddWithValue("@id", id);
            int result = await command.ExecuteNonQueryAsync();
            await transaction.CommitAsync();
            return result > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            transaction.Rollback();
            throw e;
        }
    }

    public Task<bool> addAnimalWithProcedure(AnimalPostDTO animalPostDto)
    {
        throw new NotImplementedException();
    }
}