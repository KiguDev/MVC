using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
            private readonly IProductoService _productoService;
            private readonly IMapper _mapper;
            public ProductoController(IProductoService ProductoService, IMapper mapper)
            {
                _productoService = ProductoService;
                _mapper = mapper;
            }

            [HttpGet("{id}")]
            public ActionResult<List<ProductoDTO>> getProducto(int id)
            {
                var productos = _productoService.ObtenerProducto(id);
                var model = new List<ProductoDTO>();
                _mapper.Map( productos, model);
                return model;
            }

            [HttpPut("{id}")]
            public ActionResult putProducto(int id, ProductoViewModel model)
            {
                var producto = _productoService.Obtener(id);
                if (producto == null)
                    return BadRequest();
            producto.Nombre = model.Nombre;
            producto.Precio = model.Precio;
            producto.Descripcion = model.Descripcion;
            producto.Imagen = model.Imagen;
           

                _productoService.Editar(producto);
                return Ok();
            }

            [HttpDelete("{id}")]
            public ActionResult deleteProducto(int id)
            {
                _productoService.Eliminar(id);
                return Ok();
            }


            [HttpPost("{id}")]
            public ActionResult postProducto([FromBody] ProductoViewModel model, int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Datos Invalidos");
                }


                var producto = new Restaurantes.Core.Entities.Producto
                {
                    Id = model.Id,
                    Precio = model.Precio,
                    Descripcion = model.Descripcion,
                    Imagen = model.Imagen

                };
                producto.Id = id;
                ViewData["Id"] = producto.RestauranteId;
                var respuesta = _productoService.Insertar(producto);
                return Ok();
            }
        }
    }