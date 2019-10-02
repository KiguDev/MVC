using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.core.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        private readonly IMesasService _mesaService;
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

        [HttpDelete]
        public ActionResult Delete([FromBody]int[] ids)
        {
            _mesaService.EliminarMesas(ids);
            return Ok();
        }

        [HttpPost]
        public ActionResult Post([FromBody] MesaViewModel model)
        {
            //model.RestauranteId = id;
            var mesa = new Restaurante.core.Entities.Mesa
            {
                Identificador = model.Identificador,
                Capacidad = model.Capacidad,
                RestauranteId = model.RestauranteId
            };
            _mesaService.InsertarMesa(mesa);
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

            _mesaService.EditarMesa(mesa);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _mesaService.EliminarMesa(id);
            return Ok();
        }
    }
}