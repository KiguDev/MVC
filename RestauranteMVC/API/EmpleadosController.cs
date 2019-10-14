using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IRestauranteService _restauranteService;
        private readonly IMapper _mapper;

        public EmpleadosController(IEmpleadoService empleadoService, IMapper mapper, IRestauranteService restauranteService)
        {
            _empleadoService = empleadoService;
            _mapper = mapper;
            _restauranteService = restauranteService;
        }
        [HttpGet]
        public ActionResult<List<Empleado>> Todos(int id)
        {
            var restauranteId = _restauranteService.Obtener(id).Id;
            var empleados = _empleadoService.GetEmpleados(restauranteId);
            return empleados.ToList();
        }
        [HttpPost]
        public ActionResult Post([FromBody]EmpleadoViewModel empleado)
        {
            var newEmpleado = new Empleado();
            newEmpleado = _mapper.Map(empleado, newEmpleado);
            _empleadoService.Insert(newEmpleado);
            _empleadoService.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] EmpleadoViewModel model)
        {
            var empleado = new Empleado();
            empleado = _mapper.Map(model, empleado);
            _empleadoService.Update(empleado);
            _empleadoService.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody]EmpleadoViewModel empleado)
        {
            var empleadoABorrar = _empleadoService.GetEmpleado(empleado.Id);
            _empleadoService.Delete(empleadoABorrar);
            _empleadoService.SaveChanges();
            return Ok();
        }
    }
}