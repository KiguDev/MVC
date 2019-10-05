using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]

    public class RestaurantesController : ControllerBase
    {
        private IRestauranteService _restauranteService;
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

        [HttpGet("{id}")]
        public ActionResult<Restaurante> Get(int id)
        {
            return _restauranteService.Obtener(id);
        }

        //ADD
        [HttpPost]
        public void Post([FromBody] RestauranteViewModel model)
        {
            var restaurante = new Restaurante();
            _mapper.Map(model, restaurante);
            restaurante.Domicilio = model.Direccion;

            _restauranteService.Agregar(restaurante);
        }

        //EDIT
        [HttpPut]
        public ActionResult Put([FromBody] RestauranteViewModel model)
        {
            var restaurante = _restauranteService.Obtener(model.Id);
            if (restaurante == null)
            {
                return BadRequest();
            }
            restaurante.Nombre = model.Nombre;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.Telefono = int.Parse(model.Telefono);
            restaurante.Domicilio = model.Direccion;
            restaurante.HoraDeCierre = model.HoraDeCierre;
            restaurante.Logo = model.Logo;

            _restauranteService.Editar(restaurante);
            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var restaurante = _restauranteService.Obtener(id);
            if (restaurante == null)
            {
                return BadRequest();
            }

            _restauranteService.Eliminar(restaurante);
            return Ok();
        }

        //DELETE ARRAY
        [HttpDelete]
        public ActionResult Delete([FromBody]int[] ids)
        {
            _restauranteService.Eliminar(ids);
            return Ok();
        }
    }
}
