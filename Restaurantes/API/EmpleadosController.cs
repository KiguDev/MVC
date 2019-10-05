using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmpleadosController : ControllerBase
    {
        private IEmpleadoService _empleadoService;
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

        //ADD
        [HttpPost]
        public ActionResult Post([FromBody] EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos");

            var empleado = new Empleado
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto,
                RestauranteId = model.RestauranteId
            };

            _empleadoService.Agregar(empleado);
            return Ok();
        }

        //EDIT
        [HttpPut]
        public ActionResult Put(EmpleadoViewModel model)
        {
            var empleado = _empleadoService.Obtener(model.Id);
            if (empleado == null)
            {
                return BadRequest();
            }
            empleado.Nombre = model.Nombre;
            empleado.Puesto = model.Puesto;
            

            _empleadoService.Editar(empleado);
            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var empleado = _empleadoService.Obtener(id);
            if (empleado == null)
            {
                return BadRequest();
            }

            _empleadoService.Eliminar(empleado);
            return Ok();
        }

        //DELETE ARRAY
        [HttpDelete]
        public ActionResult Delete([FromBody]int[] ids)
        {
            _empleadoService.Eliminar(ids);
            return Ok();
        }
    }
}
