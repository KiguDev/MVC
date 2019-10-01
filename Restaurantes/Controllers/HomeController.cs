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
        private readonly IMapper mapper;


        public RestaurantesController(IRestauranteService, IMapper maper);
            {
            _restauranteService = IRestauranteService
            _maper = mapper;
           }

        public HomeController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        public IActionResult Index()
        {
            var restaurantes =_restauranteService.ObtenerRestaurantes();
            return View(restaurantes);
        }

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
            return View();
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

        public IActionResult AgregarMesa(int restaurante)
        {

            return View(new Mesa {
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

/// <summary>
/// //Empleado
/// ____________________________________________________________________________________________
/// </summary>
/// <returns></returns>
/// 

         //
        public IActionResult Empleados()
        {
            var empleados = _restauranteService.ObtenerEmpleado();
            return View(empleados);
        }


        //Agregar Empleado
        public IActionResult AgregarEmpleado()
        {
            ViewData["Accion"] = "AgregarEmpleado";
            return View(new EmpleadoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var empleado = new Empleado
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Puesto = model.Puesto,
                Restaurante = model.Restaurante
               
            };
            var id = _restauranteService.Agregar(empleado);
            return View(model);
        }
        //
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
            return View();
        }

        //Editar Empleado
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
