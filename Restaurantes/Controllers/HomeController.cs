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
        private IProductoService _productoService;
        private IAsyncRepository _repository;
        private IMesaService _mesaService;

        public HomeController(IRestauranteService restauranteService, IAsyncRepository repository, IMesaService mesaService, IProductoService productoService)
        {
            _restauranteService = restauranteService;
            _repository = repository;
            _mesaService = mesaService;
            _productoService = productoService;
            
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

        public IActionResult Empleados(int id)
        {
            ViewData["restauranteId"] = id;
            //ViewData["Accion"] = "ProductosRes";
            return View("Empleados", id);
        }

        public IActionResult AgregarEmpleado()
        {
            ViewData["Accion"] = "AgregarEmpleado";
            return PartialView("_AgregarEditarEmpleado", new EmpleadoViewModel());
        }

        public IActionResult Productos(int id)
        {
            ViewData["restauranteId"] = id;
            //ViewData["Accion"] = "ProductosRes";
            return View("ProductosRes",id);
        }


        public IActionResult AgregarProducto()
        {
            ViewData["Accion"] = "AgregarProducto";
            return PartialView("_AgregarEditarProducto", new ProductoViewModel());
        }

        [HttpPost]
        public IActionResult AgregarProducto(ProductoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var producto = new Restaurantes.Core.Entities.Producto()
            {
                Nombre = model.Nombre,
                Ingredientes = model.Ingredientes,
                Cantidad = model.Cantidad,
                Precio = model.Precio,
                RestauranteId = id
            };
            var Id = _productoService.Agregar(producto);
            return Ok();

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
            return View("EditarMesa", viewModel);
        }

        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            ViewData["Accion"] = "EditarProducto";
            var producto = _productoService.Obtener(id);

            var viewModel = new ProductoViewModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Ingredientes = producto.Ingredientes,
                Cantidad = producto.Cantidad,
            };
            return View("EditarProducto", viewModel);
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