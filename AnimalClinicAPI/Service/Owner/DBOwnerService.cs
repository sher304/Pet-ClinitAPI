using AnimalClinicAPI.Model;
using Microsoft.Data.SqlClient;

namespace AnimalClinicAPI.Service;

public class DBOwnerService : DBOwnerInterface
{
    
    private readonly IConfiguration _configuration;

    public DBOwnerService(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
    
    public async Task<List<Owner>> getOwners()
    {
        List<Owner> owners = new List<Owner>();
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand("Select * from Owner", connection);
        await connection.OpenAsync();
        
        var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            owners.Add(new Owner
            {
                id = reader.GetInt32(0),
                firstName = reader.GetString(1),
                lastName = reader.GetString(2),
            });
        }

        return owners;
    }

    public Task<Owner> getOwner(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> addOwner(Owner owner)
    {
        throw new NotImplementedException();
    }

    public Task<bool> updateOwner(Owner owner)
    {
        throw new NotImplementedException();
    }

    public Task<bool> deleteOwner(int id)
    {
        throw new NotImplementedException();
    }
}