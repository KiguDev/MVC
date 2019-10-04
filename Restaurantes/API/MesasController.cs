using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        public readonly IMesasService _mesaService;
        private readonly IMapper _mapper;

        public MesasController(IMesasService mesaService, IMapper mapper)
        {
            _mesaService = mesaService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<List<MesaDTO>> Get(int id)
        {
            var mesas = _mesaService.ObtenerMesas(id);
            var model = new List<MesaDTO>();
            _mapper.Map(mesas, model);
            return model;
        }

        [HttpPost]
        public ActionResult Post([FromBody] MesaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Elementos no validos");
            }
            var mesas = new Restaurante.Core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = model.RestauranteId,
            };
            _mesaService.Agregar(mesas);
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

        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            _mesaService.Eliminar(ids);
            return Ok();
        }
    }
}