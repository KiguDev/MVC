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
        private readonly IOrdenService _ordenService;
        private readonly IOrdenTieneProductoService _ordenTieneProductoService;
        private readonly IMapper _mapper;
        public OrdenTieneProductosController(IOrdenService ordenService, IMapper mapper, IOrdenTieneProductoService ordenTieneProductoService)
        {
            _ordenService = ordenService;
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
        [Route("NuevaOrdenProd")]
        public ActionResult Post([FromForm]string ordprod)
        {
            var o = (dynamic)Newtonsoft.Json.JsonConvert.DeserializeObject(ordprod);
            var ordid = Convert.ToInt32(o.OrdenId.Value);
            var prodid = Convert.ToInt32(o.ProductoId.Value);
            var precio = Convert.ToInt32(o.Precio.Value);

            var ordenprod = new OrdenTieneProducto();
            ordenprod.OrdenId = ordid;
            ordenprod.ProductoId = prodid;
            ordenprod.Precio = precio;

            if (ordprod == null)
                return BadRequest();

            if (_ordenService.EstaAbierta(ordid) == true) {
                if (_ordenTieneProductoService.CompruebaOrdenProducto(ordenprod.OrdenId, ordenprod.ProductoId) == false)
                {
                    ordenprod.Cantidad = 1;
                    _ordenTieneProductoService.Agregar(ordenprod);
                }
                else
                {
                    _ordenTieneProductoService.ActualizarOrdenProd(ordenprod);
                }

                var orden = _ordenService.Obtener(ordid);
                double total = 0;
                if (orden == null)
                    return BadRequest();

                var ordenesproductos = new List<OrdenTieneProducto>();

                ordenesproductos = _ordenTieneProductoService.ObtenerOrdenTieneProductos(ordid);

                foreach (var prod in ordenesproductos)
                {
                    total = (prod.Precio * prod.Cantidad) + total;
                }

                orden.Total = total;

                _ordenService.Editar(orden);
            }

            return Ok();
        }

        [HttpPost]
        [Route("EliminarOrdenProd")]
        public ActionResult Delete([FromForm]string ordprod)
        {
            var o = (dynamic)Newtonsoft.Json.JsonConvert.DeserializeObject(ordprod);
            var ordid = Convert.ToInt32(o.OrdenId.Value);
            var prodid = Convert.ToInt32(o.ProductoId.Value);

            var ordenprod = new OrdenTieneProducto();
            ordenprod.OrdenId = ordid;
            ordenprod.ProductoId = prodid;

            if (ordprod == null)
                return BadRequest();

            if (_ordenTieneProductoService.CompruebaOrdenProductoCantidad(ordenprod.OrdenId, ordenprod.ProductoId) == false)
            {
                _ordenTieneProductoService.ActualizarOrdenProdMinus(ordenprod);

            }
            else
            {
                _ordenTieneProductoService.Eliminar(ordenprod.OrdenId, ordenprod.ProductoId);
            }

            var orden = _ordenService.Obtener(ordid);
            double total = 0;
            if (orden == null)
                return BadRequest();

            var ordenesproductos = new List<OrdenTieneProducto>();

            ordenesproductos = _ordenTieneProductoService.ObtenerOrdenTieneProductos(ordid);

            foreach (var prod in ordenesproductos)
            {
                total = (prod.Precio * prod.Cantidad) + total;
            }

            orden.Total = total;

            _ordenService.Editar(orden);

            return Ok();
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

        [HttpDelete]
        public ActionResult Eliminar([FromBody] int[] ids)
        {
            _ordenTieneProductoService.Eliminar(ids);

            return Ok();

        }
    }
}