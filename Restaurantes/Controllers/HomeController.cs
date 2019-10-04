using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Services;
using Restaurantes.Models;
using System;
using System.Diagnostics;
//Hacer un mesas controller
namespace Restaurantes.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private IRestauranteService _restauranteService;
        private IAsyncRepository _repository;
        private IMesaService _mesaService;

        public HomeController(IRestauranteService restauranteService, IAsyncRepository repository, IMesaService mesaService)
        {
            _restauranteService = restauranteService;
            _repository = repository;
            _mesaService = mesaService;
        }

        public IActionResult Index()
        {
            var restaurantes = _restauranteService.ObtenerRestaurantes();
            return View(restaurantes);
        }

        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("_AgregarEditarRestaurant",new RestauranteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(RestauranteViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Te hacen falta campos");
                }

                var restaurante = new Restaurante
                {
                    Nombre = model.Nombre,
                    Domicilio = model.Domicilio,
                    HoraDeCierre = model.HoraDeCierre,
                    FechaDeAlta = DateTime.Now,
                    Telefono = int.Parse(model.Telefono)
                };
                var respuesta = _restauranteService.Agregar(restaurante);
                return Ok();
            }
            catch(Exception err)
            {
                return BadRequest();
            }

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
                Domicilio = restaurante.Domicilio,
                HoraDeCierre = restaurante.HoraDeCierre.GetValueOrDefault(),
                PaginaWeb = restaurante.PaginaWeb,
                Telefono = restaurante.Telefono.ToString(),
            };
            return View("Agregar", viewModel);
        }

        [HttpGet]
        public IActionResult Perfil(int id)
        {
            ViewData["Accion"] = "Perfil";
            var restaurante = _restauranteService.Obtener(id);

            return View("Restaurant", restaurante);
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

        public IActionResult Mesas(int id)
        {
            ViewData["restauranteId"] = id;

            var restaurante = _restauranteService.Obtener(id);

            return View(restaurante.Mesas);
        }

        public IActionResult AgregarMesa()
        {
            ViewData["Accion"] = "AgregarMesa";
            return PartialView("_AgregarEditarMesa", new MesaViewModel());
        }

        [HttpPost]
        public IActionResult AgregarMesa(MesaViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Te hacen falta campos");
                return View(model);
            }
            var mesa = new Restaurantes.Core.Entities.Mesa()
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = id
            };
            var Id = _mesaService.Agregar(mesa);
            return Ok();
            
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

        public IActionResult Restaurantes()
        {
            var restaurantes = _restauranteService.ObtenerRestaurantes();
            return View(restaurantes);
        }
    }
}