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
    [Route("api/[Controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenService _ordenService;
        private readonly IMapper _mapper;
        private readonly IOrdenProductosService _ordenProductosService;

        public OrdenesController(IOrdenService ordenService, IMapper mapper, IOrdenProductosService ordenProductosService)
        {
            _ordenService = ordenService;
            _mapper = mapper;
            _ordenProductosService = ordenProductosService;

        }

        [HttpGet]
        public ActionResult <List<OrdenDTO>> Get(int id)
        {
            var ordenes = _ordenService.ObtenerOrdenes(id);
            var model = new List<OrdenDTO>();
            _mapper.Map(ordenes, model);
            return model;
            

        }

        [HttpPost]
        public ActionResult Post(int id,[FromBody] Restaurante.Core.Entities.Orden model)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var orden = new Restaurante.Core.Entities.Orden();
       
            _mapper.Map(model, orden);

            //{
            //    Nombre = model.Nombre,
            //    Domicilio = model.Direccion,
            //    PaginaWeb = model.PaginaWeb,
            //    HoraDeCierre = model.HoraDeCierre


            //};
            _ordenService.Agregar(orden);
            
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Restaurante.Core.Entities.Orden model)
        {
            var orden = _ordenService.Obtener(id);
            if (orden == null)
            {
                return BadRequest();
            }
            _mapper.Map(model, orden);

            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var orden = _ordenService.Obtener(id);
            if (orden == null)
            {
                return BadRequest();
            }
            _ordenService.Eliminar(orden);
            return Ok();
            
        }
    }
}