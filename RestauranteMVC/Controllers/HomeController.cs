using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRestauranteService _restauranteService;
        private readonly IMesasService _mesaService;

        public HomeController(IRestauranteService restauranteService, IMesasService mesasService)
        {
            _restauranteService = restauranteService;
            _mesaService = mesasService;
        }

        public IActionResult Profile([FromQuery] int id)
        {
            var restaurante = _restauranteService.Obtener(id);
            return View(restaurante);
        }
        public IActionResult Index()
        {
            var restaurantes = _restauranteService.ObtenerRestaurantes();

            return View(restaurantes);
        }
        public IActionResult Mesas(int id)
        {
            var mesas = _mesaService.GetMesas(id);
            return View(mesas);
        }
        [HttpGet]
        public IActionResult Agregar(int id)
        {
            ViewData["Accion"] = "Agregar";
            var restaurante = _restauranteService.Obtener(id);
            var restauranteModel = new RestauranteViewModel();
            if (restaurante != null)
            {
                restauranteModel.Domicilio = restaurante.Domicilio;
                restauranteModel.Nombre = restaurante.Nombre;
                restauranteModel.Telefono = restaurante.Telefono;
                restauranteModel.PaginaWeb = restaurante.PaginaWeb;
                restauranteModel.Logo = restaurante.Logo;
                restauranteModel.Id = restaurante.Id;
            }
            return PartialView(restauranteModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(RestauranteViewModel restaurante)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Missing fields");
                return View(restaurante);
            }
            var Restaurante = new Restaurante.Core.Entities.Restaurante
            {
                Domicilio = restaurante.Domicilio,
                Nombre = restaurante.Nombre,
                Telefono = restaurante.Telefono,
                PaginaWeb = restaurante.PaginaWeb
            };
            Restaurante.FechaDeAlta = DateTime.Now;
            _restauranteService.InsertRecord(Restaurante);
            _restauranteService.SaveChanges();
            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewData["Accion"] = "Update";
            var restaurante = _restauranteService.Obtener(id: id);
            var viewModel = new RestauranteViewModel
            {
                Domicilio = restaurante.Domicilio,
                FechaDeAlta = restaurante.FechaDeAlta,
                Logo = restaurante.Logo,
                Nombre = restaurante.Nombre,
                PaginaWeb = restaurante.PaginaWeb,
                Telefono = restaurante.Telefono,
                Id = restaurante.Id,
                IsEditar = true
            };
            return View("Agregar", viewModel);
        }
        [HttpPost]
        public IActionResult Update(RestauranteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Missing fields");
            }
            var restaurante = _restauranteService.Obtener(viewModel.Id);
            restaurante.Nombre = viewModel.Nombre;
            restaurante.Domicilio = viewModel.Domicilio;
            restaurante.Telefono = viewModel.Telefono;
            restaurante.PaginaWeb = viewModel.PaginaWeb;
            restaurante.Logo = viewModel.Logo;
            _restauranteService.Edit(restaurante: restaurante);
            _restauranteService.SaveChanges();
            return Redirect("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewData["Accion"] = "Delete";
            var restaurante = _restauranteService.Obtener(id: id);
            var viewModel = new RestauranteViewModel
            {
                Domicilio = restaurante.Domicilio,
                FechaDeAlta = restaurante.FechaDeAlta,
                Logo = restaurante.Logo,
                Nombre = restaurante.Nombre,
                PaginaWeb = restaurante.PaginaWeb,
                Telefono = restaurante.Telefono,
                Id = restaurante.Id,
                IsEditar = true
            };
            return View("Agregar", model: viewModel);
        }
        [HttpPost]
        public IActionResult Delete(RestauranteViewModel viewModel)
        {
            var restaurante = _restauranteService.Obtener(viewModel.Id);
            _restauranteService.Delete(restaurante);
            _restauranteService.SaveChanges();
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult GuardarMesa(int id)
        {
            var mesa = _mesaService.GetMesa(id);
            MesaViewModel mesaNueva;
            if (mesa == null)
            {
                mesaNueva = new MesaViewModel();
            }
            else
            {
                mesaNueva = new MesaViewModel
                {
                    Capacidad = mesa.Capacidad,
                    Id = mesa.Id,
                    Identificador = mesa.Identificador,
                    RestauranteId = mesa.RestauranteId,
                };
            }
            return PartialView(mesaNueva);
        }

        [HttpPost]
        public IActionResult GuardarMesa(MesaViewModel viewModel)
        {
            Mesa mesaNueva = new Mesa()
            {
                Capacidad = viewModel.Capacidad,
                Identificador = viewModel.Identificador,
                RestauranteId = viewModel.RestauranteId,
                Restaurante = _restauranteService.Obtener(viewModel.RestauranteId)
            };
            _mesaService.Insert(mesa:mesaNueva);
            _mesaService.SaveChanges();
            return Redirect($"Mesas?id={viewModel.RestauranteId}");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
