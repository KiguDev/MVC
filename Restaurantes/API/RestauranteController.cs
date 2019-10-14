using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Services;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestauranteService RestauranteService;
        private readonly IMapper _mapper;
        public RestauranteController(IRestauranteService restauranteService, IMapper mapper)
        {
            RestauranteService = restauranteService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<RestauranteDTO>> ObtenerRestaurantes()
        {
            var restaurantes = RestauranteService.ObtenerRestaurantes();

            var model = new List<RestauranteDTO>();
            _mapper.Map(restaurantes, model);

            return model;
        }

        [HttpPost("{id}")]
        public ActionResult Editar ([FromForm] int id , RestauranteViewModel model)
        {
            var restaurante = RestauranteService.Obtener(id);
            if (restaurante == null)
                return BadRequest();
            restaurante.Nombre = model.Nombre;
            restaurante.Domicilio = model.Direccion;
            restaurante.Telefono = model.Telefono;
            restaurante.Logo = model.Logo;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.FechaAlta = model.FechaAlta;
            restaurante.HoraCierre = model.HoraCierre;

            RestauranteService.Editar(restaurante);
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            RestauranteService.Eliminar(id);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult EliminarVarios([FromBody]int[] ids)
        {
            RestauranteService.EliminarVarios(ids);
            return Ok();
        }


        [HttpPost()]
        public ActionResult Insertar([FromBody] RestauranteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var restaurante = new Restaurantes.Core.Entities.Restaurante();
            model.FechaAlta = DateTime.Now;
            _mapper.Map(model, restaurante);
          
            var respuesta = RestauranteService.Insertar(restaurante);
            return Ok();
        }
    }
}