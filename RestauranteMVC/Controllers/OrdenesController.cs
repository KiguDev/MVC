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
            return View("Index",id);
        }

        public IActionResult ProductoView()
        {
            return PartialView("_ViewProducto");
        }

        public IActionResult ProductoAddView()
        {
            return PartialView("_ViewAddProducto");
        }

        public IActionResult OrdenesView()
        {
            return PartialView("_ViewOrdenes");
        }

        public IActionResult EditarOrdenView()
        {
            return PartialView("_ViewEditOrden");
        }
    }
}