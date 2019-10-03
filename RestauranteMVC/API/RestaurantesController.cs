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
            var restaurantes = _restauranteService.ObtenerRestaurantes();
            var model = new List<RestauranteDTO>();
            _mapper.Map(restaurantes, model);
            return model;
        }
        [HttpPost]
        public ActionResult Post([FromBody]Restaurante.Core.Entities.Restaurante model)
        {
            //var restaurante = new RestauranteDTO();
            //_mapper.Map(model, restaurante);
            //_restauranteService.InsertRecord(restaurante);
            //_restauranteService.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, Restaurante.Core.Entities.Restaurante model)
        {
            var restaurante = _restauranteService.Obtener(id);
            if (restaurante == null) return BadRequest();

            restaurante.Domicilio = model.Domicilio;
            restaurante.HoraDeCierre = model.HoraDeCierre;
            restaurante.Logo = model.Logo;
            restaurante.Nombre = model.Nombre;
            restaurante.Telefono = model.Telefono;
            _restauranteService.Edit(restaurante);
            _restauranteService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var restaurante = _restauranteService.Obtener(id);
            if (restaurante == null) return BadRequest();
            _restauranteService.Delete(restaurante);
            _restauranteService.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] int [] ids)
        {
            _restauranteService.Delete(ids.ToList());
            _restauranteService.SaveChanges();
            return Ok();
        }
    }
}