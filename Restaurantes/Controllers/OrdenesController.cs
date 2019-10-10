using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class OrdenesController : Controller
    {
        private IRestauranteService _restauranteService;

        public OrdenesController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        public IActionResult Index(int id, int ordenId)
        {
            var nuevaOrden = new OrdenNuevaViewModel()
            {
                RestauranteId = id,
                OrdenId = ordenId
            };
            return View(nuevaOrden);
        }

        public IActionResult Ordenes(int id)
        {
            ViewData["RestauranteId"] = id;
            var restaurante = _restauranteService.Obtener(id);
            return View(restaurante.Ordenes);
        }

        public IActionResult ProductoCard()
        {
            return PartialView("_ProductoCardView");
        }

        public IActionResult OrdenCard()
        {
            return PartialView("_OrdenCardView");
        }
    }
}