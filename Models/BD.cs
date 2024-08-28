using System.Data.SqlClient;
using Dapper;

public class BD
{
    private static List<Pais> _listaPaises;
    private static List<Deporte> _listaDeportes;
    private static List<Deportista> _listaDeportistaxDeporte;
    private static List<Deportista> _listaDeportistaxPais;

    private static string _connectionString = @"Server=A-PHZ2-CEO-21; DataBase=JJOO ; Trusted_Connection=True;";
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
            _listaPaises = db.Query<Pais>(query).AsList();
        }
        return _listaPaises;
    }
    public static List<Deporte> ListarDeportes()
    {
        string query = "SELECT * FROM Deportes";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            _listaDeportes = db.Query<Deporte>(query).AsList();
        }
        return _listaDeportes;
    }
    public static List<Deportista> ListarDeportistasPorDeporte(int idDeporte)
    {
        string query = "SELECT * FROM Deportistas WHERE IdDeporte = @IdDeporte";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            _listaDeportistaxDeporte = db.Query<Deportista>(query, new { IdDeporte = idDeporte }).AsList();
        }
        return _listaDeportistaxDeporte;
    }

    public static List<Deportista> ListarDeportistasPorPais(int idPais)
    {
        string query = "SELECT * FROM Deportistas WHERE IdPais = @IdPais";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            _listaDeportistaxPais = db.Query<Deportista>(query, new { IdPais = idPais }).AsList();
        }
        return _listaDeportistaxPais;
    }
}
