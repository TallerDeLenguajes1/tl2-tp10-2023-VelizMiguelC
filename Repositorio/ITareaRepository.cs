namespace tl2_tp10_2023_VelizMiguelC.Models;

public interface ITareaRepository
{
    public void addTarea(int idTab,Tarea T);
    public void PutTarea(int idTar,Tarea T);
    void PutEstadoTarea(int idTar, EstadoTarea Est);
    public Tarea GetTarea(int idTar);
    public List<Tarea> GetAllTareas();
    public List<Tarea> GetTareasUsu(int idUsu);
    public List<Tarea> GetTareasTab(int idTab);
    public void DeleteTarea(int idTar);
    public void AssingUsu(int idTar,int idUsu);
}