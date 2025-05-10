using AnimalClinicAPI.Model.DTO;
using AnimalClinicAPI.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AnimalClinicAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly DBAnimalInterface _dbAnimalService;

    public AnimalController(DBAnimalInterface dbAnimalService)
    {
        _dbAnimalService = dbAnimalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnimals()
    {
        var animals = await _dbAnimalService.getAnimals();
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getAnimal(int id)
    {
        var animal = await _dbAnimalService.getAnimal(id);
        return Ok(animal);
    }
}