using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestauranteService _restauranteService;
        private IAsyncRepository _repository;
        private IMesaService _mesaService;

        public HomeController(IRestauranteService restauranteService,
            IMesaService mesaService, IAsyncRepository asyncRepository)
        {
            _restauranteService = restauranteService;
            _mesaService = mesaService;
            _repository = asyncRepository;
        }

        public IActionResult Index()
        {
            var restaurantes =_restauranteService.ObtenerRestaurantes();
            return View(restaurantes);
        }

        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("_AgregarEditarRestaurante",new RestauranteViewModel());
        }

        public IActionResult Perfil(int id)
        {
            ViewData["Accion"] = "Perfil";
            ViewData["RestauranteId"] = id;
            var restaurante = _restauranteService.Obtener(id);
            return View("Perfil",restaurante);
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
                    Domicilio = model.Direccion,
                    HoraDeCierre = model.HoraDeCierre,
                    FechaDeAlta = DateTime.Now,
                    Telefono = int.Parse(model.Telefono)
                };
                var id = _restauranteService.Agregar(restaurante);
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
            restaurante.Domicilio = model.Direccion;
            restaurante.Telefono = int.Parse(model.Telefono);
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.HoraDeCierre = model.HoraDeCierre;
            _restauranteService.Editar(restaurante);

            return RedirectToAction("Index");
        }


        public IActionResult Eliminar(int id)
        {
            ViewData["Accion"] = "Eliminar";
            var restaurante = _restauranteService.Obtener(id);
            _restauranteService.Eliminar(restaurante);
            return RedirectToAction("Index");
        }

        public IActionResult Mesas(int id)
        {
            ViewData["RestauranteId"] = id;
            var restaurante = _restauranteService.Obtener(id);
            return View(restaurante.Mesas);
        }

        public IActionResult AgregarMesa(int id)
        {
            ViewData["Accion"] = "AgregarMesa";
            return PartialView("_AgregarEditarMesa",new MesaViewModel
            {
                RestauranteId = id
            });
        }

        [HttpPost]
        public IActionResult AgregarMesa(MesaViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var mesa = new Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = id
            };
            var resId = _mesaService.Agregar(mesa);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditarMesa(int id)
        {
            ViewData["Accion"] = "EditarMesa";
            var mesa = _mesaService.Obtener(id);
            var viewModel = new MesaViewModel
            {
                Id = mesa.Id,
                Identificador = mesa.Identificador,
                Capacidad = mesa.Capacidad
                
            };

            return View("AgregarMesa", viewModel);
        }

        [HttpPost]
        public IActionResult EditarMesa(MesaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var mesa = _mesaService.Obtener(model.Id);
            mesa.Identificador = model.Identificador;
            mesa.Capacidad = model.Capacidad;
            _mesaService.Editar(mesa);

            return RedirectToAction("Index");
        }

        public IActionResult EliminarMesa(int id)
        {
            ViewData["Accion"] = "EliminarMesa";
            var mesa = _mesaService.Obtener(id);
            _mesaService.Eliminar(mesa);
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
