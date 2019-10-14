using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IRestauranteService _restauranteService;
        public EmpleadoController(IEmpleadoService empleadoService, IRestauranteService restauranteService)
        {
            _empleadoService = empleadoService;
            _restauranteService = restauranteService;
        }
        public IActionResult Index(int id)
        {
         
            return View();
        }

        public IActionResult Agregar(int id)
        {
            var empleado = _empleadoService.GetEmpleado(id);
            EmpleadoViewModel model;
            if(empleado != null)
            {
                model = new EmpleadoViewModel
                {
                    Nombre = empleado.Nombre,
                    Puesto = empleado.Puesto,
                    RestauranteId = empleado.RestauranteId
                };
            }
            else
            {
                model = new EmpleadoViewModel();
            }
            return PartialView(model);
        }
    }
}