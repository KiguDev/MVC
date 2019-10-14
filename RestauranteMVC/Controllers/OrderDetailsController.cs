using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteMVC.Controllers
{
    public class OrderDetailsController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}