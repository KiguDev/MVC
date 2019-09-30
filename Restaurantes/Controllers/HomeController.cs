using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class HomeController : Controller
    {

        private IRestauranteService _restauranteService;
        private IMesaService _mesaService;

        public HomeController(IRestauranteService restauranteService, IMesaService mesaService)
        {
            _restauranteService = restauranteService;
            _mesaService = mesaService;
        }
        public IActionResult Index()
        {
            var restaurantes = _restauranteService.ObtenerRestaurantes();
            return View(restaurantes);
        }

        public IActionResult Mesas(int id)
        {
            ViewData["restauranteId"]= id;
            var mesas = _mesaService.ObtenerMesas();
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
            
            var mesas = new Restaurante.Core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = id
            };

            var resp = _mesaService.Insertar(mesas);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditarMesa(int id)
        {
            ViewData["Accion"] = "EditarMesa";
            var mesa = _mesaService.Obtener(id);
            var viewModel = new MesaViewModel
            {
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

        [HttpPost]
        public IActionResult EliminarMesa(int id)
        {
            var mesa = _mesaService.Obtener(id);
            _mesaService.Eliminar(mesa);
            return RedirectToAction("Index");
        }
        /***********************************/
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
            var restaurante = new Restaurante.Core.Entities.Restaurante
            {
                Nombre = model.Nombre,
                Domicilio = model.Direccion,
                HoraDeCierre = model.HoraDeCierre,
                Telefono = model.Telefono,
                FechaDeAlta = DateTime.Now
            };
           
            var id = _restauranteService.Insertar(restaurante);
            return View(model);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var restaurante = _restauranteService.Obtener(id);
            var viewModel = new RestauranteViewModel
            {
                Nombre = restaurante.Nombre,
                Direccion = restaurante.Domicilio,
                HoraDeCierre = restaurante.HoraDeCierre.GetValueOrDefault(),
                PaginaWeb = restaurante.PaginaWeb,
                Telefono = restaurante.Telefono
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
            restaurante.Domicilio = model.Direccion;
            restaurante.Telefono = model.Telefono;
           

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
