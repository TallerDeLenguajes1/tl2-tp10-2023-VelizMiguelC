using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_VelizMiguelC.Models;

namespace tl2_tp10_2023_VelizMiguelC.Controllers;

public class UsuarioController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IUsuarioRepository usuarioRepository;

    public UsuarioController(ILogger<HomeController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    public IActionResult Index()
    {
        List<Usuario> usuarios = usuarioRepository.ListUsuarios();
        return View(usuarios);
    }
    [HttpGet]
    public IActionResult CrearUsuario(){
        return View(new Usuario());
    }
    [HttpPost]
    public IActionResult CrearUsuario(Usuario usuario){
        usuarioRepository.addUsuario(usuario);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult ModificarUsuario(int idUsu){
        return View(usuarioRepository.GetUsuario(idUsu));
    }
    [HttpPost]
    public IActionResult ModificarUsuario(int idUsu,Usuario usuario){
        usuarioRepository.PutUsuario(idUsu,usuario);
        return RedirectToAction("Index");
    }
    public IActionResult DeleteUsuario(int idUsu)
    {  
        usuarioRepository.DeleteUsuario(idUsu);
        return RedirectToAction("Index");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
