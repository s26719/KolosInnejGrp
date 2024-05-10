namespace kolosInnaGrupa.Services;

public interface IPatientService
{
    Task DeletePatientByIdAsync(int id);
}