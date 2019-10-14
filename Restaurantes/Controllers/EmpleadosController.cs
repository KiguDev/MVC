using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantes.Controllers
{
    public class EmpleadosController : Controller
    {
        private IEmpleadoService _empleadoServices;
        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoServices = empleadoService;
        }

        public IActionResult Index(int id)
        {
            ViewData["id"] = id;
            var empleado = _empleadoServices.ObtenerEmpleado(id);
            return View(empleado);
        }

        //Agregar /Nuevo 
        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return View("Agregar", new EmpleadoViewModel());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(EmpleadoViewModel model)
        {

            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var empleado = new Empleado
            {

                Nombre = model.Nombre,
                Puesto = model.Puesto,
                
            };
            var respuesta = _empleadoServices.insertar(empleado);
            return View();
        }


        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var empleado = _empleadoServices.Obtener(id);
            var viewModel = new EmpleadoViewModel
            {
                Nombre = empleado.Nombre,
                Puesto = empleado.Puesto,


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

        ///Eliminar Producto

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var Id = _empleadoServices.Obtener(id).Id;
            _empleadoServices.Eliminar(id);
            return RedirectToAction("Index", new { Id = Id });
        }


    }
}
