using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    [Authorize]
    public class EmpleadosController : Controller
    {
        private IRestauranteService _restauranteService;
        private IEmpleadoService _empleadoService;

        public EmpleadosController(IRestauranteService restauranteService, IEmpleadoService empleadoService)
        {
            _restauranteService = restauranteService;
            _empleadoService = empleadoService;
        }

        public IActionResult Index(int id)
        {
            ViewData["RestauranteId"] = id;
            var restaurante = _restauranteService.Obtener(id);
            return View(restaurante.Empleados);
        }

        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("_AgregarEditarEmpleado", new EmpleadoViewModel());
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var empleado = _empleadoService.Obtener(id);
            var viewModel = new EmpleadoViewModel
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Puesto = empleado.Puesto

            };

            return PartialView("_AgregarEditarEmpleado", viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
