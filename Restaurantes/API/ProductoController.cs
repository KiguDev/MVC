using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;
        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public ActionResult<List<ProductoDTO>> getProductos(int id)
        {
            var productos = _productoService.ObtenerProductos(id);
            var model = new List<ProductoDTO>();
            _mapper.Map(productos, model);
            return model;
        }

        [HttpPut]
        public ActionResult putProducto([FromBody]ProductoViewModel model)
        {
            var producto = _productoService.Obtener(model.Id);
            if (producto == null)
                return BadRequest();
            producto.Nombre = model.Nombre;
            producto.Imagen = model.Imagen;
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


        [HttpPost("{id}")]
        public ActionResult postProducto([FromBody] ProductoViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }


            var producto = new Restaurante.Core.Entities.Producto
            {
                Nombre = model.Nombre,
                Precio = model.Precio,
                Imagen = model.Imagen

            };
            producto.RestauranteId = id;
            var respuesta = _productoService.insertar(producto);
            return Ok();
        }
    }
}