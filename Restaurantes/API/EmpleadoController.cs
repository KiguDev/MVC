using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;
        public EmpleadoController(IEmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public ActionResult<List<Empleado>> getEmpleados(int id)
        {
            var empleados = _empleadoService.ObtenerEmpleados(id);
            
           
            return empleados;
        }

        [HttpPut("{id}")]
        public ActionResult putEmpleado(int id, EmpleadoViewModel model)
        {
            var empleado = _empleadoService.Obtener(id);
            if (empleado == null)
                return BadRequest();
            if(model.RestauranteId == empleado.RestauranteId)
            {
                empleado.Nombre = model.Nombre;
                empleado.Puesto = model.Puesto;
                _empleadoService.Editar(empleado);
                return Ok();
            }else
                return BadRequest("No puedes editar los empleados de otro restaurante");





        }

        [HttpDelete("{id}")]
        public ActionResult deleteEmpleado(int id)
        {
            _empleadoService.Eliminar(id);
            return Ok();
        }


        [HttpDelete]
        public ActionResult deleteEmpleados([FromBody]int[] ids)
        {
            _empleadoService.EliminarVarios(ids);
            return Ok();
        }


        [HttpPost("{id}")]
        public ActionResult postEmpleado([FromBody] EmpleadoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }


            var empleado = new Restaurante.Core.Entities.Empleado
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto

            };
            empleado.RestauranteId = id;
            var respuesta = _empleadoService.insertar(empleado);
            return Ok();
        }

    }
}