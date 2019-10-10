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
    public class OrdenTieneProductosController : ControllerBase
    {
        private readonly IOrdenTieneProductoService _ordenTieneProductoService;
        private readonly IMapper _mapper;
        public OrdenTieneProductosController(IOrdenTieneProductoService ordenTieneProductoService, IMapper mapper)
        {
            _ordenTieneProductoService = ordenTieneProductoService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<List<OrdenTieneProductoDTO>> Get(int id)
        {
            var ordenTieneProducto = _ordenTieneProductoService.ObtenerOrdenTieneProductos(id);
            var model = new List<OrdenTieneProductoDTO>();

            _mapper.Map(ordenTieneProducto, model);

            return model;
        }


        [HttpPost]
        public IActionResult Post([FromBody] OrdenTieneProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var ordenTieneProducto = new Restaurantes.Core.Entities.OrdenTieneProducto();
            _mapper.Map(model, ordenTieneProducto);
            var respuesta = _ordenTieneProductoService.Agregar(ordenTieneProducto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var orden = _ordenTieneProductoService.Obtener(id);

            if (orden == null)
                return BadRequest();

            _ordenTieneProductoService.Eliminar(id);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Eliminar([FromBody] int[] ids)
        {
            _ordenTieneProductoService.Eliminar(ids);

            return Ok();

        }
    }
}