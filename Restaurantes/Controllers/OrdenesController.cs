using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class OrdenesController : Controller
    {
        private IOrdenService _ordenService;

        public OrdenesController(IOrdenService ordenService)
        {

            _ordenService = ordenService;

        }
        public IActionResult Index(int id)
        {
            ViewData["restauranteId"] = id;
            var ordenes = _ordenService.ObtenerOrdenes(id);
            return View(ordenes);

        }
        public IActionResult AgregarOrden()
        {
            ViewData["Accion"] = "AgregarOrden";
            return View(new OrdenViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarOrden(OrdenViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var ordenes = new Restaurante.Core.Entities.Orden()
            {
                Estatus = model.Estatus,
                FechaAlta = model.FechaAlta,
                Total = model.Total,
                RestauranteId = id,


            };
            var Id = _ordenService.Agregar(ordenes);
            return Ok();
        }
        [HttpGet]
        public IActionResult EditarOrden(int id)
        {
            ViewData["Accion"] = "EditarOrden";
            var ordenes = _ordenService.Obtener(id);
            var viewModel = new OrdenViewModel
            {
                Estatus = ordenes.Estatus,
                FechaAlta = ordenes.FechaAlta,
                Total = ordenes.Total,
                RestauranteId = id,
                


            };
            return View("AgregarOrden", viewModel);
        }

        [HttpPost]
        public IActionResult EditarOrden(OrdenViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            }
            var orden = _ordenService.Obtener(model.Id);
            _ordenService.Editar(orden);

            
            orden.Estatus = model.Estatus;
            orden.FechaAlta = model.FechaAlta;
            orden.Total = model.Total;
            
            _ordenService.Editar(orden);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult EliminarOrden(int id)
        {

            var orden = _ordenService.Obtener(id);
            _ordenService.Eliminar(orden);
            return RedirectToAction("Index");
        }

    }
}