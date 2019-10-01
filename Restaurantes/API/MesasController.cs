using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : Controller
    {
        private readonly IMesasService _mesasService;

        public MesasController(IMesasService mesasService)
        {
            _mesasService = mesasService;
        }

        [HttpGet]
        public ActionResult<List<Restaurante.Core.Entities.Mesa>> Get()
        {
            return _mesasService.ObtenerMesas();
        }
        [HttpGet]
        public ActionResult<List<Restaurante.Core.Entities.Mesa>> Get(int id)
        {
            var mesa = _mesasService.Obtener(id);
            return View(mesa);
        }

        [HttpPost]
        public ActionResult Post([FromBody] MesaViewModel model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var mesa = new Restaurante.Core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = model.RestauranteId


            };
            _mesasService.Agregar(mesa);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, MesaViewModel model)
        {
            var mesa = _mesasService.Obtener(id);
            if (mesa == null)
            {
                return BadRequest();
            }

            mesa.Capacidad = model.Capacidad;
            mesa.Identificador = model.Identificador;
            mesa.RestauranteId = model.RestauranteId;

            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mesa= _mesasService.Obtener(id);
            if (mesa == null)
            {
                return BadRequest();
            }
            _mesasService.Eliminar(mesa);
            return Ok();
        }
    }
}