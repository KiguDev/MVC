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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;
        public ProductosController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }
        [Route("ObtenerProductos")]
        [HttpGet]
        public ActionResult<List<ProductoDTO>> getProductos(int id)
        {
            var producto = _productoService.ObtenerProductos(id);
            var model = new List<ProductoDTO>();
            _mapper.Map(producto, model);
            return model;
        }

        [HttpPut("{id}")]
        public ActionResult putProducto(int id, ProductoViewModel model)
        {
            var producto = _productoService.Obtener(id);
            if (producto == null)
                return BadRequest();
            producto.Nombre = model.Nombre;
            producto.Ingredientes = model.Ingredientes;
            producto.Precio = model.Precio;

            _productoService.Editar(producto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteProducto(int id)
        {
            _productoService.Eliminar(id);
            return Ok();
        }


        [HttpDelete]
        public ActionResult deleteProducto([FromBody]int[] ids)
        {
            _productoService.EliminarVarios(ids);
            return Ok();
        }


        [HttpPost]
        public ActionResult postProducto([FromBody] ProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var producto = new Restaurante.Core.Entities.Producto
            {
                Nombre = model.Nombre,
                Ingredientes = model.Ingredientes,
                Precio = model.Precio,
                RestauranteId = model.RestauranteId
            };

            var respuesta = _productoService.insertar(producto);
            return Ok();
        }
    }
}