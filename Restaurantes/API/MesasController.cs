using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Services;
using Restaurantes.Models;

namespace Mesas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        private readonly IMesaService _mesaService;
        private readonly IMapper _mapper;
        public MesasController(IMesaService mesaService, IMapper mapper)
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
        public IActionResult Post([FromBody] MesaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var mesa = new Restaurantes.Core.Entities.Mesa();
            _mapper.Map(model, mesa);
            var respuesta = _mesaService.Agregar(mesa);
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, MesaViewModel model)
        {
            var mesa = _mesaService.Obtener(id);

            if (mesa == null)
                return BadRequest();

            mesa.Identificador = model.Identificador;
            mesa.Capacidad = model.Capacidad;

            _mesaService.Editar(mesa);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mesa = _mesaService.Obtener(id);

            if (mesa == null)
                return BadRequest();

            _mesaService.Eliminar(id);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Eliminar([FromBody] int[] ids)
        {
            _mesaService.Eliminar(ids);

            return Ok();

        }
    }
}