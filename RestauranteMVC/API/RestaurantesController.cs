using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.core.Entities;
using Restaurante.core.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly IRestauranteService _restauranteService;
        private readonly IMapper _mapper;

        public RestaurantesController(IRestauranteService restauranteService, IMapper mapper)
        {
            _restauranteService = restauranteService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<RestauranteDTO>> Get()
        {
            return _restauranteService.ObtenerRestaurante().Select(c => new RestauranteDTO {
                Nombre = c.Nombre,
                Domicilio = c.Domicilio,
                CantidadMesas = c.mesas.Count
            }).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurante.core.Entities.Restaurante> Get(int id)
        {
            return _restauranteService.Obtener(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] RestauranteViewModel model)
        {
            var restaurante = new Restaurante.core.Entities.Restaurante();
            _mapper.Map(model, restaurante);
            /*var restaurante = new Restaurante.core.Entities.Restaurante
            {
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Logo = model.Logo,
                PaginaWeb = model.PaginaWeb,
                Domicilio = model.Domicilio,
                HoraDeCierre = model.HoraDeCierre
            };*/
            _restauranteService.InsertarRestaurante(restaurante);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, RestauranteViewModel model)
        {
            var restaurante = _restauranteService.Obtener(id);

            if (restaurante == null)
            {
                return BadRequest();
            }

            restaurante.Nombre = model.Nombre;
            restaurante.Telefono = model.Telefono;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.Logo = model.Logo;
            restaurante.HoraDeCierre = model.HoraDeCierre;
            restaurante.Domicilio = model.Domicilio;

            _restauranteService.EditarRestaurante(restaurante);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _restauranteService.EliminarRestaurante(id);
            return Ok();
        }
    }
}