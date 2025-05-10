using AnimalClinicAPI.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AnimalClinicAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProcedureController : ControllerBase
{
    
    private readonly DBProcedureInterface _dbProcedureService;

    public ProcedureController(DBProcedureInterface dbProcedureService)
    {
        _dbProcedureService = dbProcedureService;
    }

    [HttpGet]
    public async Task<IActionResult> getProcedures()
    {
        var procedures = await _dbProcedureService.GetAllProcedures();
        return Ok(procedures);
    }
    
}