namespace tl2_tp10_2023_VelizMiguelC.Models;
public class Tablero
{
    private int id;
    private int id_UsuarioPropiertario;
    private string? nombre;
    private string? descripcion;

    public int Id { get => id; set => id = value; }
    public int Id_UsuarioPropiertario { get => id_UsuarioPropiertario; set => id_UsuarioPropiertario = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
}