using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            
            _productoService = productoService;

        }

        public IActionResult Productos(int id)
        {
            ViewData["restauranteId"] = id;
            var productos = _productoService.ObtenerProductos(id);
            return View(productos);

        }
        public IActionResult AgregarProducto()
        {

            ViewData["Accion"] = "AgregarProducto";
            return PartialView(new ProductoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarProducto(ProductoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var productos = new Restaurante.Core.Entities.Producto()
            {
                Nombre = model.Nombre,
                Ingredientes = model.Ingredientes,
                Cantidad = model.Cantidad,
                RestauranteId = id


            };
            var Id = _productoService.Agregar(productos);
            return Ok();
        }
        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            ViewData["Accion"] = "EditarProducto";
            var productos = _productoService.Obtener(id);
            var viewModel = new ProductoViewModel
            {
                Nombre = productos.Nombre,
                Cantidad = productos.Cantidad,
                RestauranteId = id,
                Ingredientes = productos.Ingredientes


            };
            return View("AgregarProducto", viewModel);
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
            _productoService.Editar(producto);

            producto.Nombre = model.Nombre;

            producto.Cantidad = model.Cantidad;

            producto.Ingredientes = model.Ingredientes;

            _productoService.Editar(producto);

            return RedirectToAction("Productos");
        }
        [HttpPost]
        public IActionResult EliminarProducto(int id)
        {

            var producto = _productoService.Obtener(id);
            _productoService.Eliminar(producto);
            return RedirectToAction("Productos");
        }
    }
}