using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class HomeController : Controller
    {
        private IRestauranteService _restauranteServices;
        private IMesaService _mesaServices;
        public HomeController(IRestauranteService restauranteService, IMesaService mesaService)
        {
            _restauranteServices = restauranteService;
            _mesaServices = mesaService;
        }
        public IActionResult Index()
        {
            var restaurante = _restauranteServices.ObtenerRestaurantes();
            return View(restaurante);
        }

        #region CRUDMesas

        public IActionResult Mesas(int id)
        {
            ViewData["resId"] = id;
            var mesas = _mesaServices.ObtenerMesas(id);
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


            model.RestauranteId = id;

            var mesa = new Restaurante.Core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = model.RestauranteId
            };
            var respuesta = _mesaServices.insertar(mesa);

            return View("AgregarMesa", model);
        }


        public IActionResult EditarMesa(int id)
        {
            ViewData["Accion"] = "EditarMesa";
            var mesa = _mesaServices.Obtener(id);
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
                return View("Agregar", model);
            }
            var mesa = _mesaServices.Obtener(model.Id);


            mesa.Identificador = model.Identificador;
            mesa.Capacidad = model.Capacidad;
           
            _mesaServices.Editar(mesa);


            return RedirectToAction("Mesas", new { id = model.RestauranteId});
        }
        [HttpPost]
        public IActionResult EliminarMesa(int id)
        {
            _mesaServices.Eliminar(id);
            return RedirectToAction("Mesas", new { id = ViewData["resId"] });
        }
        #endregion 

        

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
            model.FechaAlta = DateTime.Now;

            var restaurante = new Restaurante.Core.Entities.Restaurante {
                Nombre = model.Nombre,
                Domicilio = model.Direccion,
                Telefono = model.Telefono,
                Logo = model.Logo,
                PaginaWeb = model.PaginaWeb,
                FechaAlta = model.FechaAlta,
                HoraCierre = model.HoraCierre
                
            };
            var respuesta = _restauranteServices.insertar(restaurante);
            
            return View("Agregar", model);
        }


        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var restaurante = _restauranteServices.Obtener(id);
            var viewModel = new RestauranteViewModel {
                Id = restaurante.Id,
                Nombre = restaurante.Nombre,
                Direccion = restaurante.Domicilio,
                Telefono = restaurante.Telefono,
                Logo = restaurante.Logo,
                PaginaWeb = restaurante.PaginaWeb,
                FechaAlta = restaurante.FechaAlta,
                HoraCierre = restaurante.HoraCierre.GetValueOrDefault()
            };

            return View("Agregar", viewModel);

        }

        [HttpPost]
        public IActionResult Editar(RestauranteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View("Agregar",model);
            }
            var restaurante = _restauranteServices.Obtener(model.Id);


            restaurante.Nombre = model.Nombre;
            restaurante.Domicilio = model.Direccion;
            restaurante.Telefono = model.Telefono;
            restaurante.Logo = model.Logo;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.FechaAlta = model.FechaAlta;
            restaurante.HoraCierre = model.HoraCierre;
            _restauranteServices.Editar(restaurante);
            

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Eliminar (int id)
        {
            _restauranteServices.Eliminar(id);
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
