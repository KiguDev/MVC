using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Entities;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Services;
using Restaurantes.Models;

namespace Productos.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;
        public ProductosController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet("{resid}")]
        public ActionResult<List<ProductoDTO>> Get(int resid)
        {
            var productos = _productoService.ObtenerProductosRestaurante(resid);
            var model = new List<ProductoDTO>();

            _mapper.Map(productos, model);

            return model;
        }


        [HttpPost]
        public IActionResult Post([FromBody] ProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var producto = new Restaurantes.Core.Entities.Producto();
            _mapper.Map(model, producto);
            var respuesta = _productoService.Agregar(producto);
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, ProductoViewModel model)
        {
            var producto = _productoService.Obtener(id);

            if (producto == null)
                return BadRequest();

            producto.Nombre = model.Nombre;
            producto.Ingredientes = model.Ingredientes;
            producto.Cantidad = model.Cantidad;
            producto.Precio = model.Precio;


            _productoService.Editar(producto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mesa = _productoService.Obtener(id);

            if (mesa == null)
                return BadRequest();

            _productoService.Eliminar(id);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Eliminar([FromBody] int[] ids)
        {
            _productoService.Eliminar(ids);

            return Ok();

        }
    }
}