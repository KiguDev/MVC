using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.core.Interfaces;

namespace RestauranteMVC.Controllers
{
    [Authorize]
    public class OrdenesController : Controller
    {
        private IOrdenesService _ordenService;
        public OrdenesController(IOrdenesService ordenService)
        {
            _ordenService = ordenService;
        }
        public IActionResult Index(int id)
        {
            ViewData["resId"] = id;
            var productos = _ordenService.ObtenerTodas(id);
            return View(productos);
        }
    }
}