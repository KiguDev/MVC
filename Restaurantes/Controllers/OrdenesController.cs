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
    public class OrdenesController : Controller
    {
        private IOrdenService _OrdenServices;
        public OrdenesController(IOrdenService ordenService)
        {
            _OrdenServices = ordenService;
        }

        public IActionResult Index(int id)
        {
            ViewData["id"] = id;
            var ordenes = _OrdenServices.ObtenerOrdenes(id);
            return View(ordenes);
        }

        //Agregar /Nuevo 
        public IActionResult Agregar()
        {
            ViewData["Accion"] = "Agregar";
            return View("Agregar", new OrdenViewModel());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(OrdenViewModel model)
        {

            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }

            var ordenes = new Orden
            {
                Id = model.Id,
                MesaId = model.MesaId,
                RestaurantId = model.RestaurantId,
                EmpleadoId = model.EmpleadoId,
                

            };
            var respuesta = _OrdenServices.insertar(ordenes);
            return View();
        }


        public IActionResult Editar(int id)
        {
            ViewData["Accion"] = "Editar";
            var ordenes = _OrdenServices.Obtener(id);
            var viewModel = new OrdenViewModel
            {

               


            };

            return View("Agregar", viewModel);

        }

        [HttpPost]
        public IActionResult Editar(OrdenViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View("Agregar", model);
            }
            var ordenes = _OrdenServices.Obtener(model.Id);

              

            _OrdenServices.Editar(ordenes);


            return RedirectToAction("Index", new { Id = ordenes.RestauranteId });
        }

        ///Eliminar Producto

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var Id = _OrdenServices.Obtener(id).Id;
            _OrdenServices.Eliminar(id);
            return RedirectToAction("Index", new { Id = Id });
        }


    }
}
