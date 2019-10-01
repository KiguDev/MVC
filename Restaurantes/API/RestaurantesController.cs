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

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly IRestauranteService _restauranteService;
        private readonly IMapper _mapper;

        public RestaurantesController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        [HttpGet]
        public ActionResult<List<RestauranteDTO>> Get()
        {
            return _restauranteService.ObtenerRestaurantes().Select(c=> new RestauranteDTO { Nombre = c.Nombre, Direccion = c.Domicilio, CantidadMesas = c.Mesas.Count()}).ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] RestauranteViewModel model)
        {
            //Alternativa con IMapper
            var restaurante = new Restaurante();
            _mapper.Map(model, restaurante);
            //var restaurante = new Restaurante
            //{
            //    Nombre = model.Nombre,
            //    Domicilio = model.Direccion,
            //    PaginaWeb = model.PaginaWeb,
            //    HoraDeCierre = model.HoraDeCierre
            //};
            _restauranteService.Agregar(restaurante);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, RestauranteViewModel model)
        {
            var restaurante = _restauranteService.Obtener(id);
            if (restaurante == null)
                return BadRequest();

            restaurante.Nombre = model.Nombre;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.Telefono = Int32.Parse(model.Telefono);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var restaurante = _restauranteService.Obtener(id);

            _restauranteService.Eliminar(id);
            return Ok();
        }

    }
}