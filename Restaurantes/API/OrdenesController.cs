using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenService _ordenService;
        private readonly IOrdenTieneProductoService _ordenTPService;
        
        public OrdenesController(IOrdenService ordenService, IOrdenTieneProductoService ordenTPService, IProductoService productoService)
        {
            _ordenService = ordenService;
            _ordenTPService = ordenTPService;
            
        }
        [HttpGet("{id}")]
        public ActionResult<List<OrdenViewModel>> getOrdenes(int id)
        {
           var ordenes = _ordenService.ObtenerOrdenes(id);
            var ordenesVM = new List<OrdenViewModel>();

            foreach (var orden in ordenes)
            {
                var ordenVM = new OrdenViewModel {
                    Estatus = orden.Estatus,
                    FechaAlta = orden.FechaAlta.ToLongDateString() + "  " + orden.FechaAlta.ToShortTimeString(),
                    RestauranteId = orden.RestauranteId,
                    Total = orden.Total,
                    cantidadP = orden.Productos.Count,
                    Id = orden.Id
                };
                ordenesVM.Add(ordenVM);
            }
            return Ok(ordenesVM);
        }

        [HttpPut("{id}")]
        public ActionResult putOrden(int id, Orden model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteOrden(int id, Orden model)
        {
            return Ok();
        }


        [HttpPost]
        [Route("InsertarOrden")]
        public ActionResult postOrden([FromForm] int resId)
        {
            var orden = new Orden {
                FechaAlta = DateTime.Now,
                RestauranteId = resId,
                Estatus = 1
            };
            var ordenId = _ordenService.insertar(orden);
            return Ok(ordenId);
        }
        [Route("InsertarOTP")]
        [HttpPost]
        public ActionResult postOrdenTP([FromForm] OrdenTPViewModel model)
        {

           
            var OrdenTP = new OrdenTieneProducto { 
                OrdenId = model.OrdenId,
                ProductoId = model.ProductoId,
                Cantidad = model.Cantidad,
            };

            var ordenTpID = _ordenTPService.insertar(OrdenTP);
            return Ok(ordenTpID);
        }
    }
}