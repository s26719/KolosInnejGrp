namespace kolosInnaGrupa.Repositories;

public interface IPatientRepository
{
    Task DeletePatientByIdAsync(int id);
}