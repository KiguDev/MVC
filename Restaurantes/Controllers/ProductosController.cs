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

        private readonly IProductoService _productoService;
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        public IActionResult Index(int id)
        {
            ViewData["resId"] = id;
            var productos = _productoService.ObtenerProductos(id);
          
            return View(productos);
          
        }

        public IActionResult AgregarM()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("_AgregarEditarProducto", new ProductoViewModel());
        }


        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var producto = _productoService.Obtener(id);
            var viewModel = new ProductoViewModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Imagen = producto.Imagen
            };

            return PartialView("_AgregarEditarProducto", viewModel);

        }
    }
}