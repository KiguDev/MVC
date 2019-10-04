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
    public class EmpleController : Controller
    {
        private readonly IEmpleadosService _empleadoService;
        private readonly IMapper _mapper;

        public EmpleController(IEmpleadosService emepleadoService, IMapper mapper)
        {
            _empleadoService = emepleadoService;
            _mapper = mapper;
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
        [HttpGet("{id}")]
        public ActionResult<List<EmpleadoDTO>> Get(int id)
        {
            var empleados = _empleadoService.ObtenerEmpleado(id);
            var model = new List<EmpleadoDTO>();
            _mapper.Map(empleados, model);
            return model;
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmpleadoViewModel model)
        {
            var empleado = new Restaurante.core.Entities.Empleado
            {
                Nombre = model.Nombre,
                Puesto = model.Puesto,
                RestauranteId = model.RestauranteId
            };
            _empleadoService.InsertarEmpleado(empleado);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _empleadoService.EliminarEmpleado(id);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody]int[] ids)
        {
            _empleadoService.EliminarEmpleados(ids);
            return Ok();
        }
    }
}