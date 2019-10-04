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
    public class EmpleadosController : ControllerBase
    {
        public readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;

        public EmpleadosController(IEmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public ActionResult<List<EmpleadoDTO>> Get(int id)
        {
            var empleados = _empleadoService.ObtenerEmpleados(id);
            var model = new List<EmpleadoDTO>();
            _mapper.Map(empleados, model);
            return model;
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Elementos no validos");
            }
            var mesas = new Restaurante.Core.Entities.Empleado
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto,
                RestauranteId = model.RestauranteId,
            };
            _empleadoService.Agregar(mesas);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, EmpleadoViewModel model)
        {
            var empleado = _empleadoService.Obtener(id);
            if (empleado == null)
            {
                return BadRequest();
            }
            empleado.Nombre= model.Nombre;
            empleado.Puesto = model.Puesto;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mesa = _empleadoService.Obtener(id);
            if (mesa == null)
            {
                return BadRequest();
            }
            _empleadoService.Eliminar(mesa);
            return Ok();
        }

       
    }
}