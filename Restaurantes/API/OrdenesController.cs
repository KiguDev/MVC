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
    public class OrdenesController : ControllerBase
    {
        private IOrdenService _ordenService;
        private IOrdenTieneProductoService _ordenTieneProductoService;
        private readonly IMapper _mapper;

        public OrdenesController(IOrdenService ordenService, IMapper mapper,
            IOrdenTieneProductoService ordenTieneProductoService)
        {
            _ordenService = ordenService;
            _ordenTieneProductoService = ordenTieneProductoService;
            _mapper = mapper;
        }

        //GET
        [HttpGet("{id}")]
        public ActionResult<List<OrdenDTO>> Get(int id)
        {
            var ordenes = _ordenService.ObtenerOrdenes(id);
            var model = new List<OrdenDTO>();
            _mapper.Map(ordenes, model);
            return model;
        }

        //ADD
        [HttpPost]
        public ActionResult Post([FromForm]int id)
        {

            var orden = new Orden
            {
                FechaAlta = DateTime.Now,
                Estatus = 1,
                RestauranteId = id
            };

            _ordenService.Agregar(orden);
            return Ok(orden.Id);
        }

        //ADD ORDEN TIENE PRODUCTO
        [HttpPost]
        [Route("PostOrdenTieneProducto")]
        public ActionResult PostOrdenTieneProducto([FromForm] OrdenTieneProductoViewModel model)
        {
            var ordenTieneProducto = new OrdenTieneProducto
            {
                OrdenId = model.OrdenId,
                ProductoId = model.ProductoId,
                Cantidad = model.Cantidad,
            };
            _ordenTieneProductoService.Agregar(ordenTieneProducto);
            return Ok();
        }

        //EDIT ORDEN TIENE PRODUCTO
        [HttpPut]
        [Route("PutOrdenTieneProducto")]
        public ActionResult PutOrdenTieneProducto(OrdenTieneProductoViewModel model)
        {
            var ordenTieneProducto = _ordenTieneProductoService.Obtener(model.OrdenId, model.ProductoId);
            ordenTieneProducto.Cantidad = model.Cantidad;
            _ordenTieneProductoService.Editar(ordenTieneProducto);
            return Ok();
        }

        //DELETE ORDEN TIENE PRODUCTO
        [HttpDelete]
        public ActionResult Delete(int ordenId, int productoId)
        {
            var ordenTieneProducto = _ordenTieneProductoService.Obtener(ordenId, productoId);
            _ordenTieneProductoService.Eliminar(ordenTieneProducto);
            return Ok();
        }



    }
}
