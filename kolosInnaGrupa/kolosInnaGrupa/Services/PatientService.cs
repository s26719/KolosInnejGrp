using kolosInnaGrupa.Repositories;

namespace kolosInnaGrupa.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }


    public async Task DeletePatientByIdAsync(int id)
    {
        await _patientRepository.DeletePatientByIdAsync(id);
    }
}