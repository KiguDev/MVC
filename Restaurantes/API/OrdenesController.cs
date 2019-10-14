using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurantes.Models;

namespace Restaurantes.API
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenService _ordenService;
        private readonly IMapper _mapper;
        private readonly IOrdenProductosService _ordenProductosService;
        private readonly IProductoService _productoService;

        public OrdenesController(IOrdenService ordenService, IMapper mapper, IOrdenProductosService ordenProductosService, IProductoService productoService)
        {
            _ordenService = ordenService;
            _mapper = mapper;
            _ordenProductosService = ordenProductosService;
            _productoService = productoService;

        }

        [HttpGet]
        public ActionResult<List<OrdenDTO>> Get(int id)
        {
            var ordenes = _ordenService.ObtenerOrdenes(id);
            var model = new List<OrdenDTO>();
            _mapper.Map(ordenes, model);
            return model;


        }

        [HttpPost]
        public ActionResult Post(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Datos Invalidos");
            }
            var orden = new Restaurante.Core.Entities.Orden();

            orden.RestauranteId = id;
            orden.Estatus = 0;
            orden.FechaAlta = DateTime.Now;
            orden.Total = 0;

            //{
            //    Nombre = model.Nombre,
            //    Domicilio = model.Direccion,
            //    PaginaWeb = model.PaginaWeb,
            //    HoraDeCierre = model.HoraDeCierre


            //};
             
            return Ok(_ordenService.Agregar(orden));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Restaurante.Core.Entities.Orden model)
        {
            var orden = _ordenService.Obtener(id);
            if (orden == null)
            {
                return BadRequest();
            }
            _mapper.Map(model, orden);

            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var orden = _ordenService.Obtener(id);
            if (orden == null)
            {
                return BadRequest();
            }
            _ordenService.Eliminar(orden);
            return Ok();

        }

        [HttpPost]
        [Route("GuardarOrdenProducto")]
        public IActionResult GuardarOrdenProducto([FromForm] OrdenProductoViewModel model)
        {
            var ordenProducto = new OrdenProducto
            {
                OrdenId = model.OrdenId,
                ProductoId = model.ProductoId,
                Cantidad = model.Cantidad
                
            };
            var ordenp = _ordenProductosService.Obtener(ordenProducto.OrdenId, ordenProducto.ProductoId);
            if (ordenp != null)
            {
                _ordenProductosService.Editar(ordenp);
            }
            else
            {
                _ordenProductosService.Agregar(ordenProducto);
                
            }
            return Ok();
        


        }
    }
}