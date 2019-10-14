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
            ViewData["RestauranteId"] = id;
            var empleados = _empleadoServices.ObtenerEmpleados(id);
            return View(empleados);
        }

        public IActionResult AgregarEmpleado(int id)
        {
            ViewData["Accion"] = "AgregarEmpleado";
            var model = new EmpleadoViewModel();
            model.RestauranteId = id;
            return PartialView("_AgregarEditarEmpleado", model);
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


            var empleado = new Restaurante.Core.Entities.Empleado
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto,
                Foto = model.Foto,
                RestauranteId = model.RestauranteId
            };

            var respuesta = _empleadoServices.insertar(empleado);

            return View("AgregarEmpleado", model);
        }


        public IActionResult EditarEmpleado(int id)
        {
            ViewData["Accion"] = "EditarEmpleado";
            var empleado = _empleadoServices.Obtener(id);
            var viewModel = new EmpleadoViewModel
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Puesto = empleado.Puesto,
                Foto= empleado.Foto
            };

            return View("AgregarEmpleado", viewModel);

        }

        [HttpPost]
        public IActionResult EditarEmpleado(EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View("Agregar", model);
            }
            var empleado = _empleadoServices.Obtener(model.Id);


            empleado.Nombre = model.Nombre;
            empleado.Puesto = model.Puesto;
            empleado.Foto = model.Foto;
            _empleadoServices.Editar(empleado);


            return RedirectToAction("Index", new { Id = empleado.RestauranteId });
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var resId = _empleadoServices.Obtener(id).RestauranteId;
            _empleadoServices.Eliminar(id);
            return RedirectToAction("Empleados", new { Id = resId });
        }
    }
}