using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Controladores.Models;

namespace Controladores.Controllers
{
    public class RestauranteController : Controller
    {
        public IActionResult Index()
        {
            var restaurante = new RestauranteViewModel {
                Nombre = "Sushi Alfa",
                Direccion = "Calle 123 Colonia 22000",
                NumeroExterior = 123,
                TipoDeComida = "Japonesa",
                FechaDeAlta = DateTime.Now,
                Ordenes = new List<int> {
                1,
                2,
                3,
                4,
                5,
                6}
        };
            return View(restaurante);
        }

        
    }
}