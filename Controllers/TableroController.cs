using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_VelizMiguelC.Models;

namespace tl2_tp10_2023_VelizMiguelC.Controllers;

public class TableroController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ITableroRepository tableroRepository;

    public TableroController(ILogger<HomeController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    public IActionResult Index()
    {
        return View(tableroRepository.GetTableros());
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet]
    public IActionResult ModificarTablero(int idTablero)
    {
        return View(tableroRepository.GetTablero(idTablero));
    }
    

    [HttpPost]
    public IActionResult ModificarTablero(Tablero tablero)
    {
        var tablero2 = tableroRepository.GetTablero(tablero.Id);
        tablero2.Nombre = tablero.Nombre;
        tablero2.Descripcion = tablero.Descripcion;

        tableroRepository.PutTablero(tablero.Id, tablero2);

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
