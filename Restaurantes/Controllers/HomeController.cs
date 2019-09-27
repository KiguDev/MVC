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
            ViewData["Accion"] = "Agregar";
            return View(new RestauranteViewModel());
        }

        [HttpPost]
        public IActionResult Agregar(RestauranteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Te hacen falta campos");
                return View(model);
            }

            var restaurante = new Restaurante {
                Nombre = model.Nombre,
                Domicilio = model.Direccion,
                HoraDeCierre = model.HoraDeCierre,
                FechaDeAlta = DateTime.Now,
                Telefono = int.Parse(model.Telefono)
            };
            var id = _restauranteService.Agregar(restaurante);
            return View(model);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var restaurante = _restauranteService.Obtener(id);

            var viewModel = new RestauranteViewModel
            {
                Id = restaurante.Id,
                Nombre = restaurante.Nombre,
                Direccion = restaurante.Domicilio,
                HoraDeCierre = restaurante.HoraDeCierre.GetValueOrDefault(),
                PaginaWeb = restaurante.PaginaWeb,
                Telefono = restaurante.Telefono.ToString(),
            };
            return View("Agregar",viewModel);
        }

        [HttpPost]
        public IActionResult Editar(RestauranteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var restaurante = _restauranteService.Obtener(model.Id);
            restaurante.Nombre = model.Nombre;

            _restauranteService.Editar(restaurante);

            return RedirectToAction("Index");
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
