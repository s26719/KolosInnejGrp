using kolosInnaGrupa.Exceptions;
using kolosInnaGrupa.Repositories;
using kolosInnaGrupa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolosInnaGrupa.Controllers;

[Route("api/medicament")]
[ApiController]
public class MedicamentController:ControllerBase
{
    private readonly IMedicamentService _medicamentService;


    public MedicamentController(IMedicamentService medicamentService)
    {
        _medicamentService = medicamentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInfo([FromQuery] int id)
    {
        try
        {
            var result = await _medicamentService.GetAllinfoMedicamentAsync(id);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [Route("api/prescription")]
    [HttpGet]
    public async Task<IActionResult> GetallPresciptions(int id)
    {

        return Ok(await _medicamentService.GetAllPrescriptionByMedicamentIdAsync(id));
    }
    
}