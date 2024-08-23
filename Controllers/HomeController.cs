using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Deportes()
    {
        ViewBag.Deportes = BD.ListarDeportes();
        return View();
    }
    public IActionResult Paises()
    {
        ViewBag.Paises = BD.ListarPaises(); 
        return View();
    }
     public IActionResult VerDetalleDeporte(int idDeportista)
    {
        ViewBag.DatosDeporte = BD.VerInfoDeporte(idDeportista);
        ViewBag.DatosDeportista = BD.ListarDeportistasPorDeporte(idDeportista);
        return View("DetalleDeporte");
    }
    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.DetallePais = BD.VerInfoPais(idPais);
        ViewBag.ListaDeportistas = BD.ListarDeportistasPorPais(idPais);
        return View("DetallePais");
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult VerDetalleDeportista(int idDeportista)
    {
        ViewBag.Datos = BD.VerInfoDeportista(idDeportista);
        return View("DetalleDeportista");
    }
}
