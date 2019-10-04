using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.core.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{

    [Authorize(Roles ="Administrator")]
    public class EmpleadosController : Controller
    {
        private IEmpleadosService _empleadoService;
        public EmpleadosController(IEmpleadosService empleadoService)
        {
            _empleadoService = empleadoService;
        }
        public IActionResult Index(int id)
        {
            ViewData["resId"] = id;
            var empleados = _empleadoService.ObtenerEmpleado(id);
            return View(empleados);
        }

        /*public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return View(new EmpleadoViewModel());
        }*/

        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return PartialView("_AgregarEditarEmpleado",new EmpleadoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(EmpleadoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            model.RestauranteId = id;
            var empleado = new Restaurante.core.Entities.Empleado
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto,
                RestauranteId = model.Id
            };

            var empleadoId = _empleadoService.InsertarEmpleado(empleado);
            return RedirectToAction("/Index/" + model.RestauranteId);
        }

        /*[HttpGet]
        public IActionResult EditarEmpleado(int id)
        {
            ViewData["Accion"] = "EditarEmpleado";
            var empleado = _empleadoService.Obtener(id);
            var viewModel = new EmpleadoViewModel
            {
                Nombre = empleado.Nombre,
                Puesto = empleado.Puesto
            };
            return View("Agregar", viewModel);
        }*/

        [HttpGet]
        public IActionResult EditarEmpleado(int id)
        {
            ViewData["Accion"] = "EditarEmpleado";
            var empleado = _empleadoService.Obtener(id);
            var viewModel = new EmpleadoViewModel
            {
                Nombre = empleado.Nombre,
                Puesto = empleado.Puesto
            };
            return PartialView("_AgregarEditarEmpleado", viewModel);
        }

        [HttpPost]
        public IActionResult EditarEmpleado(EmpleadoViewModel model, int resId)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var empleado = _empleadoService.Obtener(model.Id);
            empleado.Nombre = model.Nombre;
            empleado.Puesto = model.Puesto;

            _empleadoService.EditarEmpleado(empleado);

            return RedirectToAction("Index/" + empleado.RestauranteId);
        }

        [HttpGet]
        public IActionResult EliminarEmpleado(int id, int resId)
        {
            var eliminarMesa = _empleadoService.EliminarEmpleado(id);
            return RedirectToAction("Index/" + resId);
        }
    }
}