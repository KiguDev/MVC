using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Ordenes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenService _ordenService;
        private readonly IMapper _mapper;
        public OrdenesController(IOrdenService ordenService, IMapper mapper)
        {
            _ordenService = ordenService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<List<OrdenDTO>> Get(int id)
        {
            var ordenes = _ordenService.ObtenerOrdenes(id);
            var model = new List<OrdenDTO>();

            _mapper.Map(ordenes, model);

            return model;
        }


        [HttpPost]
        public IActionResult Post([FromBody] OrdenViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var orden = new Restaurantes.Core.Entities.Orden();
            _mapper.Map(model, orden);
            return Ok(_ordenService.Agregar(orden));
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, OrdenViewModel model)
        {
            var orden = _ordenService.Obtener(id);

            if (orden == null)
                return BadRequest();
            orden.Estatus = model.Estatus;
            orden.FechaAlta = model.FechaAlta;
            orden.Total = model.Total;
            _ordenService.Editar(orden);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var orden = _ordenService.Obtener(id);

            if (orden == null)
                return BadRequest();

            _ordenService.Eliminar(id);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Eliminar([FromBody] int[] ids)
        {
            _ordenService.Eliminar(ids);

            return Ok();

        }
    }
}