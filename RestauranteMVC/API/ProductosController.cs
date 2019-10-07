using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.core.Interfaces;
using RestauranteMVC.Models;

namespace RestauranteMVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly IProductosService _productoService;
        private readonly IMapper _mapper;

        public ProductosController(IProductosService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }
        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet("{id}")]
        public ActionResult<List<ProductoDTO>> Get(int id)
        {
            var productos = _productoService.ObtenerProducto(id);
            var model = new List<ProductoDTO>();
            _mapper.Map(productos, model);
            return model;
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductoViewModel model)
        {
            var producto = new Restaurante.core.Entities.Producto
            {
                Nombre = model.Nombre,
                Ingredientes = model.Ingredientes,
                Precio = model.Precio,
                RestauranteId = model.RestauranteId
            };
            _productoService.InsertarProducto(producto);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, ProductoViewModel model)
        {
            var producto = _productoService.Obtener(id);

            if (producto == null || producto.RestauranteId != model.RestauranteId)
            {
                return BadRequest();
            }

            producto.Nombre = model.Nombre;
            producto.Ingredientes = model.Ingredientes;
            producto.Precio = model.Precio;

            _productoService.EditarProducto(producto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productoService.EliminarProducto(id);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody]int[] ids)
        {
            _productoService.EliminarProductos(ids);
            return Ok();
        }
    }
}