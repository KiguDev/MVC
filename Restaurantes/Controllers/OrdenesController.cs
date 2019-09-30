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

        [Route("peticion")]
        public IActionResult Detalles()
        {
            return View();
        }
    }
}