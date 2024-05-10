using kolosInnaGrupa.Models;

namespace kolosInnaGrupa.Repositories;

public interface IMedicamentRepository
{
    Task<Medicament> GetMedicamentsByIdAsync(int id);
}