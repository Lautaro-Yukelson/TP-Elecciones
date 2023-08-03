using System.ComponentModel;
using System.IO.Compression;
using System.Net;
using System.Drawing;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_Elecciones.Models;

namespace TP_Elecciones.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ListaPartidos = BD.LevantarPartidos();
        ViewBag.cantidad = BD.GetCantPartidos();
        return View();
    }

    public IActionResult VerDetallePartido(int idPartido)
    {
        ViewBag.ListaPartidos = BD.LevantarPartidos();
        ViewBag.infoPartido = BD.VerInfoPartido(idPartido);
        ViewBag.candidatos = BD.LevantarCandidatos(idPartido);
        return View();
    }

    public IActionResult AgregarCandidato()
    {
        ViewBag.ListaPartidos = BD.LevantarPartidos();
        return View();
    }

    [HttpPost]
    public IActionResult GuardarCandidato(int idPartido, string Apellido, string Nombre, DateTime FechaNacimiento, string Foto, string Postulacion)
    {
        BD.AgregarCandidato(new Candidato(idPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion));
        return RedirectToAction("VerDetallePartido", new { idPartido });
    }

    [HttpPost]
    public IActionResult ActualizarCandidato(int idCandidato, int idPartido, string Apellido, string Nombre, DateTime FechaNacimiento, string Foto, string Postulacion)
    {
        BD.ActualizarCandidato(new Candidato(idPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion), idCandidato);
        return RedirectToAction("VerDetallePartido", new { idPartido });
    }

    public IActionResult EliminarCandidato(int idCandidato, int idPartido)
    {
        BD.EliminarCandidato(idCandidato);
        return RedirectToAction("VerDetallePartido", new { idPartido });
    }

    public IActionResult AgregarPartido()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GuardarPartido(string Nombre, string Logo, string SitioWeb, DateTime FechaFundacion, int CantidadDiputados, int CantidadSenadores, string ColorPrimario, string ColorSecundario)
    {
        BD.AgregarPartido(new Partido(Nombre, Logo, SitioWeb, FechaFundacion, CantidadDiputados, CantidadSenadores, ColorPrimario, ColorSecundario));
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult ActualizarPartido(int idPartido, string Nombre, string Logo, string SitioWeb, DateTime FechaFundacion, int CantidadDiputados, int CantidadSenadores, string ColorPrimario, string ColorSecundario)
    {
        BD.ActualizarPartido(new Partido(Nombre, Logo, SitioWeb, FechaFundacion, CantidadDiputados, CantidadSenadores, ColorPrimario, ColorSecundario), idPartido);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult EliminarPartido(int idPartido)
    {
        BD.EliminarPartido(idPartido);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Elecciones()
    {
        return View();
    }

    public IActionResult Creditos()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
