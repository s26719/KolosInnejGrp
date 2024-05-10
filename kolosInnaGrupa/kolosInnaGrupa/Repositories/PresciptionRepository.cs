using System.Data.SqlClient;
using kolosInnaGrupa.Models;

namespace kolosInnaGrupa.Repositories;

public class PresciptionRepository : IPresciptionRepository
{
    private readonly string connectionString;

    public PresciptionRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    

    public async Task<List<Prescription>> GetAllPrescriptionByMedicamentIdAsync(int id)
    {
        var prescriptions = new List<Prescription>();
        using var con = new SqlConnection(connectionString);
        await con.OpenAsync();
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"Select pr.IdPrescription, pr.Date, pr.DueDate, pr.IdPatient, pr.IdDoctor
                            from Prescription pr 
                            join Prescription_Medicament prM ON pr.IdPrescription = prM.IdPrescription 
                            where prM.IdMedicament = @idMedicament
                            order by date DESC";
        cmd.Parameters.AddWithValue("@idMedicament", id);
        var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            Prescription prescription = new()
            {
                IdPrescription = int.Parse(reader["IdPrescription"].ToString()),
                Date = DateTime.Parse(reader["Date"].ToString()),
                DueDate = DateTime.Parse(reader["DueDate"].ToString()),
                IdPatient = int.Parse(reader["IdPatient"].ToString()),
                IdDoctor = int.Parse(reader["IdDoctor"].ToString())
            };
            prescriptions.Add(prescription);
        }

        return prescriptions;

    }
}