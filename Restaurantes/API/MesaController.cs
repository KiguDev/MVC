using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _mesaService;
        private readonly IMapper _mapper;
        public MesaController(IMesaService mesaService, IMapper mapper)
        {
            _mesaService = mesaService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public ActionResult<List<MesaDTO>> getMesas(int id)
        {
            var mesas = _mesaService.ObtenerMesas(id);
            var model = new List<MesaDTO>();
            _mapper.Map(mesas, model);
            return model;
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


            var mesa = new Restaurantes.Core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad

            };
            mesa.RestauranteId = id;
            var respuesta = _mesaService.Insertar(mesa);
            return Ok();
        }
    }
}