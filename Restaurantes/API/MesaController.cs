using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _mesaService;
        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }
        [HttpGet("{id}")]
        public ActionResult<List<Restaurante.Core.Entities.Mesa>> getMesas(int id)
        {
            return _mesaService.ObtenerMesas(id);
        }

        [HttpPut("{id}")]
        public ActionResult putMesa(int id, MesaViewModel model)
        {
            var mesa = _mesaService.Obtener(id);
            if (mesa == null)
                return BadRequest();
            mesa.Capacidad = model.Capacidad;
            mesa.Identificador = model.Identificador;

            _mesaService.Editar(mesa);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteMesa(int id)
        {
            _mesaService.Eliminar(id);
            return Ok();
        }


        [HttpPost("{id}")]
        public ActionResult postMesa([FromBody] MesaViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
           

            var mesa = new Restaurante.Core.Entities.Mesa
            {
               Identificador = model.Identificador,
               Capacidad = model.Capacidad

            };
        mesa.RestauranteId = id;
            var respuesta = _mesaService.insertar(mesa);
            return Ok();
        }
    }
}