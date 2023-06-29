using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_Elecciones.Models;

namespace TP_Elecciones.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger){
        _logger = logger;
    }

    public IActionResult Index(){
        return View();
    }

    public IActionResult VerDetalleCandidato(){
        return View();   
    }

    public IActionResult VerDetallePartido(){
        return View();
    }

    public IActionResult AgregarCandidato(){
        return View();
    }

    public IActionResult AgregarPartido(){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
