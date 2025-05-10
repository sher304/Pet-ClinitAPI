using AnimalClinicAPI.Service.Procedure_Animal;
using Microsoft.AspNetCore.Mvc;

namespace AnimalClinicAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProcedureAnimal : ControllerBase
{
    
    private readonly DBProcedureAnimalInterface _dbService;

    public ProcedureAnimal(DBProcedureAnimalInterface dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProcedureAnimal()
    {
        var animalProcedures = await _dbService.GetAllProcedureAnimals();
        return Ok(animalProcedures);
    }
    
}