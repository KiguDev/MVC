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
            return _restauranteService
                .ObtenerRestaurantes()
                .Select(c => new RestauranteDTO {
                    Id = c.Id,
                Nombre = c.Nombre,
                Direccion = c.Domicilio,
                CantidadMesas = c.Mesas.Count()
            }).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurante> Get(int id)
        {
            return _restauranteService.Obtener(id);
        }


        [HttpPost]
        public void Post([FromBody] RestauranteViewModel model)
        {
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
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, RestauranteViewModel model)
        {
            var restaurante = _restauranteService.Obtener(id);

            if (restaurante == null)
                return BadRequest();

            restaurante.Nombre = model.Nombre;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.Telefono = int.Parse(model.Telefono);

            _restauranteService.Editar(restaurante);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var restaurante = _restauranteService.Obtener(id);

            if (restaurante == null)
                return BadRequest();

            _restauranteService.Eliminar(id);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Delete(int[] ids)
        {
            _restauranteService.Eliminar(ids);

            return Ok();

        }
    }
}