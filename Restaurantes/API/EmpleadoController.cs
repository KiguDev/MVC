using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {

        private readonly  IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;

        public EmpleadoController (IEmpleadoService EmpleadoService, IMapper mapper)
        {
            _empleadoService = EmpleadoService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<List<EmpleadoDTO>> getEmpleado(int id)
        {
            var empleados = _empleadoService.ObtenerEmpleados(id);
            var model = new List<EmpleadoDTO>();
            _mapper.Map(empleados, model);
            return model;
        }

        [HttpPut("{id}")]
        public ActionResult putEmpleado(int id, EmpleadoViewModel model)
        {
            var empleados = _empleadoService.Obtener(id);
            if (empleados == null)
                return BadRequest();
            empleados.Nombre = model.Nombre;
            empleados.Id = model.Id;

            _empleadoService.Editar(empleados);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteEmpleado(int id)
        {
            _empleadoService.Eliminar(id);
            return Ok();
        }


        [HttpPost("{id}")]
        public ActionResult postEmpleado([FromBody] EmpleadoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }


            var empleado = new Restaurantes.Core.Entities.Empleado
            {
                Id = model.Id,
                Nombre = model.Nombre

            };
            empleado.Id = id;
            var respuesta = _empleadoService.Insertar(empleado);
            return Ok();
        }






    }
}