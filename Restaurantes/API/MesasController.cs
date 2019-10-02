﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public MesasController(IMesaService mesaService, IMapper mapper)
        {
            _mesaService = mesaService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<MesaDTO>> Get()
        {
            var mesas = _mesaService.ObtenerMesas();
            var model = new List<MesaDTO>();
            _mapper.Map(mesas, model);
            return model;
        }

        [HttpPost]
        public ActionResult Post([FromBody] MesaViewModel model)
        {
            var mesa = new Restaurante.Core.Entities.Mesa();
            _mapper.Map(model, mesa);
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

        [HttpDelete]
        public ActionResult Delete([FromBody] int[] ids)
        {
            _mesaService.Eliminar(ids);
            return Ok();
        }
    }
}