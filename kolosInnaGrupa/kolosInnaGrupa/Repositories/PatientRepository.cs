using System.Data.SqlClient;
using kolosInnaGrupa.Exceptions;

namespace kolosInnaGrupa.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly string connectionString;

    public PatientRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public async Task DeletePatientByIdAsync(int id)
    {
        using var con = new SqlConnection(connectionString);
        await con.OpenAsync();
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        using var transaction = await con.BeginTransactionAsync();
        try
        {
            // usuwamy presc_medica
            cmd.CommandText = @"DELETE FROM Prescription_Medicament WHERE IdPrescription in(SELECT IdPrescription FROM prescription WHERE IdPatient = @idPatient)";
            cmd.Parameters.AddWithValue("@idPatient", id);
            cmd.Transaction = (SqlTransaction)transaction;
            await cmd.ExecuteNonQueryAsync();
            
             
             // usuwamy prescription
             cmd.CommandText = "Delete from Prescription where IdPatient = @idPatient";
             await cmd.ExecuteNonQueryAsync();

           // usuwamy patient
             cmd.CommandText = "Delete from Patient where IdPatient = @idPatient";
             
             var patientCount = await cmd.ExecuteNonQueryAsync();
             if (patientCount == 0)
             {
                 throw new NotFoundException("nie ma takiej osoby");
             }

             

             await transaction.CommitAsync();


        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw new NotFoundException(e.Message);
        }
        
        cmd.Parameters.AddWithValue("@idPatient", id);
        
    }


}