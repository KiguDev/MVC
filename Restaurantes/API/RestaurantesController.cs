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
    public class RestaurantesController : Controller
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
        public ActionResult Post([FromBody] RestauranteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var restaurante = new Restaurante.Core.Entities.Restaurante();
            _mapper.Map(model, restaurante);
              
            //{
            //    Nombre = model.Nombre,
            //    Domicilio = model.Direccion,
            //    PaginaWeb = model.PaginaWeb,
            //    HoraDeCierre = model.HoraDeCierre
                

            //};
            _restauranteService.Agregar(restaurante);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, RestauranteViewModel model)
        {
            var restaurante = _restauranteService.Obtener(id);
            if (restaurante == null)
            {
                return BadRequest();
            }
            _mapper.Map(model, restaurante);
            //restaurante.Nombre = model.Nombre;
            //restaurante.PaginaWeb = model.PaginaWeb;
            //restaurante.Telefono = int.Parse(model.Telefono);

            return Ok();

        }
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
        [HttpDelete]
        public ActionResult Delete([FromBody]int[] ids)
        {
            _restauranteService.Eliminar(ids);
            return Ok();
        }
    }
}