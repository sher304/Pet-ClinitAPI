using AnimalClinicAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace AnimalClinicAPI.Controller;
[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{

    private readonly DBOwnerInterface  _ownerService;
    
    public OwnerController(DBOwnerInterface ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOwners()
    {
        var owners = await _ownerService.getOwners();
        return Ok(owners);
    }
}