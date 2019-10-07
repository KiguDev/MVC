using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.core.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        private IProductosService _productoService;
        public ProductosController(IProductosService productoService)
        {
            _productoService = productoService;
        }
        public IActionResult Index(int id)
        {
            ViewData["resId"] = id;
            var productos = _productoService.ObtenerProducto(id);
            return View(productos);
        }

        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("_AgregarEditarProducto", new ProductoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(ProductoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            model.RestauranteId = id;
            var producto = new Restaurante.core.Entities.Producto
            {
                Nombre = model.Nombre,
                Ingredientes = model.Ingredientes,
                Precio = model.Precio,
                RestauranteId = model.Id
            };

            var empleadoId = _productoService.InsertarProducto(producto);
            return RedirectToAction("/Index/" + model.RestauranteId);
        }

        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            ViewData["Accion"] = "EditarProducto";
            var empleado = _productoService.Obtener(id);
            var viewModel = new ProductoViewModel
            {
                Nombre = empleado.Nombre,
                Ingredientes = empleado.Ingredientes,
                Precio = empleado.Precio,
            };
            return PartialView("_AgregarEditarProducto", viewModel);
        }

        [HttpPost]
        public IActionResult EditarProducto(ProductoViewModel model, int resId)
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

            _productoService.EditarProducto(producto);

            return RedirectToAction("Index/" + producto.RestauranteId);
        }

        [HttpGet]
        public IActionResult EliminarProducto(int id, int resId)
        {
            var eliminarProducto = _productoService.EliminarProducto(id);
            return RedirectToAction("Index/" + resId);
        }
    }
}