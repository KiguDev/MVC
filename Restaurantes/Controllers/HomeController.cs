using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Infrastructure.Services;
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
        private IEmpleadoService _empleadoService;
        private IProductoService _productoservice;
        public HomeController(IRestauranteService restauranteService, IProductoService productoService, IEmpleadoService empleadoservice)
        {
            _restauranteService = restauranteService;
            _empleadoService = empleadoservice;
            _productoservice = productoService;



        }

        //Index
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
            return View("Agregar", new RestauranteViewModel());
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
                    PaginaWeb = model.PaginaWeb,
                    Logo = model.Logo,
                    HoraCierre = model.HoraCierre,
                    FechaAlta = DateTime.Now,
                    Telefono = model.Telefono
                };
            _restauranteService.Insertar(restaurante);
            return RedirectToAction("Index");
        }






        



        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            _restauranteService.Eliminar(id);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult ElminarVarios([FromBody]int[] ids)
        {
            _restauranteService.EliminarVarios(ids);
            return Ok("OK");
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
                Logo = restaurante.Logo,
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
            restaurante.Logo = model.Logo;
            restaurante.Nombre = model.Nombre;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.Domicilio = model.Direccion;
            restaurante.Telefono = model.Telefono;
            restaurante.HoraCierre = model.HoraCierre;
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

        public IActionResult Restaurantes()
        {
            var restaurantes = _restauranteService.ObtenerRestaurantes();
            return View(restaurantes);
        }
















    }
}