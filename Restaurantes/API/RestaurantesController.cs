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
            return _restauranteService.ObtenerRestaurantes().Select(c=> new RestauranteDTO
            {
                Nombre = c.Nombre,
                Direccion = c.Domicilio,
                CantidadMesas = c.Mesas.Count()
            }).ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] RestauranteViewModel model)
        {
            var restaurante = new Restaurante.Core.Entities.Restaurante();
            _mapper.Map(model, restaurante);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("Datos inválidos");
            //}
            //var restaurante = new Restaurante.Core.Entities.Restaurante
            //{
            //    Nombre = model.Nombre,
            //    Domicilio = model.Direccion,
            //    PaginaWeb = model.PaginaWeb,
            //    HoraDeCierre = model.HoraDeCierre
            //};
            _restauranteService.Insertar(restaurante);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, RestauranteViewModel model)
        {
            var restaurante = _restauranteService.Obtener(id);
            if (restaurante==null)
            {
                return BadRequest();
            }
            restaurante.Nombre = model.Nombre;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.Telefono = model.Telefono;

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
    }
}