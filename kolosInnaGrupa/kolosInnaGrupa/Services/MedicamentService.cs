using kolosInnaGrupa.Models;
using kolosInnaGrupa.Repositories;

namespace kolosInnaGrupa.Services;

public class MedicamentService : IMedicamentService
{
    private readonly IMedicamentRepository _medicamentRepository;
    private readonly IPresciptionRepository _presciptionRepository;

    public MedicamentService(IMedicamentRepository medicamentRepository, IPresciptionRepository presciptionRepository)
    {
        _medicamentRepository = medicamentRepository;
        _presciptionRepository = presciptionRepository;
    }


    public async Task<Medicament> GetAllinfoMedicamentAsync(int id)
    {
        var presciptions = await _presciptionRepository.GetAllPrescriptionByMedicamentIdAsync(id);
        var result = await _medicamentRepository.GetMedicamentsByIdAsync(id);
        result.PrescriptionList = presciptions;
        return result;
    }

    public Task<List<Prescription>> GetAllPrescriptionByMedicamentIdAsync(int id)
    {
        return _presciptionRepository.GetAllPrescriptionByMedicamentIdAsync(id);
    }
}