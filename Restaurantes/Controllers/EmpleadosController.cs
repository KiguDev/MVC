using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class EmpleadosController : Controller
    {
        //Se crea un objeto de IEmpleadoService para poder usar la interfaz y sus métodos
        private IEmpleadoService _empleadoService;

        //Se crea el constructor de esta clase
        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }


        //Se definen los métodos
        public IActionResult Index()
        {
            var empleados = _empleadoService.ObtenerEmpleados();
            //Se regresa a la vista los empleados
            return View(empleados);
        }

        public IActionResult Empleados(int id)
        {
            ViewData["restauranteId"] = id;
            var empleados = _empleadoService.ObtenerEmpleados();
            return View(empleados);
        }

        public IActionResult AgregarEmpleado()
        {
            ViewData["Accion"] = "AgregarEmpleado";
            return View(new EmpleadoViewModel());
        }

        [HttpPost]
        public IActionResult AgregarEmpleado(EmpleadoViewModel model, int id)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("","Campos faltantes");
                return View(model);
            }

            var empleados = new Restaurantes.Core.Entities.Empleado
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto,
                RestauranteId = id
            };

            var resp = _empleadoService.Insertar(empleados);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditarEmpleado(int id)
        {
            ViewData["Accion"] = "EditarEmpleado";
            var empleado = _empleadoService.Obtener(id);
            var viewModel = new EmpleadoViewModel
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Puesto = empleado.Puesto,
                RestauranteId = empleado.RestauranteId
            };
            return View("Agregar", viewModel);
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
            empleado.Nombre = model.Nombre;
            empleado.Puesto = model.Puesto;

            _empleadoService.Editar(empleado);

            return RedirectToAction("Index");
        }

        public IActionResult EliminarEmpleado(int id)
        {
            var empleado = _empleadoService.Obtener(id);
            _empleadoService.Eliminar(empleado);
            return RedirectToAction("Index");
        }

    }
}