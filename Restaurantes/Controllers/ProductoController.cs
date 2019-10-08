using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Services;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoService _productoService;
        private IRestauranteService _restauranteService;
        private IAsyncRepository _repository;

        public ProductoController(IRestauranteService restauranteService, IProductoService productoService, IAsyncRepository repository)
        {
            _productoService = productoService;
            _repository = repository;
            _restauranteService = restauranteService;
        }

        public IActionResult Productos(int id)
        {
            ViewData["restauranteId"] = id;

            var restaurante = _restauranteService.Obtener(id);

            return View(restaurante.Productos);
        }

    }
}