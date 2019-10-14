using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;

namespace RestauranteMVC.API
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IServicio<OrdenProducto> _serviceOrdenProducto;
        private readonly IServicio<Producto> _productService;
        private readonly IServicio<Orden> _ordenService;
        private readonly IOrdenProducto _serviceOrder;
        public OrderDetailsController(IServicio<OrdenProducto> ordenProducto, IServicio<Producto> productoService, IServicio<Orden> ordenServicio, IOrdenProducto serviceOrder)
        {
            _serviceOrdenProducto = ordenProducto;
            _productService = productoService;
            _ordenService = ordenServicio;
            _serviceOrder = serviceOrder;
        }
        [HttpGet]
        public ActionResult<List<OrdenProducto>> Index(int id)
        {
            var orderdetails = _serviceOrder.GetAllInclude(id);
            return orderdetails;
        }

        [HttpPost]
        public ActionResult AgregarProducto([FromBody]OrdenProducto model)
        {
            model.Producto = _productService.Get(model.ProductoId);
            var orden = _ordenService.Get(model.OrdenId);
            model.Orden = orden;
            _serviceOrdenProducto.Insert(model);
            _serviceOrdenProducto.SaveChanges();
            orden.Total += (model.Producto.Precio * model.Cantidad);
            _ordenService.Update(orden);
            _ordenService.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult ActulizarCantidad([FromBody] OrdenProducto model)
        {
            var ordenProducto = _serviceOrder.Get(model);
            var cantidadActual = ordenProducto.Cantidad;
            ordenProducto.Cantidad = model.Cantidad;
            _serviceOrder.Update(ordenProducto);
            _serviceOrder.SaveChanges();
            var orden = _ordenService.Get(model.OrdenId);
            orden.Total += (model.Cantidad - cantidadActual) * model.Producto.Precio;
            _ordenService.Update(orden);
            _ordenService.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public ActionResult RemoveProduct([FromBody] OrdenProducto model)
        {
            var ordenProducto = _serviceOrder.Get(model);
            _serviceOrder.DeleteRercord(ordenProducto);
            _serviceOrder.SaveChanges();
            var orden = _ordenService.Get(model.OrdenId);
            orden.Total += -(model.Cantidad * model.Producto.Precio);
            _ordenService.Update(orden);
            _ordenService.SaveChanges();
            return Ok();
        }
    }
}