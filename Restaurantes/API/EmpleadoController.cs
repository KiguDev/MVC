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
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;

        public EmpleadoController(IEmpleadoService empleadoService, IMapper mapper)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<EmpleadoDTO>> getEmpleados(int id)
        {
            var empleado = _empleadoService.ObtenerEmpleados(id);

            var model = new List<EmpleadoDTO>();
            _mapper.Map(empleado, model);

            return model;
        }

        [HttpPut("{id}")]
        public ActionResult putEmpleado(int id, [FromBody] EmpleadoViewModel model)
        {
            var empleado = _empleadoService.Obtener(id);
            if (empleado == null)
                return BadRequest();
            empleado.Nombre = model.Nombre;
            empleado.Puesto = model.Puesto;
            empleado.Foto = model.Foto;
            _empleadoService.Editar(empleado);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteEmpleado(int id)
        {
            _empleadoService.Eliminar(id);
            return Ok();
        }

        [HttpDelete]
        public ActionResult deleteEmpleado([FromBody]int[] ids)
        {
            _empleadoService.EliminarVarios(ids);
            return Ok();
        }


        [HttpPost()]
        public ActionResult postEmpleado([FromBody] EmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var empleado = new Restaurante.Core.Entities.Empleado();
            _mapper.Map(model, empleado);
            
            var respuesta = _empleadoService.insertar(empleado);
            return Ok();
        }
    }
}