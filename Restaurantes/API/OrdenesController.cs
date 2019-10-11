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
        private readonly IOrdenTieneProductoService _ordenTieneProductoService;
        private readonly IMapper _mapper;
        public OrdenesController(IOrdenService ordenService, IMapper mapper, IOrdenTieneProductoService ordenTieneProductoService)
        {
            _ordenService = ordenService;
            _ordenTieneProductoService = ordenTieneProductoService;
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
            var resultado = _ordenService.Agregar(orden);
            return Ok();
        }

        [HttpPost]
        [Route("NuevaOrden")]
        public IActionResult Post([FromForm]string RestauranteId)
        {
            var orden = new Orden();

            orden.FechaAlta = DateTime.Now;
            orden.RestauranteId = Int32.Parse(RestauranteId); ;
            orden.Total = 0;
            orden.Estatus = 0;

            _ordenService.Agregar(orden);
            return Ok();
        }


        [HttpPost]
        [Route("CambiarEstatus")]
        public ActionResult Put([FromForm]string ord)
        {
            var o = (dynamic)Newtonsoft.Json.JsonConvert.DeserializeObject(ord);
            var id = Convert.ToInt32(o.Id.Value);
            var estatus = Convert.ToInt32(o.Estatus.Value);

            var orden = _ordenService.Obtener(id);

            if (orden == null)
                return BadRequest();

            if(estatus == 0)
            { orden.Estatus = 1; }
            else if(estatus == 1)
            {
                orden.Estatus = 0;
            }            

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