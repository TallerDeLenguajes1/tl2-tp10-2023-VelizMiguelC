using Microsoft.Data.Sqlite;

namespace tl2_tp10_2023_VelizMiguelC.Models;

public class UsuarioRepository : IUsuarioRepository
{
    private string cadenaConexion = "Data Source=DataBase/kanban.db;Cache=Shared";
    public void addUsuario(Usuario Usu)
    {
        var query = @"INSERT INTO Usuario (nombre_de_usuario) VALUES (@nombre_de_usuario);";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@nombre_de_usuario", Usu.NombreUsuario));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void PutUsuario(int id_Usu, Usuario Usu)
    {
        var query = @"UPDATE Usuario SET nombre_de_usuario = @nombre_de_usuario where id=@idUsu;";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@nombre_de_usuario", Usu.NombreUsuario));
            command.Parameters.Add(new SqliteParameter("@idUsu", id_Usu));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public List<Usuario> ListUsuarios()
    {
        var query = @"SELECT * FROM Usuario;";
        List<Usuario> Usuarios = new List<Usuario>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Usuarios1 = new Usuario();
                    Usuarios1.Id = Convert.ToInt32(reader["id"]);
                    Usuarios1.NombreUsuario = reader["Nombre_De_Usuario"].ToString();
                    Usuarios.Add(Usuarios1);
                }
            }
            connection.Close();
        }
        return Usuarios;
    }
    public Usuario GetUsuario(int id_Usu){
        var query = @"SELECT * FROM Usuario where id=@idUsu;";
        using(SqliteConnection connection = new SqliteConnection(cadenaConexion)){
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            var Usuario1 = new Usuario();
            command.Parameters.Add(new SqliteParameter("@idUsu",id_Usu));
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Usuario1.Id = Convert.ToInt32(reader["id"]);
                    Usuario1.NombreUsuario = reader["Nombre_De_Usuario"].ToString();
                }
            }
            connection.Close();
            return Usuario1;
        }
    }
    public void DeleteUsuario(int id_Usu){
        SqliteConnection connection = new SqliteConnection(cadenaConexion);
        SqliteCommand command = connection.CreateCommand();
        
        command.CommandText = @"DELETE FROM Usuario where id=@idUsu;";
        command.Parameters.Add(new SqliteParameter("@idUsu",id_Usu));
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}