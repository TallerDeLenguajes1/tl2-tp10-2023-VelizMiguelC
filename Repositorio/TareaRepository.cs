using Microsoft.Data.Sqlite;

namespace tl2_tp10_2023_VelizMiguelC.Models;

public class TareaRepository : ITareaRepository
{
    private string cadenaConexion = "Data Source=DataBase/kanban.db;Cache=Shared";
    public void addTarea(int idTab, Tarea T)
    {
        var query = @"INSERT INTO Tarea (id_tablero,nombre,estado,descripcion,color) VALUES (@id_tablero,@nombre,@estado,@descripcion,@color);";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id_tablero", idTab));
            command.Parameters.Add(new SqliteParameter("@nombre", T.Nombre));
            command.Parameters.Add(new SqliteParameter("@estado", T.Estado));
            command.Parameters.Add(new SqliteParameter("@descripcion", T.Descripcion));
            command.Parameters.Add(new SqliteParameter("@color", T.Color));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void PutTarea(int idTar, Tarea T)
    {
        var query = @"UPDATE Tarea SET nombre = @nombre,estado = @estado,descripcion = @descripcion, color = @color where id=@id_Tar;";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id_Tar", idTar));
            //command.Parameters.Add(new SqliteParameter("@idTarea", idTar));
            command.Parameters.Add(new SqliteParameter("@nombre", T.Nombre));
            command.Parameters.Add(new SqliteParameter("@estado", T.Estado));
            command.Parameters.Add(new SqliteParameter("@descripcion", T.Descripcion));
            command.Parameters.Add(new SqliteParameter("@color", T.Color));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void PutEstadoTarea(int idTar, EstadoTarea Est)
    {
        var query = @"UPDATE Tarea SET estado = @estado where id=@id_Tar;";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id_Tar", idTar));
            command.Parameters.Add(new SqliteParameter("@idTarea", idTar));
            command.Parameters.Add(new SqliteParameter("@estado", Est));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public Tarea GetTarea(int idTar)
    {
        var query = @"SELECT * FROM Tarea where id=@idTar;";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            var tarea = new Tarea();
            command.Parameters.Add(new SqliteParameter("@idTar", idTar));
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.Id_Tablero = Convert.ToInt32(reader["id"]);
                    tarea.Descripcion = reader["descripcion"].ToString();
                    if (reader["id_usuario_asignado"] == DBNull.Value)
                    {
                        tarea.IdUsuarioAsignado = 0;
                    }
                    else
                    {
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                    }
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Color = reader["color"].ToString();
                    int valorBD = Convert.ToInt32(reader["estado"]);
                    tarea.Estado = tarea.GetEstado(valorBD);
                }
            }
            connection.Close();
            return tarea;
        }
    }
    public List<Tarea> GetTareasUsu(int idUsu)
    {
        var query = @"SELECT * FROM Tarea where id_usuario_asignado=@idUsu;";
        List<Tarea> tareas = new List<Tarea>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            command.Parameters.Add(new SqliteParameter("@idUsu", idUsu));

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.Id_Tablero = Convert.ToInt32(reader["id"]);
                    tarea.Descripcion = reader["descripcion"].ToString();
                    if (reader["id_usuario_asignado"] == DBNull.Value)
                    {
                        tarea.IdUsuarioAsignado = 0;
                    }
                    else
                    {
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                    }
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Color = reader["color"].ToString();
                    int valorBD = Convert.ToInt32(reader["estado"]);
                    tarea.Estado = tarea.GetEstado(valorBD);
                    tareas.Add(tarea);
                }
            }
            connection.Close();
        }
        return tareas;
    }
    public List<Tarea> GetAllTareas()
    {
        var query = @"SELECT * FROM Tarea;";
        List<Tarea> tareas = new List<Tarea>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.Id_Tablero = Convert.ToInt32(reader["id"]);
                    tarea.Descripcion = reader["descripcion"].ToString();
                    if (reader["id_usuario_asignado"] == DBNull.Value)
                    {
                        tarea.IdUsuarioAsignado = 0;
                    }
                    else
                    {
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                    }
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Color = reader["color"].ToString();
                    int valorBD = Convert.ToInt32(reader["estado"]);
                    tarea.Estado = tarea.GetEstado(valorBD);
                    tareas.Add(tarea);
                }
            }
            connection.Close();
        }
        return tareas;
    }
    public List<Tarea> GetTareasTab(int idTab)
    {
        var query = @"SELECT * FROM Tarea where id_tablero=@idTab;";
        List<Tarea> tareas = new List<Tarea>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            command.Parameters.Add(new SqliteParameter("@idTab", idTab));

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.Id_Tablero = Convert.ToInt32(reader["id"]);
                    tarea.Descripcion = reader["descripcion"].ToString();
                    if (reader["id_usuario_asignado"] == DBNull.Value)
                    {
                        tarea.IdUsuarioAsignado = 0;
                    }
                    else
                    {
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                    }
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Color = reader["color"].ToString();
                    int valorBD = Convert.ToInt32(reader["estado"]);
                    tarea.Estado = tarea.GetEstado(valorBD);
                    tareas.Add(tarea);
                }
            }
            connection.Close();
        }
        return tareas;
    }
    public void DeleteTarea(int idTar)
    {
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            connection.Open();

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Tarea WHERE id=@idTar;";
                command.Parameters.Add(new SqliteParameter("@idTar", idTar));

                command.ExecuteNonQuery();
            }
        }
    }
    public void AssingUsu(int idTar, int idUsu)
    {
        var query = @"UPDATE Tarea SET id_usuario_asignado = @id_usuario_asignado  where id=@id_Tar;";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id_usuario_asignado", idUsu));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}