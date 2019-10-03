using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestauranteService _restauranteService;
        private IMesasService _mesasService;
        private IAsyncRepository _asyncRepository;


        public HomeController(IRestauranteService restauranteService, IMesasService mesasService, IAsyncRepository asyncRepository)
        {
            _restauranteService = restauranteService;
            _mesasService = mesasService;
            _asyncRepository = asyncRepository;
        }

        public IActionResult Index()
        {
            //var restaurantes = _restauranteService.ObtenerRestaurantes();
            _asyncRepository.ListAllASync<>();
                
            return View(restaurantes);
        }

        public IActionResult Info()
        {
            return View();
        }
        
        public IActionResult Mesas(int id)
        {
            ViewData["restauranteId"] = id;
            var mesas = _mesasService.ObtenerMesas();
            return View(mesas);
            
        }
        public IActionResult AgregarMesa()
        {
       
            ViewData["Accion"] = "AgregarMesa";
            return View(new MesaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarMesa(MesaViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var mesas = new Restaurante.Core.Entities.Mesa()
            {
                Capacidad = model.Capacidad,
                Identificador = model.Identificador,
                RestauranteId = id
               
             
            };
            var Id = _mesasService.Agregar(mesas);
            return View(model);
        }
        [HttpGet]
        public IActionResult EditarMesa(int id)
        {
            ViewData["Accion"] = "EditarMesa";
            var mesas = _mesasService.Obtener(id);
            var viewModel = new MesaViewModel
            {
                
                Capacidad = mesas.Capacidad,
                Identificador = mesas.Identificador,
                
                
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
            var mesa = _mesasService.Obtener(model.Id);
            _mesasService.Editar(mesa);
           
            mesa.Identificador = model.Identificador;
            
            mesa.Capacidad = model.Capacidad;

            _mesasService.Editar(mesa);
          
            return RedirectToAction("Mesas");
        }
        [HttpPost]
        public IActionResult EliminarMesa(int id)
        {

            var mesa = _mesasService.Obtener(id);
            _mesasService.Eliminar(mesa);
            return RedirectToAction("Mesas");
        }

        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return View(new RestaurantesViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(RestaurantesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var restaurante = new Restaurante.Core.Entities.Restaurante
            {
                Nombre = model.Nombre,
                Domicilio = model.Direccion,
                Telefono = int.Parse(model.Telefono),
                HoraDeCierre = model.HoraDeCierre,
                FechaDeAlta = DateTime.Now
            };

            var id = _asyncRepository.AddASync(restaurante);
            //var id = _restauranteService.Agregar(restaurante);
            return View(model);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var restaurantes = _restauranteService.Obtener(id);
            var viewModel = new RestaurantesViewModel
            {
                Id = restaurantes.Id,
                Nombre = restaurantes.Nombre,
                Direccion = restaurantes.Domicilio,
                HoraDeCierre = restaurantes.HoraDeCierre.GetValueOrDefault(),
                PaginaWeb = restaurantes.PaginaWeb,
                Telefono = restaurantes.Telefono.ToString()
            };
            return View("Agregar", viewModel);
        }

        [HttpPost]
        public IActionResult Editar(RestaurantesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var restaurante = _restauranteService.Obtener(model.Id);
            restaurante.Nombre = model.Nombre;
            restaurante.Id = model.Id;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.HoraDeCierre = model.HoraDeCierre;
            restaurante.Telefono = int.Parse(model.Telefono);
            _restauranteService.Editar(restaurante);
            

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
           
            var restaurante = _restauranteService.Obtener(id);
            _restauranteService.Eliminar(restaurante);
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
