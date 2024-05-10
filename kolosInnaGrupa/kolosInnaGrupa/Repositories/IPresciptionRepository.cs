using kolosInnaGrupa.Models;

namespace kolosInnaGrupa.Repositories;

public interface IPresciptionRepository
{
    Task<List<Prescription>> GetAllPrescriptionByMedicamentIdAsync(int id);
}