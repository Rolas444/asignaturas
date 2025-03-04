using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica.Models;

namespace prueba_tecnica.Controllers;

public class HomeController : Controller
{
    private readonly AsignaturaService _asignaturaService;

    public HomeController (AsignaturaService asignaturaService)
    {
        _asignaturaService = asignaturaService;
    }

    public async Task<IActionResult> Index()
    {
        var asignaturas = await _asignaturaService.GetAsignaturas();
        return View(asignaturas);
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
