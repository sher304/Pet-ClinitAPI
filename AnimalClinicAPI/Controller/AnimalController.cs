using AnimalClinicAPI.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AnimalClinicAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly DBInterface _dbService;

    public AnimalController(DBInterface _dbService)
    {
        this._dbService = _dbService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAnimals()
    {
        var animals = await _dbService.getAnimals();
        return Ok(animals);
    }
}