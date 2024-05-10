using kolosInnaGrupa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolosInnaGrupa.Controllers;
[Route("api/patient")]
[ApiController]

public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePatient(int id)
    {
       await _patientService.DeletePatientByIdAsync(id);
        return NoContent();
    }
}