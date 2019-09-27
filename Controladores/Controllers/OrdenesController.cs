using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Controladores.Controllers
{
    public class OrdenesController : Controller
    {
        public IActionResult Index(int id)
        {
            return View(id);
        }

        [HttpPost]
        [Route("peticion")]
        public IActionResult Detalles()
        {
            return View();
        }
    }
}