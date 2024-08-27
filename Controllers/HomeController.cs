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
     public IActionResult VerDetalleDeporte(int idDeporte)
    {
        ViewBag.DatosDeporte = BD.VerInfoDeporte(idDeporte);
        ViewBag.DatosDeportista = BD.ListarDeportistasPorDeporte(idDeporte);
        return View("VerDetalleDeporte");
    }
    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.DetallePais = BD.VerInfoPais(idPais);
        ViewBag.ListaDeportistas = BD.ListarDeportistasPorPais(idPais);
        return View("VerDetallePais");
    }
    public IActionResult VerDetalleDeportista(int idDeportista)
    {
        ViewBag.Datos = BD.VerInfoDeportista(idDeportista);
        return View("VerDetalleDeportista");
    }
    public IActionResult AgregarDeportista()
    {
        ViewBag.ListadoPaises = BD.ListarPaises();
        ViewBag.ListadoDeportes = BD.ListarDeportes();
        return View();
    }
    [HttpPost]
    public IActionResult GuardarDeportista(Deportista dep)
    {
        BD.AgregarDeportista(dep);
        return RedirectToAction("Index");
    }
    public IActionResult EliminarDeportista(int idCandidato)
    {
        BD.EliminarDeportista(idCandidato);
        return RedirectToAction("Index");
    }
    public IActionResult Creditos()
    {
        return View();
    }
}
