using System.Data.SqlClient;
using System.Globalization;
using kolosInnaGrupa.Exceptions;
using kolosInnaGrupa.Models;

namespace kolosInnaGrupa.Repositories;

public class MedicamentRepository : IMedicamentRepository
{
    private readonly string connectionString;

    public MedicamentRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    

    public async Task<Medicament> GetMedicamentsByIdAsync(int id)
    {
        using var con = new SqlConnection(connectionString);
        await con.OpenAsync();
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * from Medicament where IdMedicament = @idMedicament";
        cmd.Parameters.AddWithValue("@idMedicament", id);
        using var reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            Medicament medicament = new()
            {
                IdMedicament = int.Parse(reader["IdMedicament"].ToString()),
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Type = reader["Type"].ToString()
            };
            return medicament;
        }
        else
        {
            throw new NotFoundException("Nie ma tekiego leku");
        }


    }
}