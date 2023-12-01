using Microsoft.Data.Sqlite;

namespace tl2_tp10_2023_VelizMiguelC.Models;

public class TableroRepository : ITableroRepository
{
    private string cadenaConexion = "Data Source=DataBase/kanban.db;Cache=Shared";
    public void addTablero(Tablero Tab)
    {
        var query = @"INSERT INTO Tablero (id_usuario_propietario,nombre,descripcion) VALUES (@id_usuario_propietario,@nombre,@descripcion);";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id_usuario_propietario", Tab.Id_UsuarioPropiertario));
            command.Parameters.Add(new SqliteParameter("@descripcion", Tab.Descripcion));
            command.Parameters.Add(new SqliteParameter("@nombre", Tab.Nombre));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void PutTablero(int idTab, Tablero Tab)
    {
        var query = @"UPDATE Tablero SET id_usuario_propietario = @id_usuario_propietario,descripcion = @descripcion,nombre = @nombre  where id=@idTab;";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id_usuario_propietario", Tab.Id_UsuarioPropiertario));
            command.Parameters.Add(new SqliteParameter("@nombre",Tab.Nombre));
            command.Parameters.Add(new SqliteParameter("@idTab", Tab.Id));
            command.Parameters.Add(new SqliteParameter("@descripcion", Tab.Descripcion));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public Tablero GetTablero(int idTab)
    {
        var query = @"SELECT * FROM Tablero where id=@idTab;";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            var Tablero = new Tablero();
            command.Parameters.Add(new SqliteParameter("@idTab", idTab));
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tablero.Id = Convert.ToInt32(reader["id"]);
                    Tablero.Descripcion = reader["descripcion"].ToString();
                    Tablero.Id_UsuarioPropiertario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    Tablero.Nombre = reader["nombre"].ToString();
                }
            }
            connection.Close();
            return Tablero;
        }
    }
    public List<Tablero> GetTableros()
    {
        var query = @"SELECT * FROM Tablero;";
        List<Tablero> tableros = new List<Tablero>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Tablero = new Tablero();
                    Tablero.Id = Convert.ToInt32(reader["id"]);
                    Tablero.Descripcion = reader["descripcion"].ToString();
                    Tablero.Id_UsuarioPropiertario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    Tablero.Nombre = reader["nombre"].ToString();
                    tableros.Add(Tablero);
                }
            }
            connection.Close();
        }
        return tableros;
    }
    public List<Tablero> GetTableros(int idUsu)
    {
        var query = @"SELECT * FROM Tablero where id_usuario_propietario=@idUsu;";
        List<Tablero> tableros = new List<Tablero>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            command.Parameters.Add(new SqliteParameter("@idUsu", idUsu));

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Tablero = new Tablero();
                    Tablero.Id = Convert.ToInt32(reader["id"]);
                    Tablero.Descripcion = reader["descripcion"].ToString();
                    Tablero.Id_UsuarioPropiertario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    Tablero.Nombre = reader["nombre"].ToString();
                    tableros.Add(Tablero);
                }
            }
            connection.Close();
        }
        return tableros;
    }
    public void DeleteTablero(int idTab)
    {
        SqliteConnection connection = new SqliteConnection();
        SqliteCommand command = connection.CreateCommand();

        command.CommandText = $"DELETE * FROM Tablero where id=@idTab;";
        command.Parameters.Add(new SqliteParameter("@idTab", idTab));
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}
