namespace tl2_tp10_2023_VelizMiguelC.Models;

public enum EstadoTarea
{
    Ideas = 0,
    ToDo = 1,
    Doing = 2,
    Review = 3,
    Done = 4
}
public class Tarea
{
    private int id;
    private int id_Tablero;
    private string? nombre;
    private string? descripcion;
    private string? color;
    private EstadoTarea estado;
    private int? idUsuarioAsignado;

    public int Id { get => id; set => id = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }
    public int? IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
    public int Id_Tablero { get => id_Tablero; set => id_Tablero = value; }
    public EstadoTarea GetEstado(int EstadoBD)
    {
        var Estados = EstadoTarea.Ideas;
        switch (EstadoBD)
        {
            case 0:
                Estados = EstadoTarea.Ideas;
                break;
            case 1:
                Estados = EstadoTarea.ToDo;
                break;
            case 2:
                Estados = EstadoTarea.Doing;
                break;
            case 3:
                Estados = EstadoTarea.Review;
                break;
            case 4:
                Estados = EstadoTarea.Done;
                break;
            default:
                break;
        }
        return Estados;
    }
}