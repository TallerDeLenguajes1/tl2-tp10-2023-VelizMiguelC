namespace tl2_tp10_2023_VelizMiguelC.Models;

public interface IUsuarioRepository
{
    public void addUsuario(Usuario Usu);
    public void PutUsuario(int id_Usu, Usuario Usu);
    public List<Usuario> ListUsuarios();
    public Usuario GetUsuario(int id_Usu);
    public void DeleteUsuario(int id_Usu);
}

