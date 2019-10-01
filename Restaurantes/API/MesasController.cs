using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        public readonly IMesaService _mesaService;

        public MesasController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet]
        public ActionResult<List<Restaurante.Core.Entities.Mesa>> Get()
        {
            return _mesaService.ObtenerMesas();
        }

        [HttpPost]
        public ActionResult Post([FromBody] MesaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos inválidos");
            }
            var mesa = new Restaurante.Core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad
            };
            _mesaService.Insertar(mesa);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, MesaViewModel model)
        {
            var mesa = _mesaService.Obtener(id);
            if (mesa == null)
            {
                return BadRequest();
            }
            mesa.Identificador = model.Identificador;
            mesa.Capacidad = model.Capacidad;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mesa = _mesaService.Obtener(id);
            if (mesa == null)
            {
                return BadRequest();
            }
            _mesaService.Eliminar(mesa);
            return Ok();
        }
    }
}