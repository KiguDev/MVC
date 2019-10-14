using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Services;
using Restaurantes.Models;
using System.Diagnostics;

namespace Restaurantes.Controllers
{

    public class MesaController : Controller
    {
        private IMesaService _mesaService;
        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }
        public IActionResult Mesas(int id)
        {
            ViewData["Id"] = id;
            var mesas = _mesaService.ObtenerMesas(id);
            return View(mesas);
        }

        public IActionResult AgregarMesa()
        {
            ViewData["Accion"] = "AgregarMesa";
            return PartialView("AgregarMesa",new MesaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarMesa(MesaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View(model);
            } 
            var mesa = new Restaurantes.Core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = model.RestauranteId
            };
            var respuesta = _mesaService.insertar(mesa);

            return View("AgregarMesa", model);
        }


        public IActionResult EditarMesa(int id)
        {
            ViewData["Accion"] = "EditarMesa";
            var mesa = _mesaService.Obtener(id);
            var viewModel = new MesaViewModel
            {
                Id = mesa.Id,
                Identificador = mesa.Identificador,
                Capacidad = mesa.Capacidad
            };

            return View("AgregarMesa", viewModel);

        }

        [HttpPost]
        public IActionResult EditarMesa(MesaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Te hacen falta campos");
                return View("Agregar", model);
            }
            var mesa = _mesaService.Obtener(model.Id);


            mesa.Identificador = model.Identificador;
            mesa.Capacidad = model.Capacidad;

            _mesaService.Editar(mesa);


            return RedirectToAction("Mesas", new { Id = mesa.RestauranteId });
        }
        [HttpPost]
        public IActionResult EliminarMesa(int id)
        {
            var Id = _mesaService.Obtener(id).RestauranteId;
            _mesaService.Eliminar(id);
            return RedirectToAction("Mesas", new { Id = Id });
        }
     

    }
}