using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class HomeController : Controller
    {
        private IRestauranteService _restauranteService;

        public HomeController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        public IActionResult Index()
        {
            var restaurantes =_restauranteService.ObtenerRestaurantes();
            return View(restaurantes);
        }

        public IActionResult Mesas(int id)
        { 
            return View();
        }

        public IActionResult Agregar()
        {
            return View(new Restaurante());
        }

        [HttpPost]
        public IActionResult PostAgregar(Restaurante model)
        {
            model.FechaDeAlta = DateTime.Now;
            var id = _restauranteService.Agregar(model);
            return View("Agregar", model);
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
}
