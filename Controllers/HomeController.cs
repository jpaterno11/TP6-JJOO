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
        ViewBag.Deportes = "";
        return View();
    }
    public IActionResult Paises()
    {
        ViewBag.Paises = null; 
        return View();
    }
     public IActionResult VerDetalleDeporte(int idDeportista)
    {
        ViewBag.DatosDeporte = "datos";
        ViewBag.DatosDeportista = "datos";
        return View("DetalleDeporte");
    }
    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.DetallePais = null;
        ViewBag.ListaDeportistas = null;
        return View("DetallePais");
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult VerDetalleDeportista(int idDeportista)
    {
        ViewBag.Datos = "datos";
        return View("DetalleDeportista");
    }
}
