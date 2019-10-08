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

        [HttpGet]
        public ActionResult<List<ProductoViewModel>> Get(int id)
        {
            var restaurantes = _productoService.ObtenerProductos(id);
            var model = new List<ProductoViewModel>();
            _mapper.Map(restaurantes, model);

            return model;
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var producto = new Restaurante.Core.Entities.Producto();
            _mapper.Map(model, producto);

            //{
            //    Nombre = model.Nombre,
            //    Domicilio = model.Direccion,
            //    PaginaWeb = model.PaginaWeb,
            //    HoraDeCierre = model.HoraDeCierre


            //};
            _productoService.Agregar(producto);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, ProductoViewModel model)
        {
            var producto = _productoService.Obtener(id);
            if (producto == null)
            {
                return BadRequest();
            }
            _mapper.Map(model, producto);
            //restaurante.Nombre = model.Nombre;
            //restaurante.PaginaWeb = model.PaginaWeb;
            //restaurante.Telefono = int.Parse(model.Telefono);

            return Ok();

        }
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
        
       
    }
}