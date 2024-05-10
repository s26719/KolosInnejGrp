using kolosInnaGrupa.Models;

namespace kolosInnaGrupa.Services;

public interface IMedicamentService
{
    Task<Medicament> GetAllinfoMedicamentAsync(int id);
    Task<List<Prescription>> GetAllPrescriptionByMedicamentIdAsync(int id);
}