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

        //GET ORDEN
        
        [Route("GetOrden")]
        public ActionResult<OrdenDTO> GetOrden(int id)
        {
            var orden = _ordenService.Obtener(id);
            var model = new OrdenDTO();
            _mapper.Map(orden, model);
            return model;
        }

        [Route("CerrarOrden")]
        public ActionResult CerrarOrden(int id)
        {
            _ordenService.CerrarOrden(id);
            return Ok();
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


        //GET ORDEN TIENE PRODUCTO
       
        [Route("GetOrdenTieneProducto")]
        public ActionResult<List<OrdenTieneProductoDTO>> GetOrdenTieneProducto(int id)
        {
            var productos = _ordenTieneProductoService.ObtenerOrdenTieneProducto(id);
            var model = new List<OrdenTieneProductoDTO>();
            _mapper.Map(productos, model);
            return model;
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
        
        [Route("PutOrdenTieneProducto")]
        public ActionResult PutOrdenTieneProducto([FromForm] OrdenTieneProductoViewModel model)
        {
            var ordenTieneProducto = _ordenTieneProductoService.Obtener(model.OrdenId, model.ProductoId);
            if (ordenTieneProducto != null)
            {
                if(model.Cantidad == 0)
                {
                    _ordenTieneProductoService.Eliminar(ordenTieneProducto);
                }
                else
                {
                    ordenTieneProducto.Cantidad = model.Cantidad;
                    _ordenTieneProductoService.Editar(ordenTieneProducto);
                }
                
            }
            else
            {
                var otp = new OrdenTieneProducto
                {
                    OrdenId = model.OrdenId,
                    ProductoId = model.ProductoId,
                    Cantidad = model.Cantidad,
                };
                _ordenTieneProductoService.Agregar(otp);
            }
            return Ok();
        }

        
    }
}
