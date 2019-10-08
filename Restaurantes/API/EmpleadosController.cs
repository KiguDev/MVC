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

namespace Empleados.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;
        public EmpleadosController(IEmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<EmpleadoDTO>> Get(int id)
        {
            var empleados = _empleadoService.ObtenerEmpleados(id);
            var model = new List<EmpleadoDTO>();

            _mapper.Map(empleados, model);

            return model;
        }


        [HttpPost]
        public IActionResult Post([FromBody] EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var empleado = new Restaurantes.Core.Entities.Empleado();
            _mapper.Map(model, empleado);
            var respuesta = _empleadoService.Agregar(empleado);
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, EmpleadoViewModel model)
        {
            var empleado = _empleadoService.Obtener(id);

            if (empleado == null)
                return BadRequest();
            empleado.Nombre = model.Nombre;
            empleado.Puesto = model.Puesto;

            _empleadoService.Editar(empleado);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var empleado = _empleadoService.Obtener(id);

            if (empleado == null)
                return BadRequest();

            _empleadoService.Eliminar(id);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Eliminar([FromBody] int[] ids)
        {
            _empleadoService.Eliminar(ids);

            return Ok();

        }
    }
}