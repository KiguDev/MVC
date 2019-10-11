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
    public class HomeController : Controller
    {
        private IRestauranteService _restauranteService;
        private IProductoService _productoService;
        private IAsyncRepository _repository;
        private IMesaService _mesaService;
        private IEmpleadoService _empleadoService;
        private IOrdenService _ordenService;
        private IOrdenTieneProductoService _ordenTieneProductoService;

        public HomeController(IRestauranteService restauranteService, IAsyncRepository repository, IMesaService mesaService, IProductoService productoService, IEmpleadoService empleadoService, IOrdenService ordenService, IOrdenTieneProductoService ordenTieneProductoService)
        {
            _restauranteService = restauranteService;
            _repository = repository;
            _mesaService = mesaService;
            _productoService = productoService;
            _empleadoService = empleadoService;
            _ordenService = ordenService;
            _ordenTieneProductoService = ordenTieneProductoService;
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
            catch(Exception)
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

        [HttpPost]
        public IActionResult AgregarEmpleado(EmpleadoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var empleado = new Restaurantes.Core.Entities.Empleado()
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto,
                RestauranteId = id
            };
            var Id = _empleadoService.Agregar(empleado);
            return Ok();

        }

        [HttpGet]
        public IActionResult EditarEmpleado(int id)
        {
            ViewData["Accion"] = "EditarEmpleado";
            var empleado = _empleadoService.Obtener(id);

            var viewModel = new EmpleadoViewModel
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Puesto = empleado.Puesto,
                RestauranteId = empleado.RestauranteId,
            };
            return View("EditarEmpleado", viewModel);
        }


        [HttpPost]
        public IActionResult EditarEmpleado(EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var empleado = _empleadoService.Obtener(model.Id);
            empleado.Nombre = model.Nombre;
            empleado.Puesto = model.Puesto;
            _empleadoService.Editar(empleado);

            return RedirectToAction("Mesas");
        }

        public IActionResult Productos(int id)
        {
            ViewData["restauranteId"] = id;
            //ViewData["Accion"] = "ProductosRes";
            return View("ProductosRes",id);
        }

        [Route("ProductosView")]
        public IActionResult ProductosView(int id)
        {
            ViewData["restauranteId"] = id;
            return View("ProductosView", id);
        }

        [Route("ProductosOrdenView")]
        public IActionResult ProductosOrdenView(int id)
        {
            ViewData["restauranteId"] = id;
            return PartialView("ProductosView", id);
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

        [HttpPost]
        public IActionResult EditarProducto(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var producto = _productoService.Obtener(model.Id);
            producto.Nombre = model.Nombre;
            producto.Ingredientes = model.Ingredientes;
            producto.Precio = model.Precio;
            producto.Cantidad = model.Cantidad;
            _productoService.Editar(producto);

            return RedirectToAction("ProductosRes");
        }


        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            ViewData["Accion"] = "EditarProducto";
            var producto = _productoService.Obtener(id);

            var viewModel = new ProductoViewModel
            {
                Id = producto.Id,
                Cantidad = producto.Cantidad,
                Ingredientes = producto.Ingredientes,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                RestauranteId = producto.RestauranteId,
            };
            return View("EditarProducto", viewModel);
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
                Capacidad = mesa.Capacidad,
                RestauranteId = mesa.RestauranteId,
            };
            return View("EditarMesa", viewModel);
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

            return RedirectToAction("Mesas", "Home", new { @id = model.RestauranteId });
        }

        //[HttpGet]
        //public IActionResult EditarProducto(int id)
        //{
        //    ViewData["Accion"] = "EditarProducto";
        //    var producto = _productoService.Obtener(id);

        //    var viewModel = new ProductoViewModel
        //    {
        //        Id = producto.Id,
        //        Nombre = producto.Nombre,
        //        Precio = producto.Precio,
        //        Ingredientes = producto.Ingredientes,
        //        Cantidad = producto.Cantidad,
        //    };
        //    return View("EditarProducto", viewModel);
        //}

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

        //Ordenes
        public IActionResult Ordenes(int id)
        {
            ViewData["restauranteId"] = id;
            return View("Ordenes", id);
        }

        public IActionResult OrdenesView(int id)
        {
            ViewData["restauranteId"] = id;
            return PartialView("OrdenesView", id);
        }

        public IActionResult AgregarOrden()
        {
            ViewData["Accion"] = "AgregarOrden";
            return PartialView("_AgregarEditarOrden", new OrdenViewModel());
        }

        [HttpPost]
        public IActionResult AgregarOrden(OrdenViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var orden = new Restaurantes.Core.Entities.Orden()
            {
                Total = model.Total,
                Estatus = model.Estatus,
                FechaAlta = model.FechaAlta,
                RestauranteId = id
            };
            var Id = _ordenService.Agregar(orden);
            return Ok();

        }

        public IActionResult OrdenTieneProductos(string id, string resid)
        {
            var orden = new Orden();
            orden.Id = Convert.ToInt32(id);
            orden.RestauranteId = Convert.ToInt32(resid);
            return View("OrdenTieneProductos", orden);
        }

        public IActionResult OrdenTieneProductosView(int id)
        {
            ViewData["ordenId"] = id;
            return PartialView("OrdenTieneProductosView", id);
        }



    }
}