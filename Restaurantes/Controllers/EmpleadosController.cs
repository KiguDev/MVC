using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EmpleadosController : Controller
    {
        private IEmpleadoService _empleadoServices;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoServices = empleadoService;
        }
        public IActionResult Index(int id)
        {
            ViewData["resId"] = id;
            var empleados = _empleadoServices.ObtenerEmpleados(id);
            return View(empleados);
        }

        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return View(new EmpleadoViewModel());
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


            var empleado = new Empleado
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto


            };

            model.RestauranteId = id;
            empleado.RestauranteId = id;
            var respuesta = _empleadoServices.Insertar(empleado);

            return View("Agregar", model);
        }


        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var empleado = _empleadoServices.Obtener(id);
            var viewModel = new EmpleadoViewModel
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Puesto = empleado.Puesto
            };

            return View("Agregar", viewModel);

        }

        [HttpPost]
        public IActionResult Editar(EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View("Agregar", model);
            }
            var empleado = _empleadoServices.Obtener(model.Id);

            empleado.Nombre = model.Nombre;
            empleado.Puesto = model.Puesto;
            _empleadoServices.Editar(empleado);


            return RedirectToAction("Index", new { Id = empleado.RestauranteId });
        }
        [HttpPost]
        public IActionResult Eliminar(int id)
        {

            var resId = _empleadoServices.Obtener(id).RestauranteId;
            _empleadoServices.Eliminar(id);
            return RedirectToAction("Index", new { Id = resId });
        }
    }
}