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

    public HomeController(ILogger<HomeController> logger){
        _logger = logger;
    }

    public IActionResult Index(){
        ViewBag.ListaPartidos = BD.LevantarPartidos();
        ViewBag.cantidad = BD.GetCantPartidos();
        return View();
    }

    public IActionResult VerDetalleCandidato(int idCandidato){
        ViewBag.infoCandidato = BD.VerInfoCandidato(idCandidato);
        return View();
    }

    public IActionResult VerDetallePartido(int idPartido){
        ViewBag.infoPartido = BD.VerInfoPartido(idPartido);
        ViewBag.candidatos = BD.LevantarCandidatos(idPartido);
        ViewBag.cantidad = BD.GetCantCandidatos(idPartido);
        return View();
    }

    public IActionResult AgregarCandidato(){
        ViewBag.Partidos = BD.LevantarPartidos();
        ViewBag.cant = BD.GetCantPartidos();
        return View();
    }

    [HttpPost]
    public IActionResult GuardarCandidato(int idPartido, string Apellido, string Nombre, DateTime FechaNacimiento, string Foto, string Postulacion){
        BD.AgregarCandidato(new Candidato(idPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion));
        return RedirectToAction("VerDetallePartido", new { idPartido = idPartido });
    }

    [HttpPost]
    public IActionResult ActualizarCandidato(int idPartido, string Apellido, string Nombre, DateTime FechaNacimiento, string Foto, string Postulacion){
        int idCandidato = 3;
        BD.ActualizarCandidato(new Candidato(idPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion));
        return RedirectToAction("VerDetalleCandidato", new {idCandidato = idCandidato});
    }

    public IActionResult AgregarPartido(){
        return View();
    }

    [HttpPost]
    public IActionResult GuardarPartido(string Nombre, string Logo, string SitioWeb, DateTime FechaFundacion, int CantidadDiputados, int CantidadSenadores, string ColorPrimario, string ColorSecundario){
        BD.AgregarPartido(new Partido(Nombre, Logo, SitioWeb, FechaFundacion, CantidadDiputados, CantidadSenadores, ColorPrimario, ColorSecundario));
        return RedirectToAction("Index", "Home");
    }

    public IActionResult ActualizarPartido(string Nombre, string Logo, string SitioWeb, DateTime FechaFundacion, int CantidadDiputados, int CantidadSenadores, string ColorPrimario, string ColorSecundario){
        BD.ActualizarPartido(new Partido(Nombre, Logo, SitioWeb, FechaFundacion, CantidadDiputados, CantidadSenadores, ColorPrimario, ColorSecundario));
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Elecciones(){
        return View();
    }

    public IActionResult Creditos(){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
