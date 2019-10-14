using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Models;

namespace Controladores.Controllers
{
    public class OrdenesController : Controller
    {
        //public IActionResult Index(int numero, string nombre)
        //{
        //    var orden = new OrdenesViewModel {
        //        nombre = nombre,
        //        numero = numero

        //    };
        //    return View("index",orden);
        //}

        public IActionResult Index(int id)
        {

            return View("index", id);
        }

        public IActionResult OrdenDashboard(int id, int ordenId)
        {

            var model = new OrdenDashboardViewModel() {
                RestauranteId = id,
                OrdenId = ordenId
            };
            return View(model);
        }
        public IActionResult OrdenElement()
        {
            return PartialView("_OrdenElementList");
        }

        public IActionResult ProductCard()
        {
            return PartialView("_ProductoCard");
        }

        public IActionResult ResumenElement()
        {
            return PartialView("_ElementoResumen");
        }

    }
}