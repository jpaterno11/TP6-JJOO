using System.Data.SqlClient;
using Dapper;

public class BD
{
    private static string _connectionString = @"Server=localhost5088; DataBase=basededatosJJOO;Trusted_Connection=True;";
    public static void AgregarDeportista(Deportista dep)
    {
        string query = "INSERT INTO Deportistas (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) VALUES (@Apellido, @Nombre, @FechaNacimiento, @Foto, @IdPais, @IdDeporte)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(query, new { dep.Apellido, dep.Nombre, dep.FechaNacimiento, dep.Foto, dep.IdPais, dep.IdDeporte });
        }
    }
    public static void EliminarDeportista(int idDeportista)
    {
        string query = "DELETE FROM Deportistas WHERE IdDeportista = @IdDeportista";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(query, new { IdDeportista = idDeportista });
        }
    }

    public static Deporte VerInfoDeporte(int idDeporte)
    {
        string query = "SELECT * FROM Deportes WHERE IdDeporte = @IdDeporte";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.QuerySingleOrDefault<Deporte>(query, new { IdDeporte = idDeporte });
        }
    }

    public static Pais VerInfoPais(int idPais)
    {
        string query = "SELECT * FROM Paises WHERE IdPais = @IdPais";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.QuerySingleOrDefault<Pais>(query, new { IdPais = idPais });
        }
    }

    public static Deportista VerInfoDeportista(int idDeportista)
    {
        string query = "SELECT * FROM Deportistas WHERE IdDeportista = @IdDeportista";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.QuerySingleOrDefault<Deportista>(query, new { IdDeportista = idDeportista });
        }
    }

    public static List<Pais> ListarPaises()
    {
        string query = "SELECT * FROM Paises";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Pais>(query).AsList();
        }
    }

    public static List<Deportista> ListarDeportistasPorDeporte(int idDeporte)
    {
        string query = "SELECT * FROM Deportistas WHERE IdDeporte = @IdDeporte";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Deportista>(query, new { IdDeporte = idDeporte }).AsList();
        }
    }

    public static List<Deportista> ListarDeportistasPorPais(int idPais)
    {
        string query = "SELECT * FROM Deportistas WHERE IdPais = @IdPais";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Deportista>(query, new { IdPais = idPais }).AsList();
        }
    }
}
