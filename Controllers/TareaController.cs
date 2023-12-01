using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_VelizMiguelC.Models;

namespace tl2_tp10_2023_VelizMiguelC.Controllers;

public class TareaController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ITareaRepository tareaRepository;

    public TareaController(ILogger<HomeController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    public IActionResult Index()
    {
        var tareas = tareaRepository.GetAllTareas();
        return View(tareas);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet]
    public IActionResult CrearTarea()
    {
        return View(new Tarea());
    }


    [HttpPost]
    public IActionResult CrearTarea(Tarea tarea)
    {
        tareaRepository.addTarea(1, tarea);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult ModificarTarea(int IdTar){
        return View(tareaRepository.GetTarea(IdTar));
    }
    [HttpPost]
    public IActionResult ModificarTarea(int idTar,Tarea Tar){
        tareaRepository.PutTarea(idTar,Tar);
        return RedirectToAction("index");
    }
    public IActionResult DeleteTarea(int idTar)
    {
        tareaRepository.DeleteTarea(idTar);
        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
