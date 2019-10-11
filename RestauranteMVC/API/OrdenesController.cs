using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.core.Entities;
using Restaurante.core.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenesService _ordenService;
        private IProductosService _productoService;
        private readonly IMapper _mapper;

        public OrdenesController(IOrdenesService ordenesService, IProductosService productoService, IMapper mapper)
        {
            _ordenService = ordenesService;
            _productoService = productoService;
            _mapper = mapper;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<List<Orden>> GetOrdenes(int id)
        {
            var ordenes = _ordenService.ObtenerTodas(id);
            return ordenes;
        }

        
        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<List<Producto>> GetProductos(int id)
        {
            var productos = _productoService.ObtenerProducto(id);
            return productos;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<List<OrdenProducto>> GetOrdenProductos(int id)
        {
            var ordenProductos = _ordenService.ObtenerProductoOrden(id);
            return ordenProductos;
        }

        [HttpPost]
        public int Post([FromForm] OrdenViewModel model)
        {
            model.FechaDeAlta = DateTime.Now;
            model.Estatus = 0;
            model.EmpleadoId = 0;
            var orden = new Restaurante.core.Entities.Orden();
            _mapper.Map(model, orden);
            var ordenId = _ordenService.InsertaOrden(orden);
            return ordenId;
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<Orden> PostProductoOrden([FromForm] OrdenProductoViewModel model)
        {
            var ordenProducto = new Restaurante.core.Entities.OrdenProducto();
            _mapper.Map(model, ordenProducto);
            //var inserto = true;
            var inserto = _ordenService.AgregarProductoOrden(ordenProducto);
            if (!inserto)
            {
                return BadRequest();
            }
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public bool PostCambiarEstatus([FromForm] int idOrden)
        {
            var cambio = false;
            cambio = _ordenService.CambiarEstatus(idOrden);
            if (!cambio)
            {
                return cambio;
            }
            return cambio;
        }

        [Route("[action]")]
        [HttpPost]
        public bool PostEditarOrden([FromForm] OrdenViewModel model)
        {
            var cambio = false;
            var orden = new Restaurante.core.Entities.Orden();
            _mapper.Map(model, orden);
            cambio = _ordenService.EditarOrden(orden);
            if (!cambio)
            {
                return cambio;
            }
            return cambio;
        }

        [Route("[action]")]
        [HttpPost]
        public bool PostEliminarProductoOrden([FromForm] int[] ids)
        {
            var cambio = false;
            //var ultimo = ids.Length - 1;
            var idOrden = ids[ids.Length - 1];
            int[] productos = new int[ids.Length-1];
            for (var i = 0; i < ids.Length-1; ++i)
            {
                productos[i] = ids[i];
            }
            cambio = _ordenService.EliminarProductosOrden(productos,idOrden);
            if (!cambio)
            {
                return cambio;
            }
            return cambio;
        }

        [Route("[action]")]
        [HttpPost]
        public bool PostEditarProductoOrden([FromForm] OrdenProductoViewModel model)
        {
            var cambio = false;
            var ordenProducto = new Restaurante.core.Entities.OrdenProducto();
            _mapper.Map(model, ordenProducto);
            cambio = _ordenService.EditarProductoOrden(ordenProducto);
            if (!cambio)
            {
                return cambio;
            }
            return cambio;
        }

        /*[HttpPut("{id}")]
        public ActionResult<List<Orden>> Put(int id, Orden model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }*/
    }
}