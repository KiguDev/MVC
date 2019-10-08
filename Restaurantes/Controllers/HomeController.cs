using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;
using System;
using System.Diagnostics;

namespace Restaurantes.Controllers
{ 
    //[Authorize (Roles="Administrator")]
    public class HomeController : Controller
    {
        private IRestauranteService _restauranteService;
        public HomeController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }


        public IActionResult Index()
        {
            var restaurantes = _restauranteService.ObtenerRestaurantes();
            return View(restaurantes);
            // return View();
        }



        public IActionResult AgregarP()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("AgregarEditarRestaurant", new RestauranteViewModel());
        }


        //Agregar Restaurante
        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return View(new RestauranteViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(RestauranteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var restaurante = new Core.Entities.Restaurante
            {
                Nombre = model.Nombre,
                Domicilio = model.Direccion,
                HoraCierre = model.HoraCierre,
                FechaAlta = DateTime.Now,
                Telefono =  model.Telefono
            };
            var id = _restauranteService.Insertar(restaurante);
            return RedirectToAction("Index");
        }
        //Editar Restaurante
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
                HoraCierre = restaurante.HoraCierre.GetValueOrDefault(),
                PaginaWeb = restaurante.PaginaWeb,
                Telefono = restaurante.Telefono,
            };
            return View("Agregar", viewModel);
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
        //Mesas
        public IActionResult Mesas(int id)
        {
            ViewData["restauranteId"] = id;
            var restaurante = _restauranteService.Obtener(id);

            return View(restaurante.Mesas);
        }

        public IActionResult AgregarMesa(int restaurante, int id)
        {
            return View(new Mesa
            {
                RestauranteId = restaurante
            });
        }

        [HttpPost]
        public IActionResult AgregarMesa(Mesa model)
        {
            // utilizar el servicio de mesa y pbtemer la entidad
            // modificar las propiedades de Mesa con los del view model
            // enviar la entidad al metodo de actualizar del servicio
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

        public IActionResult Restaurantes()
        {
            var restaurantes = _restauranteService.ObtenerRestaurantes();
            return View(restaurantes);
        }
















    }
}