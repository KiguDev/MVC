using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    [Authorize(Roles="Administrator")]
    public class EmpleadoController : Controller
    {
        private IEmpleadoService _empleadoService;


        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }


        public IActionResult Index()
        {
            var empleados = _empleadoService.ObtenerEmpleados();

            return View(empleados);
        }

        public IActionResult Empleados(int id)
        {
            ViewData["restauranteId"] = id;
            var empleados = _empleadoService.ObtenerEmpleados();
            return View(empleados);
        }
        
        [HttpGet]

        public IActionResult AgregarEmpleado()
        {
            ViewData["Accion"] = "AgregarEmpleado";
            return View(new EmpleadoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarEmpleado(EmpleadoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var empleado = new Restaurante.Core.Entities.Empleado()
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto,
                RestauranteId = id,
                
                


            };
            var Id = _empleadoService.Agregar(empleado);
            return View(model);
        }
        [HttpGet]
        public IActionResult EditarEmpleado(int id)
        {
            ViewData["Accion"] = "EditarEmpleado";
            var empleados = _empleadoService.Obtener(id);
            var viewModel = new EmpleadoViewModel
            {

                Nombre = empleados.Nombre,
                Puesto = empleados.Puesto


            };
            return View("AgregarEmpleado", viewModel);
        }

        [HttpPost]
        public IActionResult EditarEmpleado(EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var empleado = _empleadoService.Obtener(model.Id);
            _empleadoService.Editar(empleado);

            empleado.Nombre = model.Nombre;

            empleado.Puesto = model.Puesto;
            _empleadoService.Editar(empleado);

            return RedirectToAction("Empleados");
        }
        [HttpPost]
        public IActionResult EliminarEmpleado(int id)
        {

            var empleado = _empleadoService.Obtener(id);
            _empleadoService.Eliminar(empleado);
            return RedirectToAction("Empleados");
        }
    }
}