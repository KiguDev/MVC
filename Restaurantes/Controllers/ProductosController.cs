using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class ProductosController : Controller
    {
        private IProductoService _productoService;
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public IActionResult Index(int id)
        {
            ViewData["RestauranteId"] = id;
            var productos = _productoService.ObtenerProductos(id);
            return View(productos);
        }

        public IActionResult AgregarProducto(int id)
        {
            ViewData["Accion"] = "Agregar";

            var model = new ProductoViewModel();
            model.RestauranteId = id;
            return PartialView("_AgregarEditarProducto", model);
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
            var producto = new Restaurante.Core.Entities.Producto
            {
                Nombre = model.Nombre,
                Ingredientes = model.Ingredientes,
                Precio = model.Precio,
                RestauranteId = model.RestauranteId
            };
            var respuesta = _productoService.insertar(producto);

            return View("AgregarProducto", model);
        }


        public IActionResult EditarProducto(int id)
        {
            ViewData["Accion"] = "EditarProducto";
            var producto = _productoService.Obtener(id);
            var viewModel = new ProductoViewModel
            {

                Id = producto.Id,
                Nombre = producto.Nombre,
                Ingredientes = producto.Ingredientes,
                Precio = producto.Precio
            };

            return View("Agregar", viewModel);

        }

        [HttpPost]
        public IActionResult EditarProducto(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View("Agregar", model);
            }
            var producto = _productoService.Obtener(model.Id);
            producto.Nombre = model.Nombre;
            producto.Ingredientes = model.Ingredientes;
            producto.Precio = model.Precio;

            _productoService.Editar(producto);


            return RedirectToAction("Index", new { Id = producto.RestauranteId });
        }
        [HttpPost]
        public IActionResult EliminarProducto(int id)
        {
            var resId = _productoService.Obtener(id).RestauranteId;
            _productoService.Eliminar(id);
            return RedirectToAction("Index", new { Id = resId });
        }
    }
}