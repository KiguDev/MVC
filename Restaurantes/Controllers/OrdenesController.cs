using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;

namespace Restaurantes.Controllers
{
    public class OrdenesController : Controller
    {
        private IRestauranteService _restauranteService;

        public OrdenesController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        public IActionResult Index(int id)
        {
            ViewData["RestauranteId"] = id;
            return View();
        }

        public IActionResult Ordenes(int id)
        {
            ViewData["RestauranteId"] = id;
            var restaurante = _restauranteService.Obtener(id);
            return View(restaurante.Ordenes);
        }
    }
}