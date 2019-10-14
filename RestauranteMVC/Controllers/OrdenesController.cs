using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteMVC.Controllers
{
    public class OrdenesController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }

        public IActionResult Guardar(int id)
        {
            return PartialView();
        }

        public IActionResult Productos(int id)
        {
            return View();
        }
    }
}