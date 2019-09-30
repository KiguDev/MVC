using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controladores.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controladores.Controllers
{
    public class RestauranteController : Controller
    {
        public IActionResult Index()
        {
            var restaurante = new RestauranteViewModel {
                Nombre = "Luigi's Pizza",
                Direccion = "Ave ejemplo",
                NumeroExterior = 123,
                TipoDeComida = "Torta",
                FechaDeAlta = DateTime.Now,
                Ordenes = new List<int>
                {
                    1,
                    5,
                    6
                }
            };
            return View(restaurante);
        }
    }
}