using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        private IRestauranteService _restauranteService;
        private IProductoService _productoService;

        public ProductosController(IRestauranteService restauranteService, IProductoService productoService)
        {
            _restauranteService = restauranteService;
            _productoService = productoService;
        }

        public IActionResult Index(int id)
        {
            ViewData["RestauranteId"] = id;
            var restaurante = _restauranteService.Obtener(id);
            return View(restaurante.Productos);
        }

        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("_AgregarEditarProducto", new ProductoViewModel());
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var producto = _productoService.Obtener(id);
            var viewModel = new ProductoViewModel
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio

            };

            return PartialView("_AgregarEditarProducto", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
