using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestauranteService _RestauranteService;
        private readonly IMapper _mapper;
        public RestauranteController(IRestauranteService restauranteService, IMapper mapper)
        {
            _RestauranteService = restauranteService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<RestauranteDTO>> getRestaurantes()
        {
            var restaurantes = _RestauranteService.ObtenerRestaurantes();

            var model = new List<RestauranteDTO>();
            _mapper.Map(restaurantes, model);

            return model;
        }

        [HttpPut("{id}")]
        public ActionResult putRestaurante(int id,[FromBody] RestauranteViewModel model)
        {
            var restaurante = _RestauranteService.Obtener(id);
            if (restaurante == null)
                return BadRequest();
            restaurante.Nombre = model.Nombre;
            restaurante.Domicilio = model.Direccion;
            restaurante.Telefono = model.Telefono;
            restaurante.Logo = model.Logo;
            restaurante.PaginaWeb = model.PaginaWeb;
            restaurante.FechaAlta = model.FechaAlta;
            restaurante.HoraCierre = model.HoraCierre;

            _RestauranteService.Editar(restaurante);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteRestaurante(int id)
        {
            _RestauranteService.Eliminar(id);
            return Ok();
        }

        [HttpDelete]
        public ActionResult deleteRestaurante([FromBody ]int[] ids)
        {
            _RestauranteService.EliminarVarios(ids);
            return Ok();
        }


        [HttpPost()]
        public ActionResult postRestaurante([FromBody] RestauranteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var restaurante = new Restaurante.Core.Entities.Restaurante();
            model.FechaAlta = DateTime.Now;
            _mapper.Map(model, restaurante);
            //var restaurante = new Restaurante.Core.Entities.Restaurante
            //{
            //    Nombre = model.Nombre,
            //    Domicilio = model.Direccion,
            //    Telefono = model.Telefono,
            //    Logo = model.Logo,
            //    PaginaWeb = model.PaginaWeb,
            //    FechaAlta = model.FechaAlta,
            //    HoraCierre = model.HoraCierre

            //};
            var respuesta = _RestauranteService.insertar(restaurante);
            return Ok();
        }
    }
}