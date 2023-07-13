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
        BD.LevantarPartidos();
        ViewBag.ListaPartidos = BD.ListarPartidos();
        ViewBag.cantidad = BD.GetCantPartidos();
        return View();
    }

    public IActionResult VerDetallePartido(int idPartido){
        BD.LevantarPartidos();
        BD.LevantarCandidatos();
        ViewBag.infoPartido = BD.VerInfoPartido(idPartido);
        ViewBag.candidatos = BD.ListarCandidatos(idPartido);
        ViewBag.cantidad = BD.GetCantCandidatos(idPartido);
        return View();
    }
    public IActionResult VerDetalleCandidato(int idCandidato){
        BD.LevantarCandidatos();
        ViewBag.infoCandidato = BD.VerInfoCandidato(idCandidato);
        return View();
    }

    public IActionResult AgregarCandidato(){
        ViewBag.Partidos = BD.ListarPartidos();
        ViewBag.cant = BD.GetCantPartidos();
        return View();
    }

    [HttpPost]
    public IActionResult GuardarCandidato(int idPartido, string Apellido, string Nombre, DateTime FechaNacimiento, string Foto, string Postulacion){
        BD.AgregarCandidato(new Candidato(idPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion));
        return RedirectToAction("VerDetallePartido", new { idPartido = idPartido });
    }

    public IActionResult AgregarPartido(){
        return View();
    }

    [HttpPost]
    public IActionResult GuardarPartido(string Nombre, string Logo, string SitioWeb, DateTime FechaFundacion, int CantidadDiputados, int CantidadSenadores){
        BD.AgregarPartido(new Partido(Nombre, Logo, SitioWeb, FechaFundacion, CantidadDiputados, CantidadSenadores));
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
