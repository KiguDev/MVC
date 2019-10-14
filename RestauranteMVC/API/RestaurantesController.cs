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
        public ActionResult<List<RestauranteDTO>> GetAll()
        {
            var restaurantes = _restauranteService.ObtenerRestaurantes();
            var model = new List<RestauranteDTO>();
            _mapper.Map(restaurantes, model);
            return model;
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurante.Core.Entities.Restaurante> Get(int id) =>  _restauranteService.Obtener(id);

        [HttpPost]
        public ActionResult Post([FromBody]Restaurante.Core.Entities.Restaurante model)
        {
            var restaurante = new Restaurante.Core.Entities.Restaurante();
            restaurante = _mapper.Map<Restaurante.Core.Entities.Restaurante>(model);
            _restauranteService.InsertRecord(restaurante);
            _restauranteService.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(Restaurante.Core.Entities.Restaurante model)
        {
            var restaurante = _restauranteService.Obtener(model.Id);
            if (restaurante == null) return BadRequest();

            restaurante.Domicilio = model.Domicilio;
            restaurante.Logo = model.Logo;
            restaurante.PaginaWeb = model.PaginaWeb;
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