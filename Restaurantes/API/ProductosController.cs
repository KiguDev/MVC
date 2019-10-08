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

    public class ProductosController : ControllerBase
    {
        private IProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductosController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<List<ProductoDTO>> Get(int id)
        {
            var productos = _productoService.ObtenerProductos(id);
            var model = new List<ProductoDTO>();
            _mapper.Map(productos, model);
            return model;
        }

        //ADD
        [HttpPost]
        public ActionResult Post([FromBody] ProductoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos inválidos");

            var producto = new Producto
            {
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Precio = model.Precio,
                RestauranteId = model.RestauranteId
            };

            _productoService.Agregar(producto);
            return Ok();
        }

        //EDIT
        [HttpPut]
        public ActionResult Put(ProductoViewModel model)
        {
            var producto = _productoService.Obtener(model.Id);
            if (producto == null)
            {
                return BadRequest();
            }
            producto.Nombre = model.Nombre;
            producto.Descripcion = model.Descripcion;
            producto.Precio = model.Precio;


            _productoService.Editar(producto);
            return Ok();
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = _productoService.Obtener(id);
            if (producto == null)
            {
                return BadRequest();
            }

            _productoService.Eliminar(producto);
            return Ok();
        }

        //DELETE ARRAY
        [HttpDelete]
        public ActionResult Delete([FromBody]int[] ids)
        {
            _productoService.Eliminar(ids);
            return Ok();
        }
    }
}
